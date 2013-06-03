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
            LoadSendPage();
        }

        #region 发送
        /// <summary>
        /// 发送页载入
        /// </summary>
        private void LoadSendPage()
        {
            this.dgvSendList.Rows.Clear();
            foreach (var typeType in TypeData.Instance.GetTypeAchievement().AchievementDic)
            {
                //if (typeType.Value.显示)
                this.dgvSendList.Rows.Add(typeType.Key, typeType.Value.优先级,typeType.Value.显示, typeType.Value.描述词);
                this.cbxSort.Items.Add(typeType.Value.优先级);//优先级的载入
            }
        }

        /// <summary>
        /// 点击显示项目
        /// </summary>
        private void dgvSendList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var key = this.dgvSendList.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (string.IsNullOrEmpty(key)) return;
            this.tbxProjectName.Text = key;
            var data = TypeData.Instance.GetTypeAchievement().AchievementDic[key];
            this.cbxSort.SelectedItem = data.优先级;
            this.tbxDescText.Text = data.描述词;
            this.cbxEmptyNotShow.Checked = data.为空不显示;
            this.cbxShowDesc.Checked = data.显示描述词;
            this.cbxSwitch.Checked = !data.显示;
        }

        /// <summary>
        /// 保存此项
        /// </summary>
        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            var key = this.tbxProjectName.Text;
            if (string.IsNullOrEmpty(key)) return;
            var data = TypeData.Instance.GetTypeAchievement().AchievementDic[key];
            //优先级判断
            int getInputSort;
            int.TryParse(this.cbxSort.SelectedItem.ToString(),out getInputSort);
            if (getInputSort > 0)
            {
                if (getInputSort != data.优先级)
                {
                    TypeData.Instance.GetTypeAchievement()
                            .AchievementDic.First(o => o.Value.优先级 == getInputSort)
                            .Value.优先级 = data.优先级;
                    data.优先级 = getInputSort;
                }
            }
            else
            {
                TyLogModel.Instance.WriteLog(LogType.Info, this.cbxSort.SelectedItem + " - 优先级设置错误！");
            }
            data.为空不显示 = this.cbxEmptyNotShow.Checked;
            data.显示描述词 = this.cbxShowDesc.Checked;
            data.显示 = !this.cbxSwitch.Checked;
            TypeData.Instance.GetTypeAchievement().ReSort();
            LoadSendPage();
            MessageBox.Show("保存成功!", GlobalModel.Instance.FormInfo.FormTitleAndVersion);
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
        }
        /// <summary>
        ///     保存默认页
        /// </summary>
        private void btnSaveDefault_Click(object sender, EventArgs e)
        {
            GlobalModel.Instance.Config.UserSignWrite = this.tbxSign.Text.Trim();
            MessageBox.Show("保存成功!", GlobalModel.Instance.FormInfo.FormTitleAndVersion);
        }

        #endregion
    }
}
