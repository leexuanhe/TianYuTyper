using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TyModel.Model;

namespace TyGdqJjb.Forms
{
    public partial class BlockListForm : Form
    {
        public BlockListForm()
        {
            InitializeComponent();
            var dgvType = this.dgvBlockList.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvBlockList, true, null);
        }
        private readonly Rectangle _infoRect = new Rectangle(10,2,200,20);
        private readonly Font _font = new Font("微软雅黑",10f);
        private int _systemDimCount = 0;
        private int _userDimCount = 0;

        private int SystemDimCount
        {
            set { _systemDimCount = value; Invalidate(_infoRect);}
            get { return _systemDimCount; }
        }

        private int UserDimCount
        {
            set { _userDimCount = value; Invalidate(_infoRect); }
            get { return _userDimCount; }
        }

        private void BlockListForm_Load(object sender, EventArgs e)
        {
            if (GlobalModel.Instance.Config.UserBlockGroupList != null)
            {
                foreach (var block in GlobalModel.Instance.Config.UserBlockGroupList)
                {
                    this.dgvBlockList.Rows.Add("用户定义", block, "取消屏蔽");
                }
                UserDimCount = GlobalModel.Instance.Config.UserBlockGroupList.Count;
            }
            foreach (var block in GroupOprationModel.Instance.BlockGroupList)
            {
                this.dgvBlockList.Rows.Add("系统定义", block);
                var row = this.dgvBlockList.Rows[this.dgvBlockList.Rows.Count - 1];
                row.Cells[2] = new DataGridViewTextBoxCell();
                row.DefaultCellStyle.ForeColor = Color.DarkGray;
            }
            SystemDimCount = GroupOprationModel.Instance.BlockGroupList.Count;
        }

        private void dgvBlockList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

        private void dgvBlockList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                var btnText = this.dgvBlockList.Rows[e.RowIndex].Cells[2];
                var font = this.dgvBlockList.Rows[e.RowIndex].DefaultCellStyle.Font;
                switch ((string)btnText.Value)
                {
                    case "取消屏蔽":
                        GlobalModel.Instance.Config.UserBlockGroupList.Remove(this.dgvBlockList.Rows[e.RowIndex].Cells[1].Value.ToString());
                        this.dgvBlockList.Rows[e.RowIndex].Cells[1].Style.Font = new Font(font.FontFamily, font.Size,FontStyle.Strikeout);
                        this.dgvBlockList.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.DarkGray;
                        btnText.Value = "再次屏蔽";
                        break;
                    case "再次屏蔽":
                        GlobalModel.Instance.Config.UserBlockGroupList.Add(
                            this.dgvBlockList.Rows[e.RowIndex].Cells[1].Value.ToString());
                        this.dgvBlockList.Rows[e.RowIndex].Cells[1].Style.Font = font;
                        this.dgvBlockList.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Black;
                        btnText.Value = "取消屏蔽";
                        break;
                }
                UserDimCount = GlobalModel.Instance.Config.UserBlockGroupList.Count;
            }
        }

        private void BlockListForm_Paint(object sender, PaintEventArgs e)
        {
            var system = "系统定义：" + SystemDimCount + "个";
            var user = "用户定义：" + UserDimCount + "个";
            var systemSize = e.Graphics.MeasureString(system, _font);
            var userSize = e.Graphics.MeasureString(user, _font);
            e.Graphics.FillRectangle(Brushes.LightSeaGreen, _infoRect.X,_infoRect.Y,systemSize.Width,systemSize.Height);
            e.Graphics.DrawString(system,_font,Brushes.White,_infoRect.X,_infoRect.Y);

            e.Graphics.FillRectangle(Brushes.Maroon, _infoRect.X + systemSize.Width + 2, _infoRect.Y, userSize.Width + 2, userSize.Height);
            e.Graphics.DrawString(user, _font, Brushes.White, _infoRect.X + systemSize.Width + 2, _infoRect.Y);
        }
    }
}
