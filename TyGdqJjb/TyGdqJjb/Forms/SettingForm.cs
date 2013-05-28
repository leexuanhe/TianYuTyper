using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TyModel.Data;

namespace TyGdqJjb.Forms
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            var type = this.dgvSortList.GetType();
            var pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvSortList, true, null);
            
            //自已绘制
            this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //演示为绿底白字
                e.Graphics.FillRectangle(Brushes.Green, e.Node.Bounds);

                var nodeFont = e.Node.NodeFont ?? ((TreeView)sender).Font;
                var stringFormat = new StringFormat {Alignment = StringAlignment.Center};
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White,
                                      e.Bounds, stringFormat);
            }
            else
            {
                e.DrawDefault = true;
            }

            if ((e.State & TreeNodeStates.Focused) == 0) return;
            using (var focusPen = new Pen(Color.Black))
            {
                focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                var focusBounds = e.Node.Bounds;
                focusBounds.Size = new Size(focusBounds.Width - 1,
                                            focusBounds.Height - 1);
                e.Graphics.DrawRectangle(focusPen, focusBounds);
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            //优先级载入
            foreach (var typeType in TypeData.Instance.GetTypeAchievement().AchievementDic )
            {
                this.dgvSortList.Rows.Add(true, typeType.Key, typeType.Value.优先级, "↑");
                if (typeType.Key != "速度") continue;
                var row = this.dgvSortList.Rows[this.dgvSortList.Rows.Count - 1];
                row.Cells[0] = new DataGridViewTextBoxCell{Value = ""};
            }
            // 
            ShowSortList();
        }

        #region 发送顺序

        private void ShowSortList()
        {
            this.SendSortShow.Controls.Clear();
            foreach (var typeType in TypeData.Instance.GetTypeAchievement().AchievementDic)
            {
                this.SendSortShow.Controls.Add(GetLabel(typeType.Key));
            }

        }

        private Label GetLabel(string text)
        {
            var l = new Label
                {
                    AutoSize = false,
                    Size = new Size(50, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = text,
                    BackColor = Color.Teal,
                    ForeColor = Color.White,
                    Margin = new Padding(3, 3, 3, 3)
                };
            return l;
        }

        private void dgvSortList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var cbx = this.dgvSortList.Rows[e.RowIndex].Cells[0] as DataGridViewCheckBoxCell;
                if (cbx != null)
                {
                    cbx.Value = !(bool) cbx.Value;
                    this.dgvSortList.Rows[e.RowIndex].Cells[1].Style.ForeColor = (bool) cbx.Value
                                                                                     ? Color.Black
                                                                                     : Color.LightGray;
                }
            }
            if (e.RowIndex == 0) return;
            if (e.ColumnIndex == 3)
            {
                var pre = (int) this.dgvSortList.Rows[e.RowIndex - 1].Cells["优先级"].Value;
                var nex = (int) this.dgvSortList.Rows[e.RowIndex].Cells["优先级"].Value;
                var preKey = this.dgvSortList.Rows[e.RowIndex - 1];
            }
        }

        #endregion

        private void dgvSortList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

    }
}
