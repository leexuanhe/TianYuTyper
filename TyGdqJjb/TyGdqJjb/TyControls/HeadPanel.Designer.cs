namespace TyGdqJjb.TyControls
{
    partial class HeadPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.HrightMenu = new TyGdqJjb.TyControls.RightMenu();
            this.SuspendLayout();
            // 
            // HrightMenu
            // 
            this.HrightMenu.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HrightMenu.MaximumSize = new System.Drawing.Size(0, 300);
            this.HrightMenu.Name = "HrightMenu";
            this.HrightMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // HeadPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "HeadPanel";
            this.Size = new System.Drawing.Size(393, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private RightMenu HrightMenu;
    }
}
