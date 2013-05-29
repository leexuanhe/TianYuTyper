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
            var type = this.dgvSendList.GetType();
            var pi = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(this.dgvSendList, true, null);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //发送列表的显示
            ShowSendList();
        }

        #region 发送
        private void ShowSendList()
        {
            foreach (var typeType in TypeData.Instance.GetTypeAchievement().AchievementDic)
            {
                //if (typeType.Value.显示)
                this.dgvSendList.Rows.Add(typeType.Key, typeType.Value.优先级,typeType.Value.显示, typeType.Value.描述词);
            }
        }

        private void dgvSendList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }
        #endregion

        
    }
}
