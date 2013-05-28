using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TyGdqJjb.TyControls
{
    [DefaultEvent("Click")]

    public class TyButton : UserControl
    {
        internal enum Style
        {
            Normal, //默认状态
            Moving, //鼠标移动到上面
            Down, //鼠标点击时
            Up, //鼠标UP
            Selected //选中
        }

        public delegate void ClickIt(object sender);

        public event ClickIt ClickIted;

        private void OnClickIted()
        {
            var handler = ClickIted;
            if (handler != null) handler(this);
        }

        private Style _buttonStyle = Style.Normal;

        [DisplayName(@"正常状态")]
        public Bitmap Normal { set; get; }

        [DisplayName(@"移动状态")]
        public Bitmap Moving { set; get; }

        [DisplayName(@"按下状态")]
        public Bitmap Down { set; get; }

        [DisplayName(@"不可用状态")]
        public Bitmap Unenable { set; get; }

        private string _btnText = "未设置";
        private bool _btnTextShow = false;

        public string BtnText
        {
            set { _btnText = value; }
            get { return _btnText; }
        }

        public bool BtnTextShow
        {
            set { _btnTextShow = value; }
            get { return _btnTextShow; }
        }

        public TyButton()
        {
            MouseEnter += (sender, args) =>
                {
                    _buttonStyle = Style.Moving;
                    Invalidate();
                };
            MouseDown += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                        _buttonStyle = Style.Down;
                    Invalidate();
                };
            MouseLeave += (sender, args) =>
                {
                    _buttonStyle = Style.Normal;
                    Invalidate();
                };
            MouseUp += (sender, args) =>
                {
                    _buttonStyle = Style.Up;
                    Invalidate();
                };
            MouseClick += (sender, args) =>
                {
                    if (args.Button == MouseButtons.Left)
                    {
                        OnClickIted();
                    }
                };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Normal == null || Moving == null || Down == null)
            {
                return;
            }
            Size = Normal.Size;
            //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            if (!Enabled)
            {
                //不可用状态
                if (Unenable != null)
                    e.Graphics.DrawImage(Unenable, 0, 0, Unenable.Width, Unenable.Height);
                return;
            }
            switch (_buttonStyle)
            {
                case Style.Up:
                case Style.Normal:
                    e.Graphics.DrawImage(Normal, 0, 0, Normal.Width, Normal.Height);
                    break;
                case Style.Moving:
                    e.Graphics.DrawImage(Moving, 0, 0, Moving.Width, Moving.Height);
                    break;
                case Style.Down:
                    e.Graphics.DrawImage(Down, 0, 0, Down.Width, Down.Height);
                    break;
                default:
                    e.Graphics.DrawImage(Normal, 0, 0, Normal.Width, Normal.Height);
                    break;
            }

            if (!BtnTextShow) return;
            var font = new Font("微软雅黑", 10f);
            var btntextSizef = e.Graphics.MeasureString(BtnText, font);
            var Y = (int) (Height/2 - btntextSizef.Height/2);
            if (_buttonStyle == Style.Down) Y += 1;

            e.Graphics.DrawString(BtnText, font, new SolidBrush(Enabled ? Color.FromArgb(99, 99, 99) : Color.Gray),
                                  Width/2 - btntextSizef.Width/2 - 1, Y);
        }

    }
}
