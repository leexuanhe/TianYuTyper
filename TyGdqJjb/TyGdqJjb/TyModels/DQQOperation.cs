using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TyGdqJjb.TyData;
using TyModel.Data;
using TyModel.Model;

namespace TyGdqJjb.TyModels
{
    public class DQQOperation
    {
        #region 从QQ获取数据
        [DllImport("user32.dll", EntryPoint = "SwitchToThisWindow")]
        private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string strclassName, string strWindowName);
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref Point mouse_p);                       //获取鼠标位置

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        private MainForm MainForm { set; get; }
        public DQQOperation(MainForm mainForm)
        {
            this.MainForm = mainForm;
        }
        /// <summary>
        /// 从QQ中获取文本
        /// </summary>
        public void GetTextFromQQ()
        {
            var oldPoint = new Point();
            GetCursorPos(ref oldPoint);
            SetActive();//将群激活
            delay(80);
            var rect = new RECT();
            var quan = FindWindow(null, GlobalModel.Instance.GroupData.Now);
            if (quan.ToInt32() == 0) return;
            GetWindowRect(quan, ref rect);
            SetCursorPos(rect.Left + 20, rect.Top + 120);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            delay(80);
            SendKeys.SendWait("^a");
            SendKeys.SendWait("^a");
            delay(80);
            SendKeys.SendWait("^c");
            try
            {
                GetDuan(Clipboard.GetText());
            }
            catch (Exception exception)
            {
                TyLogModel.Instance.WriteLog(LogType.ClipboardError, exception.Message);
            }
            //放回鼠标
            SetCursorPos(oldPoint.X,oldPoint.Y);
        }

        /// <summary>
        /// 发送数据到 QQ
        /// </summary>
        /// <param name="text">发送的数据</param>
        public void SendToQQ(string text)
        {
            Clipboard.Clear();
            SetActive();//激活窗口
            try
            {
                Clipboard.SetText(text);
            }
            catch (Exception err)
            {
                TyLogModel.Instance.WriteLog(LogType.ClipboardError,err.Message);
                MessageBox.Show("剪切板异常，已记录日志。");
                return;
            }
            delay(80);//延迟
            SendKeys.SendWait("^a");
            delay(50);//延迟
            SendKeys.SendWait("^v");
            delay(50);//延迟
            SendKeys.SendWait("%s");
        }

        /// <summary>
        /// 设置激活
        /// </summary>
        private void SetActive()
        {
            var quan = FindWindow(null, GlobalModel.Instance.GroupData.Now);
            SwitchToThisWindow(quan, true);
        }
        /// <summary>
        /// 延迟
        /// </summary>
        /// <param name="hm">毫秒</param>
        private void delay(int hm)
        {
            DateTime start = DateTime.Now;
            DateTime end;
            while (true)
            {
                end = DateTime.Now;
                TimeSpan ts = end - start;
                if (ts.TotalMilliseconds >= hm)
                {
                    break;
                }
            }
        }
        /// <summary>
        /// 从源数据中获取文段
        /// </summary>
        /// <param name="text">源数据</param>
        private void GetDuan(string text)
        {
            if (text.Length > 0)
            {
                Regex checkIf = new Regex("\r(?!\n)");
                string get_ = text;
                if (checkIf.IsMatch(text))
                {
                    get_ = get_.Replace("\r", "\r\n");  //匹配则是QQ2009+
                }

                TempData.Instance.SourceMatches = GlobalModel.Instance.GetData.FindAllDuan.Matches(get_);
                if (TempData.Instance.SourceMatches.Count <= 0)
                {
                    //未找到文章
                }
                else
                {
                    TempData.Instance.DuanList = new Dictionary<string, List<string>>();
                    string GetDuan = TempData.Instance.SourceMatches[0].ToString();
                    TypeData.Instance.TypeInfo.Id = GlobalModel.Instance.GetData.FindDuanHao.Match(GetDuan).ToString();
                    //获取文章
                    var regexText = new Regex(@".+(?=\s-----第" + TypeData.Instance.TypeInfo.Id + "段)");
                    string aritle = regexText.Match(GetDuan).ToString().Trim();
                    if (aritle.Length > 0)
                    {
                        TypeData.Instance.TypeInfo.Text = aritle;//填入
                        TypeData.Instance.TypeInfo.Title = GlobalModel.Instance.GetData.FindTitle.Match(GetDuan).ToString().Trim();
                        TypeData.Instance.GetTextInitAll(TypeData.Instance.TypeInfo);
                    }
                    else
                    {
                        //未找到文段
                        return;
                    }
                    Action action = () =>
                        {
                            //获取文章
                            var regexAllDuan = new Regex(@"(?<=-----第)\d+(?=段)");
                            foreach (var sourceMatch in TempData.Instance.SourceMatches)
                            {
                                var get = regexAllDuan.Match(sourceMatch.ToString()).ToString();
                                if (get == "") continue;
                                var regexText_ = new Regex(@".+(?=\s-----第" + get + "段)");
                                var aritle_ = regexText_.Match(sourceMatch.ToString()).ToString().Trim();
                                if (TempData.Instance.DuanList.Keys.Contains(get)) continue;
                                TempData.Instance.DuanList.Add(get,
                                                               new List<string>()
                                                                   {
                                                                       GlobalModel.Instance.GetData.FindTitle.Match(
                                                                           sourceMatch.ToString()).ToString().Trim(),
                                                                       aritle_
                                                                   });
                            }
                        };
                    action.BeginInvoke(null, null);
                }
            }
        }
        #endregion
    }
}
