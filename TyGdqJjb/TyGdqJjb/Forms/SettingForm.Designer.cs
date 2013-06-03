namespace TyGdqJjb.Forms
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDefault = new System.Windows.Forms.TabPage();
            this.tabPageSend = new System.Windows.Forms.TabPage();
            this.tabPageColor = new System.Windows.Forms.TabPage();
            this.lblUserSignWord = new System.Windows.Forms.Label();
            this.tbxSign = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveDefault = new System.Windows.Forms.Button();
            this.tyPanel2 = new TyGdqJjb.TyControls.TyPanel();
            this.btnSaveItem = new System.Windows.Forms.Button();
            this.cbxSwitch = new System.Windows.Forms.CheckBox();
            this.cbxShowDesc = new System.Windows.Forms.CheckBox();
            this.cbxEmptyNotShow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSort = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.tbxDescText = new System.Windows.Forms.TextBox();
            this.lblDescText = new System.Windows.Forms.Label();
            this.tbxProjectName = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tyPanel1 = new TyGdqJjb.TyControls.TyPanel();
            this.dgvSendList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain.SuspendLayout();
            this.tabPageDefault.SuspendLayout();
            this.tabPageSend.SuspendLayout();
            this.tyPanel2.SuspendLayout();
            this.tyPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendList)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageDefault);
            this.tabControlMain.Controls.Add(this.tabPageSend);
            this.tabControlMain.Controls.Add(this.tabPageColor);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(10, 30);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(455, 299);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageDefault
            // 
            this.tabPageDefault.AutoScroll = true;
            this.tabPageDefault.Controls.Add(this.btnSaveDefault);
            this.tabPageDefault.Controls.Add(this.label1);
            this.tabPageDefault.Controls.Add(this.tbxSign);
            this.tabPageDefault.Controls.Add(this.lblUserSignWord);
            this.tabPageDefault.Location = new System.Drawing.Point(4, 26);
            this.tabPageDefault.Name = "tabPageDefault";
            this.tabPageDefault.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDefault.Size = new System.Drawing.Size(447, 269);
            this.tabPageDefault.TabIndex = 0;
            this.tabPageDefault.Text = "常规";
            this.tabPageDefault.UseVisualStyleBackColor = true;
            // 
            // tabPageSend
            // 
            this.tabPageSend.Controls.Add(this.tyPanel2);
            this.tabPageSend.Controls.Add(this.tyPanel1);
            this.tabPageSend.Location = new System.Drawing.Point(4, 26);
            this.tabPageSend.Name = "tabPageSend";
            this.tabPageSend.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageSend.Size = new System.Drawing.Size(447, 269);
            this.tabPageSend.TabIndex = 1;
            this.tabPageSend.Text = "发送";
            this.tabPageSend.UseVisualStyleBackColor = true;
            // 
            // tabPageColor
            // 
            this.tabPageColor.Location = new System.Drawing.Point(4, 26);
            this.tabPageColor.Name = "tabPageColor";
            this.tabPageColor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColor.Size = new System.Drawing.Size(447, 269);
            this.tabPageColor.TabIndex = 2;
            this.tabPageColor.Text = "颜色";
            this.tabPageColor.UseVisualStyleBackColor = true;
            // 
            // lblUserSignWord
            // 
            this.lblUserSignWord.AutoSize = true;
            this.lblUserSignWord.Location = new System.Drawing.Point(12, 14);
            this.lblUserSignWord.Name = "lblUserSignWord";
            this.lblUserSignWord.Size = new System.Drawing.Size(68, 17);
            this.lblUserSignWord.TabIndex = 0;
            this.lblUserSignWord.Text = "个性签名：";
            // 
            // tbxSign
            // 
            this.tbxSign.Location = new System.Drawing.Point(81, 10);
            this.tbxSign.Name = "tbxSign";
            this.tbxSign.Size = new System.Drawing.Size(188, 23);
            this.tbxSign.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(275, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "(为空不显示)";
            // 
            // btnSaveDefault
            // 
            this.btnSaveDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDefault.Location = new System.Drawing.Point(352, 9);
            this.btnSaveDefault.Name = "btnSaveDefault";
            this.btnSaveDefault.Size = new System.Drawing.Size(90, 23);
            this.btnSaveDefault.TabIndex = 1;
            this.btnSaveDefault.Text = "保存此页";
            this.btnSaveDefault.UseVisualStyleBackColor = true;
            this.btnSaveDefault.Click += new System.EventHandler(this.btnSaveDefault_Click);
            // 
            // tyPanel2
            // 
            this.tyPanel2.Controls.Add(this.btnSaveItem);
            this.tyPanel2.Controls.Add(this.cbxSwitch);
            this.tyPanel2.Controls.Add(this.cbxShowDesc);
            this.tyPanel2.Controls.Add(this.cbxEmptyNotShow);
            this.tyPanel2.Controls.Add(this.label4);
            this.tyPanel2.Controls.Add(this.label3);
            this.tyPanel2.Controls.Add(this.cbxSort);
            this.tyPanel2.Controls.Add(this.lblSort);
            this.tyPanel2.Controls.Add(this.tbxDescText);
            this.tyPanel2.Controls.Add(this.lblDescText);
            this.tyPanel2.Controls.Add(this.tbxProjectName);
            this.tyPanel2.Controls.Add(this.lblProjectName);
            this.tyPanel2.Controls.Add(this.label2);
            this.tyPanel2.Location = new System.Drawing.Point(244, 6);
            this.tyPanel2.Name = "tyPanel2";
            this.tyPanel2.Padding = new System.Windows.Forms.Padding(1, 25, 1, 1);
            this.tyPanel2.Size = new System.Drawing.Size(200, 257);
            this.tyPanel2.TabIndex = 1;
            this.tyPanel2.Title = "设置发送";
            // 
            // btnSaveItem
            // 
            this.btnSaveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveItem.Location = new System.Drawing.Point(52, 221);
            this.btnSaveItem.Name = "btnSaveItem";
            this.btnSaveItem.Size = new System.Drawing.Size(90, 23);
            this.btnSaveItem.TabIndex = 10;
            this.btnSaveItem.Text = "保存此项";
            this.btnSaveItem.UseVisualStyleBackColor = true;
            this.btnSaveItem.Click += new System.EventHandler(this.btnSaveItem_Click);
            // 
            // cbxSwitch
            // 
            this.cbxSwitch.AutoSize = true;
            this.cbxSwitch.Location = new System.Drawing.Point(45, 187);
            this.cbxSwitch.Name = "cbxSwitch";
            this.cbxSwitch.Size = new System.Drawing.Size(99, 21);
            this.cbxSwitch.TabIndex = 9;
            this.cbxSwitch.Text = "关闭此项显示";
            this.cbxSwitch.UseVisualStyleBackColor = true;
            // 
            // cbxShowDesc
            // 
            this.cbxShowDesc.AutoSize = true;
            this.cbxShowDesc.Location = new System.Drawing.Point(45, 160);
            this.cbxShowDesc.Name = "cbxShowDesc";
            this.cbxShowDesc.Size = new System.Drawing.Size(87, 21);
            this.cbxShowDesc.TabIndex = 9;
            this.cbxShowDesc.Text = "显示描述词";
            this.cbxShowDesc.UseVisualStyleBackColor = true;
            // 
            // cbxEmptyNotShow
            // 
            this.cbxEmptyNotShow.AutoSize = true;
            this.cbxEmptyNotShow.Location = new System.Drawing.Point(45, 133);
            this.cbxEmptyNotShow.Name = "cbxEmptyNotShow";
            this.cbxEmptyNotShow.Size = new System.Drawing.Size(147, 21);
            this.cbxEmptyNotShow.TabIndex = 9;
            this.cbxEmptyNotShow.Text = "数值为零或空时不显示";
            this.cbxEmptyNotShow.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(135, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "(发送顺序)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(135, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "(不可修改)";
            // 
            // cbxSort
            // 
            this.cbxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSort.FormattingEnabled = true;
            this.cbxSort.Location = new System.Drawing.Point(57, 89);
            this.cbxSort.Name = "cbxSort";
            this.cbxSort.Size = new System.Drawing.Size(78, 25);
            this.cbxSort.TabIndex = 5;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(1, 93);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(56, 17);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "优先级：";
            // 
            // tbxDescText
            // 
            this.tbxDescText.Location = new System.Drawing.Point(57, 60);
            this.tbxDescText.Name = "tbxDescText";
            this.tbxDescText.ReadOnly = true;
            this.tbxDescText.Size = new System.Drawing.Size(78, 23);
            this.tbxDescText.TabIndex = 3;
            // 
            // lblDescText
            // 
            this.lblDescText.AutoSize = true;
            this.lblDescText.Location = new System.Drawing.Point(1, 63);
            this.lblDescText.Name = "lblDescText";
            this.lblDescText.Size = new System.Drawing.Size(56, 17);
            this.lblDescText.TabIndex = 2;
            this.lblDescText.Text = "描述词：";
            // 
            // tbxProjectName
            // 
            this.tbxProjectName.Location = new System.Drawing.Point(57, 31);
            this.tbxProjectName.Name = "tbxProjectName";
            this.tbxProjectName.ReadOnly = true;
            this.tbxProjectName.Size = new System.Drawing.Size(78, 23);
            this.tbxProjectName.TabIndex = 1;
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(13, 34);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(44, 17);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(135, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "(不可修改)";
            // 
            // tyPanel1
            // 
            this.tyPanel1.Controls.Add(this.dgvSendList);
            this.tyPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tyPanel1.Location = new System.Drawing.Point(6, 6);
            this.tyPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tyPanel1.Name = "tyPanel1";
            this.tyPanel1.Padding = new System.Windows.Forms.Padding(1, 25, 1, 1);
            this.tyPanel1.Size = new System.Drawing.Size(234, 257);
            this.tyPanel1.TabIndex = 0;
            this.tyPanel1.Title = "发送列表";
            // 
            // dgvSendList
            // 
            this.dgvSendList.AllowUserToAddRows = false;
            this.dgvSendList.AllowUserToDeleteRows = false;
            this.dgvSendList.AllowUserToResizeColumns = false;
            this.dgvSendList.AllowUserToResizeRows = false;
            this.dgvSendList.BackgroundColor = System.Drawing.Color.White;
            this.dgvSendList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSendList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSendList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSendList.ColumnHeadersHeight = 24;
            this.dgvSendList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSendList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvSendList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSendList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSendList.EnableHeadersVisualStyles = false;
            this.dgvSendList.GridColor = System.Drawing.Color.White;
            this.dgvSendList.Location = new System.Drawing.Point(1, 25);
            this.dgvSendList.MultiSelect = false;
            this.dgvSendList.Name = "dgvSendList";
            this.dgvSendList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSendList.RowHeadersVisible = false;
            this.dgvSendList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvSendList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSendList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSendList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSendList.RowTemplate.Height = 24;
            this.dgvSendList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSendList.Size = new System.Drawing.Size(232, 231);
            this.dgvSendList.TabIndex = 1;
            this.dgvSendList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSendList_RowEnter);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "项目";
            this.Column1.Name = "Column1";
            this.Column1.Width = 55;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "优先级";
            this.Column2.Name = "Column2";
            this.Column2.Width = 67;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "可见";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 36;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "描述词";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column4.Width = 48;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(475, 339);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Padding = new System.Windows.Forms.Padding(10, 30, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDefault.ResumeLayout(false);
            this.tabPageDefault.PerformLayout();
            this.tabPageSend.ResumeLayout(false);
            this.tyPanel2.ResumeLayout(false);
            this.tyPanel2.PerformLayout();
            this.tyPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDefault;
        private System.Windows.Forms.TabPage tabPageSend;
        private System.Windows.Forms.TabPage tabPageColor;
        private TyControls.TyPanel tyPanel1;
        private System.Windows.Forms.DataGridView dgvSendList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxSign;
        private System.Windows.Forms.Label lblUserSignWord;
        private System.Windows.Forms.Button btnSaveDefault;
        private TyControls.TyPanel tyPanel2;
        private System.Windows.Forms.CheckBox cbxShowDesc;
        private System.Windows.Forms.CheckBox cbxEmptyNotShow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSort;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.TextBox tbxDescText;
        private System.Windows.Forms.Label lblDescText;
        private System.Windows.Forms.TextBox tbxProjectName;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxSwitch;
        private System.Windows.Forms.Button btnSaveItem;

    }
}