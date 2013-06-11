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
using TyModel.Model;

namespace TyGdqJjb.Forms
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            var type = this.dgvSendList.GetType();
            var pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvSendList, true, null);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //默认页初始化
            LoadDefault();
            //发送列表的显示
            LoadSendPage(0);
        }

        #region 发送
        /// <summary>
        /// 发送页载入
        /// </summary>
        private void LoadSendPage(int index)
        {
            this.dgvSendList.Rows.Clear();
            this.cbxSort.Items.Clear();
            if (TypeData.Instance.GetTypeAchievement().AchievementDic.Count <= 0) return;
            foreach (var typeType in TypeData.Instance.GetTypeAchievement().AchievementDic)
            {
                //if (typeType.Value.显示)
                this.dgvSendList.Rows.Add(typeType.Key, typeType.Value.TypeData.优先级, typeType.Value.TypeData.显示 ? "是" : "否",
                                          typeType.Value.TypeData.描述词);
                this.dgvSendList.Rows[this.dgvSendList.Rows.Count - 1].DefaultCellStyle.ForeColor =
                    typeType.Value.TypeData.显示
                        ? Color.Firebrick
                        : Color.LightGray;
                this.cbxSort.Items.Add(typeType.Value.TypeData.优先级); //优先级的载入
            }
            try
            {
                this.dgvSendList.CurrentCell = this.dgvSendList.Rows[index].Cells[0];
                this.cbxSort.SelectedIndex = index;
                LoadSetup(index);
            }
            catch
            {
                TyLogModel.Instance.WriteLog(LogType.Info, index + " - 发送列表设置错误");
            }
            if (this.cbxSort.Items.Count > 0)
                this.cbxSort.SelectedIndex = 0;
        }

        /// <summary>
        /// 点击显示项目
        /// </summary>
        private void dgvSendList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LoadSetup(e.RowIndex);
        }

        /// <summary>
        /// 载入设置
        /// </summary>
        /// <param name="index"></param>
        private void LoadSetup(int index)
        {
            this.tyPanelSendList.Title = "发送列表(" + TypeData.Instance.GetTypeAchievement().AchievementDic.Count + ")";
            var key = this.dgvSendList.Rows[index].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(key)) return;
            this.tbxProjectName.Text = key;
            var data = TypeData.Instance.GetTypeAchievement().AchievementDic[key];
            this.cbxSort.SelectedItem = data.TypeData.优先级;
            this.tbxDescText.Text = data.TypeData.描述词;
            this.tbxConn.Text = data.TypeData.连接值;
            this.cbxEmptyNotShow.Checked = data.TypeData.为空不显示;
            this.cbxShowDesc.Checked = data.TypeData.显示描述词;
            this.cbxSwitch.Checked = !data.TypeData.显示;
            this.lblInfo.Text = data.TypeInfo;
        }
        /// <summary>
        /// 保存此项
        /// </summary>
        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            var now = this.dgvSendList.SelectedRows[0];
            var key = this.tbxProjectName.Text;
            if (string.IsNullOrEmpty(key)) return;
            var data = TypeData.Instance.GetTypeAchievement().AchievementDic[key];
            //优先级判断
            var selectedItem = this.cbxSort.SelectedItem;
            if (selectedItem != null)
            {
                int getInputSort;
                int.TryParse(selectedItem.ToString(),out getInputSort);
                if (getInputSort > 0)
                {
                    if (getInputSort != data.TypeData.优先级)
                    {
                        TypeData.Instance.GetTypeAchievement()
                                .AchievementDic.First(o => o.Value.TypeData.优先级 == getInputSort)
                                .Value.TypeData.优先级 = data.TypeData.优先级;
                        data.TypeData.优先级 = getInputSort;
                    }
                }
                else
                {
                    TyLogModel.Instance.WriteLog(LogType.Info, selectedItem + " - 优先级设置错误！");
                }
                data.TypeData.为空不显示 = this.cbxEmptyNotShow.Checked;
                data.TypeData.显示描述词 = this.cbxShowDesc.Checked;
                data.TypeData.显示 = !this.cbxSwitch.Checked;
                TypeData.Instance.GetTypeAchievement().ReSort();
                LoadSendPage(now.Index);
                MessageBox.Show("保存成功!", GlobalModel.Instance.FormInfo.FormTitleAndVersion);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("重设后，所有发送格式数值归为默认，确认重设吗？", GlobalModel.Instance.FormInfo.FormTitleAndVersion,
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) ==
                DialogResult.OK)
            {
                TypeData.Instance.GetTypeAchievement().ReSet();
                LoadSendPage(0);
            }
        }

        private void dgvSendList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           // e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }
        #endregion

        #region 默认页
        /// <summary>
        ///     默认页初始化
        /// </summary>
        private void LoadDefault()
        {
            //个签
            this.tbxSign.Text = GlobalModel.Instance.Config.UserSignWrite;
            //连接
            this.tbxWith.Text = GlobalModel.Instance.Config.SplitString;
        }
        /// <summary>
        ///     保存默认页
        /// </summary>
        private void btnSaveDefault_Click(object sender, EventArgs e)
        {
            GlobalModel.Instance.Config.UserSignWrite = this.tbxSign.Text.Trim();
            GlobalModel.Instance.Config.SplitString = this.tbxWith.Text;
            MessageBox.Show("保存成功!", GlobalModel.Instance.FormInfo.FormTitleAndVersion);
        }

        /// <summary>
        ///     成绩连接自动显示
        /// </summary>
        private void tbxWith_TextChanged(object sender, EventArgs e)
        {
            const string with = "(速度+[连接]+击键+...)";
            this.lblWith.Text = with.Replace("连接", this.tbxWith.Text);
        }

        #endregion
    }
}
