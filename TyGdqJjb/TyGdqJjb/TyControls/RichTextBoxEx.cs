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
    public sealed class RichTextBoxEx : RichTextBox
    {
        private DgetSourceModel DgetSourceModel { set; get; }

        public void SetDgetSourceModel(DgetSourceModel dgetSourceModel)
        {
            this.DgetSourceModel = dgetSourceModel;
            this.DgetSourceModel.TypeEnd += DgetSourceModel_TypeEnd;
        }

        /// <summary>
        /// 跟打完成 对 对照区的操作
        /// </summary>
        void DgetSourceModel_TypeEnd(TyInfo tyInfo, DateTime dateTime)
        {
            //显示回改地点
            if (TempData.Instance.BackReport.Count != 0)
            {
                foreach (var i in TempData.Instance.BackReport)
                {
                    this.SelectionStart = i.Key;
                    this.SelectionLength = 1;
                    this.SelectionBackColor = Color.LightGreen;
                }
            }
            //最高停留
            if (TempData.Instance.TypeReport.Count != 0)
            {
                var max = TempData.Instance.TypeReport.Max(o => o.UseTime.TotalSeconds);
                var find = TempData.Instance.TypeReport.Find(o => o.UseTime.TotalSeconds == max);
                this.SelectionStart = find.Start;
                this.SelectionLength = find.Word.Length;
                this.SelectionColor = Color.Tomato;
                TypeData.Instance.GetTypeAchievement().AchievementDic["停留"].关连值 = string.Format("[{0}]{1}s", find.Word,find.UseTime.TotalSeconds.ToString("0.00"));
                TypeData.Instance.GetTypeAchievement().AchievementDic["打词"].关连值 = TempData.Instance.TypeReport.Count(o => o.Word.Length >= 2);
            }
        }

        public RichTextBoxEx()
        {
            //强制设置
            //默认只读模式
            ReadOnly = true;
            //一直显示上下滚动条
            ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            //TAB禁止
            TabStop = false;
            //无边框
            BorderStyle = BorderStyle.None;
            SetTheme();
            FontChanged += (sender, args) => TempData.Instance.WordHeight = (int)Font.GetHeight() + 1;
        }

        public void SetInit(TypeData typeData)
        {
            typeData.Init += (sender, args) => SetTheme();
            typeData.GetTextInit += (sender, args) =>
                {
                    var typeinfo = sender as TypeInfo;
                    Text = typeinfo.Text;
                };
        }
        private void SetTheme()
        {
            //主题设置
            if (GlobalModel.Instance == null) return;
            Font = GlobalModel.Instance.Theme.DFont;
            BackColor = GlobalModel.Instance.Theme.DBgColor;
            SelectAll();
            SelectionBackColor = BackColor;
            this.SelectionStart = 0;
            this.ScrollToCaret();
        }
    }
}
