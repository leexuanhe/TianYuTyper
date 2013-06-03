using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TyGdqJjb.Forms;
using TyGdqJjb.TyData;
using TyModel.Data;
using TyModel.Model;

namespace TyGdqJjb.TyControls
{
    public partial class HeadPanel : UserControl
    {
        private readonly Font _font = new Font("微软雅黑", 10f);
        private string _duanHao = "无文段";
        public Rectangle _duanHaoRect;
        private string _title = "未设置";
        private Rectangle _titleRect;
        private string _articleTitle = "无标题";
        private int _count = 0;
        private double _progress = 0;
        private double Progress
        {
            set { _progress = value; Invalidate();}
            get { return _progress; }
        }

        public HeadPanel()
        {
            InitializeComponent();
            if (GroupOprationModel.Instance != null) GroupOprationModel.Instance.SetTitle += Instance_SetTitle;
            if (TypeData.Instance != null)
            {
                _count = TypeData.Instance.TypeText.Length;
                //进度条
                TypeData.Instance.ProgressChange += per => Progress = per;
            }
            if (TypeData.Instance != null)
                TypeData.Instance.GetTextInit += (sender, args) =>
                    {
                        var typeinfo = sender as TypeInfo;
                        DuanHao = "第" + typeinfo.Id + "段";
                        ArticleTitle = typeinfo.Title;
                        _count = typeinfo.Text.Length;
                    };
        }
        private string ArticleTitle
        {
            set { _articleTitle = value; Invalidate();}
            get { return _articleTitle; }
        }

        /// <summary>
        /// 段号
        /// </summary>
        private string DuanHao
        {
            set
            {
                _duanHao = value;
                Invalidate();
            }
            get { return _duanHao; }
        }

