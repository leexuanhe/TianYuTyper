using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TyGdqJjb.Forms;
using TyGdqJjb.Properties;
using TyGdqJjb.TyData;
using TyGdqJjb.TyModels;
using TyModel.Data;
using TyModel.Model;

namespace TyGdqJjb
{
    public partial class MainForm : Form
    {
        private DgetSourceModel DgetSourceModel { set; get; }
        public DQQOperation DgetTextFromQQ { set; get; }
        private InputOperationModel InputOperationModel { set; get; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Init();
            //数据获取前后操作
            DgetSourceModel = new DgetSourceModel(this.richTextBoxEx1,this);
            DgetTextFromQQ = new DQQOperation(this);
            textBoxEx1.SetDgetSourceModel(DgetSourceModel);
            richTextBoxEx1.SetInit(TypeData.Instance);
            richTextBoxEx1.SetDgetSourceModel(DgetSourceModel);
            TypeData.Instance.Init += (o, args) => this.Activate();
            DgetSourceModel.TypeEnd += DgetSourceModel_TypeEnd;
            DgetSourceModel.TypeStart += DgetSourceModel_TypeStart;
            //获取群
            GroupOprationModel.Instance.RefreshGroup();
            //启动输入法
            this.InputOperationModel = new InputOperationModel(this.textBoxEx1.Handle);
            //this.InputOperationModel.InputLan(TypeData.Instance.GetTypeAchievement().AchievementDic["输入法"].TypeData.关连值.ToString());
        }

        private void Init()
        {
            timer.Tick += timer_Tick;
            splitContainerMain.SplitterDistance = GlobalModel.Instance.Config.SplitDistance;
            richTextBoxEx1.Text = TypeData.Instance.TypeText;
            richTextBoxEx1.BackColorChanged +=
                (sender, args) => 背景色ToolStripMenuItem.Image = TempData.Instance.GetColor(this.richTextBoxEx1.BackColor);
            richTextBoxEx1.BackColor = GlobalModel.Instance.Theme.DBgColor;
            this.textBoxEx1.BackColorChanged += (sender, args) => 背景色ToolStripMenuItem1.Image = TempData.Instance.GetColor(this.textBoxEx1.BackColor);
            字体ToolStripMenuItem1.Font = GlobalModel.Instance.Theme.DFont;
            字体ToolStripMenuItem.Font = GlobalModel.Instance.Theme.GFont;
            打对色ToolStripMenuItem.Image = TempData.Instance.GetColor(GlobalModel.Instance.Theme.Right);
            打错色ToolStripMenuItem.Image = TempData.Instance.GetColor(GlobalModel.Instance.Theme.Wrong);
            最高停留色ToolStripMenuItem.Image = TempData.Instance.GetColor(GlobalModel.Instance.Theme.MaxStay);
            回改色ToolStripMenuItem.Image = TempData.Instance.GetColor(GlobalModel.Instance.Theme.BackSpaceColor);
        }

        /// <summary>
        /// 跟打开始
        /// </summary>
        void DgetSourceModel_TypeStart(TyInfo tyInfo, DateTime dateTime)
        {
            timer.Enabled = true;
        }

        /// <summary>
        /// 时间更新
        /// </summary>
        void timer_Tick(object sender, EventArgs e)
        {
            this.lblTime.Text = ((int)(DateTime.Now - TypeData.Instance.StartTime).TotalSeconds).ToString("D4");
        }

