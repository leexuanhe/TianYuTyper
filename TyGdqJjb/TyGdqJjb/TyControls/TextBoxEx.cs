using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TyGdqJjb.TyData;
using TyGdqJjb.TyModels;
using TyModel.Data;
using TyModel.Model;

namespace TyGdqJjb.TyControls
{
    public sealed class TextBoxEx:TextBox
    {
        private DgetSourceModel DgetSourceModel { set; get; }
        
        public void SetDgetSourceModel(DgetSourceModel dgetSourceModel)
        {
            this.DgetSourceModel = dgetSourceModel;
            //跟打完成时 设为只读
            DgetSourceModel.TypeEnd += (info, time) => this.ReadOnly = true;
            //跟打开始时 设为可写
            TypeData.Instance.Init += (sender, args) =>
                {
                    this.TextChanged -= TextBoxEx_TextChanged;
                    this.ResetText();
                    this.ReadOnly = false;
                    Array.Clear(_last,0,2);
                    this.TextChanged += TextBoxEx_TextChanged;
                    dgetSourceModel.Progress = 0;
                    TypeFlag = 0;
                    TempData.Instance.BackReport.Clear();
                    TempData.Instance.TypeReport.Clear();
                    this.Focus();
                };
            //主题
            Font = GlobalModel.Instance.Theme.GFont;
            BackColor = GlobalModel.Instance.Theme.GBgColor;
        }

        private delegate void SetRightWrong();

        private readonly SetRightWrong _setRightWrong;

        public TextBoxEx()
        {
            //强制设置
            //多行模式
            Multiline = true;
            //边框NONE
            BorderStyle = BorderStyle.None;
            //总显示滚动条
            ScrollBars = ScrollBars.Vertical;
           
            _setRightWrong = SetRw;
            this.TextChanged += TextBoxEx_TextChanged;
        }

        #region 私有处理

        /// <summary>
        /// 此项用于确定 每次跟打长度
        /// </summary>
        private int[] _last = new int[2];
        private int[] HisLine = new int[2];
        private DateTime[] _lastTime = new DateTime[2];
        private int[] _lastKick = new int[2];
        /// <summary>
        /// 跟打标记
        /// </summary>
        public int TypeFlag = 0;

