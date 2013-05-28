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
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("常规");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("发送顺序");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("发送", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelSend = new System.Windows.Forms.Panel();
            this.dgvSortList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.SendSortShow = new System.Windows.Forms.FlowLayoutPanel();
            this.panelRight.SuspendLayout();
            this.panelSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(10, 30);
            this.treeView1.Name = "treeView1";
            treeNode4.Name = "节点0";
            treeNode4.Text = "常规";
            treeNode5.Name = "节点2";
            treeNode5.Text = "发送顺序";
            treeNode6.Name = "节点1";
            treeNode6.Text = "发送";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode6});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(121, 299);
            this.treeView1.TabIndex = 0;
            // 
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.panelSend);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(131, 30);
            this.panelRight.Margin = new System.Windows.Forms.Padding(0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(334, 299);
            this.panelRight.TabIndex = 1;
            // 
            // panelSend
            // 
            this.panelSend.Controls.Add(this.SendSortShow);
            this.panelSend.Controls.Add(this.dgvSortList);
            this.panelSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSend.Location = new System.Drawing.Point(0, 0);
            this.panelSend.Name = "panelSend";
            this.panelSend.Size = new System.Drawing.Size(332, 297);
            this.panelSend.TabIndex = 0;
            // 
            // dgvSortList
            // 
            this.dgvSortList.AllowUserToAddRows = false;
            this.dgvSortList.AllowUserToDeleteRows = false;
            this.dgvSortList.AllowUserToResizeColumns = false;
            this.dgvSortList.AllowUserToResizeRows = false;
            this.dgvSortList.BackgroundColor = System.Drawing.Color.White;
            this.dgvSortList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSortList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSortList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSortList.ColumnHeadersHeight = 24;
            this.dgvSortList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSortList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvSortList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSortList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSortList.EnableHeadersVisualStyles = false;
            this.dgvSortList.GridColor = System.Drawing.Color.White;
            this.dgvSortList.Location = new System.Drawing.Point(0, 71);
            this.dgvSortList.MultiSelect = false;
            this.dgvSortList.Name = "dgvSortList";
            this.dgvSortList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSortList.RowHeadersVisible = false;
            this.dgvSortList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvSortList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvSortList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSortList.RowTemplate.Height = 24;
            this.dgvSortList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSortList.Size = new System.Drawing.Size(332, 226);
            this.dgvSortList.TabIndex = 1;
            this.dgvSortList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSortList_CellContentClick);
            this.dgvSortList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvSortList_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "显示";
            this.Column1.Name = "Column1";
            this.Column1.Width = 36;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "描述";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "优先级";
            this.Column3.Name = "Column3";
            this.Column3.Width = 67;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "设置优先";
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // SendSortShow
            // 
            this.SendSortShow.AutoScroll = true;
            this.SendSortShow.BackColor = System.Drawing.Color.White;
            this.SendSortShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendSortShow.Location = new System.Drawing.Point(0, 0);
            this.SendSortShow.Name = "SendSortShow";
            this.SendSortShow.Size = new System.Drawing.Size(332, 71);
            this.SendSortShow.TabIndex = 2;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(475, 339);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.panelRight.ResumeLayout(false);
            this.panelSend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSortList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelSend;
        private System.Windows.Forms.DataGridView dgvSortList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.FlowLayoutPanel SendSortShow;
    }
}