        /// <summary>
        /// 跟打完成
        /// </summary>
        void DgetSourceModel_TypeEnd(TyInfo tyInfo, DateTime dateTime)
        {
            TypeData.Instance.EndTime = dateTime;
            TypeData.Instance.TypeState = tyInfo.TypeState;
            timer.Enabled = false;
            //错字超出总字数百分之十此不发送
            if (TypeData.Instance.ErrorWords.Count > TypeData.Instance.TypeText.Length * 0.1) return;
            var use = TypeData.Instance.TotalUseTime.TotalSeconds;
            var realLen = TypeData.Instance.TypeText.Length - TypeData.Instance.ErrorWords.Count*5;
            if (realLen > 0)
            {
                TypeData.Instance.GetTypeAchievement().Speed2 = TypeData.Instance.TypeText.Length * 60.0 / use;
                try
                {
                    TypeData.Instance.GetTypeAchievement().AchievementDic["速度"].TypeData.关连值 = realLen*60.0/use;
                    if (TempData.Instance.TypeReport.Count >= 5)
                    {
                        var useTime = TempData.Instance.TypeReport.Take(5).Sum(o => o.UseTime.TotalSeconds);
                        var ziCount = TempData.Instance.TypeReport.Take(5).Sum(o => o.Word.Length);
                        var jsCount = TempData.Instance.TypeReport.Take(5).Sum(o => o.Kicks);
                        TypeData.Instance.GetTypeAchievement().AchievementDic["起步"].TypeData.关连值 =
                            (ziCount*60.0/useTime).ToString("0.00") + "/" +
                            (jsCount * 1.0/useTime).ToString("0.00") + "/" +
                            (jsCount * 1.0/ziCount).ToString("0.00");
                    }
                    else
                    {
                        TypeData.Instance.GetTypeAchievement().AchievementDic["起步"].TypeData.关连值 = "";
                    }
                    TypeData.Instance.GetTypeAchievement().AchievementDic["击键"].TypeData.关连值 = TypeData.Instance.KickTimes*1.0/
                                                                                      use;
                    TypeData.Instance.GetTypeAchievement().AchievementDic["码长"].TypeData.关连值 = TypeData.Instance.KickTimes*1.0/
                                                                                      TypeData.Instance.TypeText.Length;
                    TypeData.Instance.GetTypeAchievement().AchievementDic["回改"].TypeData.关连值 = TypeData.Instance.BackTimes;
                    TypeData.Instance.GetTypeAchievement().AchievementDic["错字"].TypeData.关连值 = TypeData.Instance.ErrorWords.Count;
                    TypeData.Instance.GetTypeAchievement().AchievementDic["键数"].TypeData.关连值 = TypeData.Instance.KickTimes;
                    TypeData.Instance.GetTypeAchievement().AchievementDic["输入法"].TypeData.关连值 =
                        InputLanguage.CurrentInputLanguage.LayoutName;
                    TypeData.Instance.GetTypeAchievement().InputOperation(); //对输入法进行处理输出
                    if (TempData.Instance.BackReport.Count > 0)
                    {
                        var max = TempData.Instance.BackReport.Values.Max();
                        if (max > 1)
                        {
                            var backTimes =
                                TempData.Instance.BackReport.First(o => o.Value == max);
                            TypeData.Instance.GetTypeAchievement().AchievementDic["回次"].TypeData.关连值 = "[" +TypeData.Instance.TypeText[backTimes.Key] +
                                                                                              "]" +backTimes.Value + "次";
                        }
                    }
                    if (TypeData.Instance.TypeState == TypeState.TypeOver)
                    {
                        this.DgetTextFromQQ.SendToQQ(TypeData.Instance.GetTypeAchievement().ToString());
                        this.Activate();
                        this.textBoxEx1.SelectionStart = this.textBoxEx1.TextLength;
                    }
                }
                catch (Exception err)
                {
                    TyLogModel.Instance.WriteLog(LogType.Error, err.Message);
                    MessageBox.Show(Resources.MainForm_DgetSourceModel_TypeEnd_TypeAchievementDic_Error);
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalModel.Instance.Config.SplitDistance = this.splitContainerMain.SplitterDistance;
            if (WindowState != FormWindowState.Maximized && WindowState != FormWindowState.Minimized)
            {
                var v = Screen.GetBounds(this);
                var v2 = v.Contains(new Point(Location.X + Width/2, Location.Y + Height/2));
                if (v2)
                    GlobalModel.Instance.Config.Location = Location;
                GlobalModel.Instance.Config.Size = Size;
            }
            GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.FormInfo);
        }

        #region 跟打区右键菜单

        private void 重打ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
            this.lblTime.Text = "0000";
            TypeData.Instance.InitAll();
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog {Font = GlobalModel.Instance.Theme.GFont})
            {
                if (fontDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.GFont = fontDialog.Font;
                this.textBoxEx1.Font = fontDialog.Font;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
            }
        }