        private int 上次输入标记 = 1;
        private int WordHeight = 20;
        /// <summary>
        /// 正误判断
        /// </summary>
        private void SetRw()
        {
            //获取源数据
            DgetSourceModel.MainForm.BeginInvoke(new MethodInvoker(() =>
                {
                    var text = this.DgetSourceModel.RichTextBoxEx.Text;
                    var textType = Text;
                    if (text.Length <= 0) return;
                    TypeFlag++;
                    var textLenNow = textType.Length;
                    var textLen = text.Length;
                    if (TypeFlag == 1)
                    {
                        DgetSourceModel.Start(TypeState.Typing, DateTime.Now);
                        TypeData.Instance.ImfactTextCount = TypeData.Instance.TypeText.Length - textLenNow;
                        TypeData.Instance.KickTimes = 0;
                        _lastTime[1] = DateTime.Now;//起打时间
                        _lastKick[1] = 0;
                    }
                    //自动跳行
                    int getstart = this.DgetSourceModel.RichTextBoxEx.GetLineFromCharIndex(textLenNow);
                    //int getExend = this.DgetSourceModel.RichTextBoxEx.GetLineFromCharIndex(TextLen - 1);//获取最后一行的行号 也就是 总行号
                    HisLine[1] = getstart;
                    if (HisLine[1] != HisLine[0])
                    {

                        int sizeH = this.DgetSourceModel.RichTextBoxEx.ClientSize.Height; //一屏高度
                        int onePHan = (int) Math.Ceiling((double) sizeH/TempData.Instance.WordHeight); //一屏行数
                        int sizeH_ = onePHan * TempData.Instance.WordHeight;
                        int nowHan = this.DgetSourceModel.RichTextBoxEx.GetPositionFromCharIndex(textLenNow).Y; //当前
                        int allH = this.DgetSourceModel.RichTextBoxEx.GetPositionFromCharIndex(textLen).Y + TempData.Instance.WordHeight;
                            //末行像素
                        //MessageBox.Show("末行高度：" + allH.ToString() + "\n一屏高度：" + sizeH.ToString() + "\n一行高度：" + Glob.oneH + "\n当前高度：" + nowHan + "\n可见总数：" + onePHan + "\n第一像素：" + this.DgetSourceModel.RichTextBoxEx.GetPositionFromCharIndex(0).Y);
                        if (nowHan > 0)
                        {
                            if (allH > sizeH) //末行高度超出 一屏高度时才启用滚屏
                            {
                                if (nowHan >= (sizeH_ - TempData.Instance.WordHeight * 2)) //走到倒数第二行时
                                {
                                    this.DgetSourceModel.RichTextBoxEx.SelectionStart = textLenNow - 上次输入标记;
                                    this.DgetSourceModel.RichTextBoxEx.ScrollToCaret();
                                }
                            }
                        }
                        else
                        {
                            this.DgetSourceModel.RichTextBoxEx.SelectionStart = textLenNow;
                            this.DgetSourceModel.RichTextBoxEx.ScrollToCaret();
                        }
                        HisLine[0] = HisLine[1];
                    } //此上是对 滚动条的控制


                    if (textType.Length > text.Length)
                    {
                        return;
                    }
                    //获取当前字数
                    _last[0] = _last[1];
                    _last[1] = textType.Length;
                    _lastTime[0] = _lastTime[1];
                    _lastTime[1] = DateTime.Now;
                    _lastKick[0] = _lastKick[1];
                    _lastKick[1] = TypeData.Instance.KickTimes;
                    var length = _last[1] - _last[0];
                    if (length > 0)
                    {
                        上次输入标记 = length;
                        for (var i = _last[0]; i < _last[1]; i++)
                        {
                            CheckType(text[i], textType[i], i);
                        }
                        //type report
                        var key = _last[0].ToString() + length;
                        if (TempData.Instance.TypeReport.Exists(o => o.Key == key))
                        {
                            var item = TempData.Instance.TypeReport.Find(o => o.Key == key);
                            item.Kicks = _lastKick[1] - item.StartKickIndex;
                            item.ReTypeTimes++;
                            item.UseTime = DateTime.Now - item.StartTime;
                        }
                        else
                        {
                            TempData.Instance.TypeReport.Add(new TypeReportData
                                {
                                    Key = key,
                                    Start = _last[0],
                                    Word = text.Substring(_last[0], length),
                                    StartTime = _lastTime[0],
                                    UseTime = DateTime.Now - _lastTime[0],
                                    ReTypeTimes = 1,
                                    StartKickIndex = _lastKick[0],
                                    Kicks = _lastKick[1] - _lastKick[0]
                                });
                        }
                    }
                    else
                    {
                        //将删除的字归位
                        this.DgetSourceModel.RichTextBoxEx.SelectionStart = _last[1];
                        this.DgetSourceModel.RichTextBoxEx.SelectionLength = Math.Abs(length);
                        this.DgetSourceModel.RichTextBoxEx.SelectionBackColor = GlobalModel.Instance.Theme.DBgColor;
                        this.DgetSourceModel.RichTextBoxEx.SelectionColor = Color.Black;
                        //将字符后面的归位
                        for (var i = this.DgetSourceModel.RichTextBoxEx.SelectionStart; i < textType.Length; i++)
                        {
                            CheckType(text[i], textType[i], i);
                        }
                    }
                    //进度条
                    DgetSourceModel.Progress = textType.Length*1.0/text.Length;
                    //打完了
                    if (textType.Length == text.Length)
                    {
                        //打完之后的数据处理
                        TypeFlag = 0;
                        DgetSourceModel.End(TypeState.TypeOver, DateTime.Now);
                    }
                }));
        }

        /// <summary>
        /// 正误处理
        /// </summary>
        /// <param name="a">对照数据</param>
        /// <param name="b">跟打数据</param>
        /// <param name="i">当前标记</param>
        private void CheckType(char a, char b, int i)
        {
            this.DgetSourceModel.RichTextBoxEx.SelectionStart = i;
            this.DgetSourceModel.RichTextBoxEx.SelectionLength = 1;
            this.DgetSourceModel.RichTextBoxEx.SelectionBackColor = a == b
                                                                        ? GlobalModel.Instance.Theme.Right
                                                                        : GlobalModel.Instance.Theme.Wrong;
            if (a == b)
            {
                //对字情况下 包含回改所以必须增加
                if (TypeData.Instance.ErrorWords.Contains(a))
                {
                    TypeData.Instance.ErrorWords.Remove(a);
                }
            }
            else
            {
                //错字情况
                //错字情况下 如果不存在 则增加
                if (!TypeData.Instance.ErrorWords.Contains(a))
                {
                    TypeData.Instance.ErrorWords.Add(a);
                }
            }
        }

        void TextBoxEx_TextChanged(object sender, EventArgs e)
        {
            _setRightWrong.BeginInvoke(null, null);
        }

        /// <summary>
        /// 键数统计
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            TypeData.Instance.KickTimes++;
            if (e.KeyCode == Keys.Back)
            {
                TypeData.Instance.BackTimes++;
                var now = this.TextLength;
                var n = now - 1;
                if (TempData.Instance.BackReport.Keys.Contains(n))
                {
                    TempData.Instance.BackReport[n]++;
                }
                else
                {
                    var temp = (n < 0) ? 0 : n;
                    if (TempData.Instance.BackReport.Keys.Contains(temp))
                    {
                        TempData.Instance.BackReport[temp]++;
                    }
                    else
                    {
                        TempData.Instance.BackReport.Add(temp, 1);
                    }
                }
            }
        }

        #endregion


        
    }
}
