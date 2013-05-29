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
            this.tyPanel1 = new TyGdqJjb.TyControls.TyPanel();
            this.dgvSendList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain.SuspendLayout();
            this.tabPageSend.SuspendLayout();
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
            // tyPanel1
            // 
            this.tyPanel1.Controls.Add(this.dgvSendList);
            this.tyPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tyPanel1.Location = new System.Drawing.Point(6, 6);
            this.tyPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tyPanel1.Name = "tyPanel1";
            this.tyPanel1.Padding = new System.Windows.Forms.Padding(1, 25, 1, 1);
            this.tyPanel1.Size = new System.Drawing.Size(280, 257);
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
            this.dgvSendList.Size = new System.Drawing.Size(278, 231);
            this.dgvSendList.TabIndex = 1;
            this.dgvSendList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSendList_CellFormatting);
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
            this.tabPageSend.ResumeLayout(false);
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

    }
}