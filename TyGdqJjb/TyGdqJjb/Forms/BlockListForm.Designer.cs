namespace TyGdqJjb.Forms
{
    partial class BlockListForm
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
            this.dgvBlockList = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBlockList
            // 
            this.dgvBlockList.AllowUserToAddRows = false;
            this.dgvBlockList.AllowUserToDeleteRows = false;
            this.dgvBlockList.AllowUserToResizeColumns = false;
            this.dgvBlockList.AllowUserToResizeRows = false;
            this.dgvBlockList.BackgroundColor = System.Drawing.Color.White;
            this.dgvBlockList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBlockList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBlockList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBlockList.ColumnHeadersHeight = 24;
            this.dgvBlockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBlockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column3,
            this.Column1,
            this.Column2});
            this.dgvBlockList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBlockList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBlockList.EnableHeadersVisualStyles = false;
            this.dgvBlockList.GridColor = System.Drawing.Color.White;
            this.dgvBlockList.Location = new System.Drawing.Point(10, 24);
            this.dgvBlockList.MultiSelect = false;
            this.dgvBlockList.Name = "dgvBlockList";
            this.dgvBlockList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvBlockList.RowHeadersVisible = false;
            this.dgvBlockList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvBlockList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvBlockList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvBlockList.RowTemplate.Height = 24;
            this.dgvBlockList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBlockList.Size = new System.Drawing.Size(364, 261);
            this.dgvBlockList.TabIndex = 0;
            this.dgvBlockList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBlockList_CellContentClick);
            this.dgvBlockList.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBlockList_CellFormatting);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "名单";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "类型";
            this.Column3.Name = "Column3";
            this.Column3.Width = 60;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "屏蔽关键字";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Text = "";
            this.Column2.Width = 5;
            // 
            // BlockListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(384, 295);
            this.Controls.Add(this.dgvBlockList);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 333);
            this.Name = "BlockListForm";
            this.Padding = new System.Windows.Forms.Padding(10, 24, 10, 10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "群屏蔽列表【屏蔽后将不会被显示】";
            this.Load += new System.EventHandler(this.BlockListForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BlockListForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBlockList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBlockList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}