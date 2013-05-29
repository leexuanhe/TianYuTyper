using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TyGdqJjb.TyControls
{
    public class TyPanel:Panel
    {
        private readonly Font _font = new Font("微软雅黑",10f,FontStyle.Bold);
        private readonly LinearGradientBrush _linear = new LinearGradientBrush(new Point(0, 0), new Point(0, 24),
                                                                     Color.FromArgb(254, 254, 254),
                                                                     Color.FromArgb(213, 213, 213));

        private string _title = "未命名";

        public string Title
        {
            set { _title = value; Invalidate(new Rectangle(0,0,Width,24));}
            get { return _title; }
        }

        public TyPanel()
        {
            this.Padding = new Padding(1,25,1,1);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(_linear, new Rectangle(0, 0, Width, 24));
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(200, 200, 200)), 0, 0, Width - 1, Height - 1);
            e.Graphics.DrawLine(new Pen(Color.FromArgb(200, 200, 200)), 0, 24, Width, 24);
            var titleSize = e.Graphics.MeasureString(Title, _font);
            var sb = new SolidBrush(Color.FromArgb(90, 90, 90));
            if (Title.Length > 0)
            {
                e.Graphics.DrawString(Title, _font, sb, 6, 12 - titleSize.Height/2);
            }
        }
    }
}