        private void 背景色ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog { Color = GlobalModel.Instance.Theme.GBgColor, FullOpen = true })
            {
                if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.GBgColor = colorDialog.Color;
                this.textBoxEx1.BackColor = colorDialog.Color;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
            }
        }

        private void 打对色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog { Color = GlobalModel.Instance.Theme.Right, FullOpen = true })
            {
                if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.Right = colorDialog.Color;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
                打对色ToolStripMenuItem.Image = TempData.Instance.GetColor(colorDialog.Color);
            }
        }

        private void 打错色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog { Color = GlobalModel.Instance.Theme.Wrong, FullOpen = true })
            {
                if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.Wrong = colorDialog.Color;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
                打错色ToolStripMenuItem.Image = TempData.Instance.GetColor(colorDialog.Color);
            }
        }
        #endregion

        #region 对照区右键菜单 
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.richTextBoxEx1.Text.Substring(this.richTextBoxEx1.SelectionStart,
                                                                     this.richTextBoxEx1.SelectionLength));
            }
            catch (Exception ex)
            {
                TyLogModel.Instance.WriteLog(LogType.ClipboardError, ex.Message);
            }
        }

        private void 最高停留色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog { Color = GlobalModel.Instance.Theme.MaxStay, FullOpen = true })
            {
                if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.MaxStay = colorDialog.Color;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
                最高停留色ToolStripMenuItem.Image = TempData.Instance.GetColor(colorDialog.Color);
            }
        }

        private void 回改色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog { Color = GlobalModel.Instance.Theme.BackSpaceColor, FullOpen = true })
            {
                if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.BackSpaceColor = colorDialog.Color;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
                回改色ToolStripMenuItem.Image = TempData.Instance.GetColor(colorDialog.Color);
            }
        }

        private void 字体ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var fontDialog = new FontDialog { Font = GlobalModel.Instance.Theme.DFont })
            {
                if (fontDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.DFont = fontDialog.Font;
                this.richTextBoxEx1.Font = fontDialog.Font;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
            }
        }

        private void 背景色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog {Color = GlobalModel.Instance.Theme.DBgColor,FullOpen = true})
            {
                if (colorDialog.ShowDialog(this) != DialogResult.OK) return;
                GlobalModel.Instance.Theme.DBgColor = colorDialog.Color;
                this.richTextBoxEx1.BackColor = colorDialog.Color;
                GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.Theme);
            }
        }

        private void 载文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxEx1.TypeFlag == 0)
            {
                this.DgetTextFromQQ.GetTextFromQQ();
                this.InputOperationModel.InputLan();
            }
            else
            {
                重打ToolStripMenuItem_Click(this,null);
            }
        }

        #endregion

        #region 快捷键定义

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    重打ToolStripMenuItem_Click(this, null);
                    break;
                case Keys.F4:
                    载文ToolStripMenuItem_Click(this, null);
                    break;
                case Keys.F5:
                    GroupOprationModel.Instance.RefreshGroup();
                    if (string.IsNullOrEmpty(GlobalModel.Instance.GroupData.Now))
                    {
                        headPanel1.GroupLeftClick();
                    }
                    break;
            }
        }

        #endregion

        #region 设置
        private void btnSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var settingForm = new SettingForm();
            settingForm.ShowDialog(this);
        }
        #endregion
    }
}