        /// <summary>
        /// 群标题
        /// </summary>
        public string Title
        {
            set
            {
                _title = value;
                Invalidate();
            }
            get { return _title; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (GlobalModel.Instance == null) return;
            //进度
            if (Progress != 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(GlobalModel.Instance.Theme.ProgressBack), 2,
                                         e.ClipRectangle.Height - 2, (int) ((e.ClipRectangle.Width - 2)*Progress),
                                         1);
            }
            var sf = new StringFormat { Alignment = StringAlignment.Center };

            SizeF title_size = e.Graphics.MeasureString(Title, _font);
            float title_y = Height / 2 - title_size.Height / 2 + 1;
            float title_x = Width - title_size.Width - 2;

            SizeF duanhao_size = e.Graphics.MeasureString(DuanHao, _font);
            int duanhao_x = 2;
            float duanhao_y = Height / 2 - duanhao_size.Height / 2 + 1;

            var count = "共" + _count + "字";
            SizeF count_size = e.Graphics.MeasureString(count, _font);
            var count_x = title_x - 2 - count_size.Width;
            var count_y = Height / 2 - count_size.Height / 2 + 1;

            //文章标题填充
            var articletitle_x = duanhao_x + duanhao_size.Width + 2;
            SizeF articletitle_size = e.Graphics.MeasureString(ArticleTitle, _font);
            var article_size = new SizeF(count_x - articletitle_x - 2, articletitle_size.Height);
            var articletitle_y = Height / 2 - articletitle_size.Height / 2 + 1;

            //标题设置
            _titleRect = new Rectangle((int)title_x, (int)title_y, (int)title_size.Width, (int)title_size.Height);
                e.Graphics.FillRectangle(new SolidBrush(GlobalModel.Instance.Theme.GroupBack), _titleRect);
            e.Graphics.DrawString(Title, _font, Brushes.White, title_x, title_y);
            //文章字数
            var _countRect = new Rectangle((int)count_x, (int)count_y, (int)count_size.Width, (int)count_size.Height);
                e.Graphics.FillRectangle(new SolidBrush(GlobalModel.Instance.Theme.CountBack), _countRect);
            e.Graphics.DrawString(count, _font, Brushes.White, count_x, count_y);

            //段号设置
            _duanHaoRect = new Rectangle(duanhao_x, (int)duanhao_y, (int)duanhao_size.Width, (int)duanhao_size.Height);
                e.Graphics.FillRectangle(new SolidBrush(GlobalModel.Instance.Theme.DuanHaoBack), _duanHaoRect);
            e.Graphics.DrawString(DuanHao, _font, Brushes.White, new RectangleF(duanhao_x, duanhao_y,duanhao_size.Width,duanhao_size.Height),sf);

            //文章标题
            var _articletitleRect = new Rectangle((int)articletitle_x, (int)articletitle_y, (int)article_size.Width, (int)article_size.Height);
                e.Graphics.FillRectangle(new SolidBrush(GlobalModel.Instance.Theme.TitleBack), _articletitleRect);
            e.Graphics.DrawString(ArticleTitle, _font, Brushes.White, new RectangleF(articletitle_x,articletitle_y,article_size.Width,article_size.Height),sf);
            //TextRenderer.DrawText(e.Graphics,ArticleTitle,_font,new Point((int)(articletitle_x + article_size.Width / 2 - articletitle_size.Width / 2), (int)articletitle_y),Color.White,Color.Transparent);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        //private ToolTip toolTip = new ToolTip();
        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    //移动到群标题时显示tips
        //    var l = e.Location;

        //    if (_titleRect.Contains(l))
        //    {
        //        if (!toolTip.Active)
        //            toolTip.Show("左键选择群，右键设置菜单", this, _titleRect.X, Height);
        //    }
        //}
        /// <summary>
        ///     鼠标点击
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            //点击群时 显示列表
            var l = e.Location;
            #region 群列表
            if (_titleRect.Contains(l))
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        GroupLeftClick();
                        break;
                    case MouseButtons.Right:
                        GroupRightClick();
                        break;
                }
            }
            #endregion
            else if (_duanHaoRect.Contains(l))
            {
                HrightMenu.Items.Clear();
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        {
                            ShowDuwnList();
                        }
                        break;
                    case MouseButtons.Right:
                        {
                            HrightMenu.Items.Clear();
                            HrightMenu.Items.Add("底色", null, SetDuanHaoBackColor);
                        }
                        break;
                }
                HrightMenu.Show(this, _duanHaoRect.X, Height);
            }
        }

        public void GroupRightClick()
        {
            HrightMenu.Items.Clear();
            this.HrightMenu.Font = new Font(this.HrightMenu.Font.FontFamily, 9f);
            if (GlobalModel.Instance.GroupData.Now != null)
            {
                HrightMenu.Items.Add("添加至黑名单", null, BlockGroup);
                HrightMenu.Items.Add("添加至白名单", null, WhiteGroup);
                HrightMenu.Items.Add("-");
            }
            var activeWhite = new ToolStripMenuItem
            {
                Text = "启用白名单",
                CheckState = GlobalModel.Instance.Config.IsUseWhiteList
                                 ? CheckState.Checked
                                 : CheckState.Unchecked
            };
            activeWhite.Click += ActiveWhiteList;
            HrightMenu.Items.Add(activeWhite);
            if (HrightMenu.Items.Count > 0)
                HrightMenu.Items.Add("-");
            HrightMenu.Items.Add("查看名单列表", null, ListBlockList);
            HrightMenu.Show(this, _titleRect.X, Height);
        }
       /// <summary>
       /// 群左键
       /// </summary>
       public void GroupLeftClick()
       {
           HrightMenu.Items.Clear();
           this.HrightMenu.Font = new Font(this.HrightMenu.Font.FontFamily, 9f);
           var getGroup = GroupOprationModel.Instance.UpdateGroup();
           if (getGroup == null) return;
           if (getGroup.Count == 0)
           {
               var temp = "未找到群";
               if (GlobalModel.Instance.Config.IsUseWhiteList)
               {
                   if (GroupOprationModel.Instance.UserWhiteCount != 0)
                   {
                       temp = string.Format("白名单屏蔽：{0}个\n点我取消白名单",
                                                 GroupOprationModel.Instance.UserWhiteCount);
                   }
                   HrightMenu.Items.Add(temp, null, delegate
                   {
                       GlobalModel.Instance.Config.IsUseWhiteList = false;
                       GroupOprationModel.Instance.RefreshGroup();
                   });
               }
               else
               {
                   if (GroupOprationModel.Instance.UserBlockCount != 0 ||
                       GroupOprationModel.Instance.SystemBlockCount != 0)
                   {
                       var system = GroupOprationModel.Instance.SystemBlockCount == 0
                                        ? ""
                                        : string.Format("系统屏蔽：{0}个\n",
                                                        GroupOprationModel.Instance.SystemBlockCount);
                       var user = GroupOprationModel.Instance.UserBlockCount == 0
                                      ? ""
                                      : string.Format("用户屏蔽：{0}个",
                                                      GroupOprationModel.Instance.UserBlockCount);
                       temp = string.Format(system + user);
                       HrightMenu.Items.Add(temp, null, ListBlockList);
                   }
               }

               HrightMenu.Show(this, _titleRect.X, Height);
           }
           else
           {
               foreach (var tool in getGroup.Select(@group => new ToolStripMenuItem { Text = @group.Name }))
               {
                   if (tool.Text == GlobalModel.Instance.GroupData.Now)
                       tool.CheckState = CheckState.Checked;
                   tool.Click += SetGroupTitle;
                   HrightMenu.Items.Add(tool);
               }
               //因白名单的原因而被屏蔽的群
               if (GroupOprationModel.Instance.UserWhiteCount > 0)
               {
                   HrightMenu.Items.Add("-");
                   HrightMenu.Items.Add("[&C]点我取消白名单", null, delegate
                   {
                       GlobalModel.Instance.Config.IsUseWhiteList = false;
                       GroupOprationModel.Instance.RefreshGroup();
                   });
                   HrightMenu.Items.Add("白名单屏蔽" + GroupOprationModel.Instance.UserWhiteCount + "个群");
                   if (GroupOprationModel.Instance.SystemBlockCount > 0)
                       HrightMenu.Items.Add("系统屏蔽" + GroupOprationModel.Instance.SystemBlockCount + "个");
               }
               HrightMenu.Show(this, _titleRect.X, Height);
           }
       }
        private void SetDuanHaoBackColor(object sender, EventArgs e)
        {
            //SetColor("段号","Back",);
        }

        private void SetColor(string target, string type, Color color)
        {
            switch (type)
            {
                case "Back":
                    switch (target)
                    {
                        case "段号":
                            GlobalModel.Instance.Theme.DuanHaoBack = color;
                            break;
                        case "标题":
                            GlobalModel.Instance.Theme.TitleBack = color;
                            break;
                        case "字数":
                            GlobalModel.Instance.Theme.CountBack = color;
                            break;
                        case "群":
                            GlobalModel.Instance.Theme.GroupBack = color;
                            break;
                    }
                    break;
                case "Fore":
                    break;
            }
            Invalidate();
        }
        /// <summary>
        /// 段号处点击左键显示
        /// </summary>
        public void ShowDuwnList()
        {
            if (TempData.Instance.DuanList == null) return;
            this.HrightMenu.Font = new Font(this.HrightMenu.Font.FontFamily,9f);
            var count = 0;//控制显示
            foreach (var tool in TempData.Instance.DuanList.Select(
                duan =>
                new ToolStripMenuItem
                    {
                        Tag = duan.Key,
                        Text = "段号：" + duan.Key + " 标题：" + duan.Value[0] + " 字数：" + duan.Value[1].Length
                    }).TakeWhile(tool => count <= 10))
            {
                if (TypeData.Instance.TypeInfo.Id == tool.Tag.ToString())
                {
                    tool.CheckState = CheckState.Checked;
                }
                tool.Click += SetDuan;
                HrightMenu.Items.Add(tool);
                count++;
            }
        }

        /// <summary>
        /// 从段号列表中设置段
        /// </summary>
        private void SetDuan(object sender, EventArgs e)
        {
            using (var tool = sender as ToolStripItem)
            {
                if (tool == null) return;
                TypeData.Instance.TypeInfo.Id = tool.Tag.ToString();
                TypeData.Instance.TypeInfo.Text = TempData.Instance.DuanList[tool.Tag.ToString()][1];
                TypeData.Instance.TypeInfo.Title = TempData.Instance.DuanList[tool.Tag.ToString()][0];
                TypeData.Instance.GetTextInitAll(TypeData.Instance.TypeInfo);
            }
        }

        /// <summary>
        /// 查看屏蔽列表
        /// </summary>
        private void ListBlockList(object sender, EventArgs e)
        {
            var blockListForm = new BlockListForm();
            blockListForm.ShowDialog(this);
        }

        /// <summary>
        /// 启用白名单
        /// </summary>
        private void ActiveWhiteList(object sender, EventArgs e)
        {
            GlobalModel.Instance.Config.IsUseWhiteList = !GlobalModel.Instance.Config.IsUseWhiteList;
            GroupOprationModel.Instance.RefreshGroup();
        }

        /// <summary>
        /// 添加到白名单
        /// </summary>
        private void WhiteGroup(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(string.Format("确定将群【{0}】添加至白名单？\n只有启用白名单才有效！", GlobalModel.Instance.GroupData.Now), "询",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (GlobalModel.Instance.Config.UserWhiteGroupList == null) GlobalModel.Instance.Config.UserWhiteGroupList = new List<string>();
                if (!GlobalModel.Instance.Config.UserWhiteGroupList.Exists(o => o == GlobalModel.Instance.GroupData.Now))
                {
                    GlobalModel.Instance.Config.UserWhiteGroupList.Add(GlobalModel.Instance.GroupData.Now);
                    GroupOprationModel.Instance.RefreshGroup();
                    GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.FormInfo);
                }
            }
            if (GlobalModel.Instance.Config.IsUseWhiteList) return;
            if (MessageBox.Show("当前未开启白名单功能，是否开启？", "是否开启白名单", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            GlobalModel.Instance.Config.IsUseWhiteList = true;
            GroupOprationModel.Instance.RefreshGroup();
            GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.FormInfo);
        }


        /// <summary>
        /// 添加至黑名单
        /// </summary>
        private void BlockGroup(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(string.Format("确定将群【{0}】添加至黑名单？\n黑白名单可以共存，启用白名单后，将只获取存在的白名单群！", GlobalModel.Instance.GroupData.Now), "询", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (GlobalModel.Instance.Config.UserBlockGroupList == null) GlobalModel.Instance.Config.UserBlockGroupList = new List<string>();
                if (!GlobalModel.Instance.Config.UserBlockGroupList.Exists(o=>o == GlobalModel.Instance.GroupData.Now))
                {
                    GlobalModel.Instance.Config.UserBlockGroupList.Add(GlobalModel.Instance.GroupData.Now);
                    GroupOprationModel.Instance.RefreshGroup();
                    GlobalModel.Instance.ConfigModel.ConfigSave(ConfigType.FormInfo);
                }
            }
        }

        private void SetGroupTitle(object sender, EventArgs e)
        {
            Title = sender.ToString();
            GlobalModel.Instance.GroupData.Now = sender.ToString();
        }

        /// <summary>
        ///     设置群标题
        /// </summary>
        /// <param name="title"></param>
        private void Instance_SetTitle(string title)
        {
            Title = title ?? "未设置";
        }

        //private GraphicsPath GetArc(Rectangle rectangle, int radius)
        //{
        //    var path = new GraphicsPath();
        //    var x = rectangle.X;
        //    var y = rectangle.Y;
        //    var a = radius;
        //    var w = rectangle.Width;
        //    var h = rectangle.Height;
        //    path.AddArc(x, y, a, a, 180, 90); //边框格式  
        //    path.AddArc(w - a, y, a, a, 270, 90);
        //    path.AddArc(w - a - 1, h - a - 1, a, a, 0, 90);
        //    path.AddArc(x, h - a, a, a, 90, 90);
        //    path.CloseAllFigures();
        //    return path;
        //}
    }
}