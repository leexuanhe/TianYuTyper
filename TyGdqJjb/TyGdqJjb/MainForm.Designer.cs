﻿using System.Windows.Forms;

namespace TyGdqJjb
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelHead = new System.Windows.Forms.Panel();
            this.btnSet = new System.Windows.Forms.LinkLabel();
            this.lblTime = new System.Windows.Forms.Label();
            this.headPanel1 = new TyGdqJjb.TyControls.HeadPanel();
            this.richTextBoxEx1 = new TyGdqJjb.TyControls.RichTextBoxEx();
            this.DrightMenu = new TyGdqJjb.TyControls.RightMenu();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.载文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外观ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.字体ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.背景色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打对色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打错色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最高停留色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.回改色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxEx1 = new TyGdqJjb.TyControls.TextBoxEx();
            this.GrightMenu = new TyGdqJjb.TyControls.RightMenu();
            this.重打ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.外观ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.背景色ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.DrightMenu.SuspendLayout();
            this.GrightMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerMain.Location = new System.Drawing.Point(1, 51);
            this.splitContainerMain.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.richTextBoxEx1);
            this.splitContainerMain.Panel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.textBoxEx1);
            this.splitContainerMain.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.splitContainerMain.Size = new System.Drawing.Size(424, 327);
            this.splitContainerMain.SplitterDistance = 219;
            this.splitContainerMain.SplitterWidth = 3;
            this.splitContainerMain.TabIndex = 1;
            this.splitContainerMain.TabStop = false;
            // 
            // panelHead
            // 
            this.panelHead.Controls.Add(this.headPanel1);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(1, 22);
            this.panelHead.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(424, 25);
            this.panelHead.TabIndex = 3;
            // 
            // btnSet
            // 
            this.btnSet.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.AutoSize = true;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btnSet.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.btnSet.LinkColor = System.Drawing.Color.Silver;
            this.btnSet.Location = new System.Drawing.Point(394, 3);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(35, 19);
            this.btnSet.TabIndex = 6;
            this.btnSet.TabStop = true;
            this.btnSet.Text = "设置";
            this.btnSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSet_LinkClicked);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.ForeColor = System.Drawing.Color.Silver;
            this.lblTime.Location = new System.Drawing.Point(-2, 2);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(41, 20);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "0000";
            // 
            // headPanel1
            // 
            this.headPanel1.BackColor = System.Drawing.Color.White;
            this.headPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headPanel1.Location = new System.Drawing.Point(0, 0);
            this.headPanel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headPanel1.Name = "headPanel1";
            this.headPanel1.Size = new System.Drawing.Size(424, 25);
            this.headPanel1.TabIndex = 2;
            this.headPanel1.Title = "未设置";
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.BackColor = System.Drawing.Color.White;
            this.richTextBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxEx1.ContextMenuStrip = this.DrightMenu;
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx1.Location = new System.Drawing.Point(1, 1);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.ReadOnly = true;
            this.richTextBoxEx1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxEx1.Size = new System.Drawing.Size(422, 217);
            this.richTextBoxEx1.TabIndex = 0;
            this.richTextBoxEx1.TabStop = false;
            this.richTextBoxEx1.Text = "这是一段测试内容。。。";
            // 
            // DrightMenu
            // 
            this.DrightMenu.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.DrightMenu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.DrightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.toolStripSeparator1,
            this.载文ToolStripMenuItem,
            this.外观ToolStripMenuItem1});
            this.DrightMenu.Name = "DrightMenu";
            this.DrightMenu.Size = new System.Drawing.Size(111, 94);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(110, 28);
            this.复制ToolStripMenuItem.Text = "复制";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(107, 6);
            // 
            // 载文ToolStripMenuItem
            // 
            this.载文ToolStripMenuItem.Name = "载文ToolStripMenuItem";
            this.载文ToolStripMenuItem.Size = new System.Drawing.Size(110, 28);
            this.载文ToolStripMenuItem.Text = "载文";
            this.载文ToolStripMenuItem.Click += new System.EventHandler(this.载文ToolStripMenuItem_Click);
            // 
            // 外观ToolStripMenuItem1
            // 
            this.外观ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.字体ToolStripMenuItem1,
            this.背景色ToolStripMenuItem,
            this.打对色ToolStripMenuItem,
            this.打错色ToolStripMenuItem,
            this.最高停留色ToolStripMenuItem,
            this.回改色ToolStripMenuItem});
            this.外观ToolStripMenuItem1.Image = global::TyGdqJjb.Properties.Resources.外观图标22x22;
            this.外观ToolStripMenuItem1.Name = "外观ToolStripMenuItem1";
            this.外观ToolStripMenuItem1.Size = new System.Drawing.Size(110, 28);
            this.外观ToolStripMenuItem1.Text = "外观";
            // 
            // 字体ToolStripMenuItem1
            // 
            this.字体ToolStripMenuItem1.Name = "字体ToolStripMenuItem1";
            this.字体ToolStripMenuItem1.Size = new System.Drawing.Size(143, 24);
            this.字体ToolStripMenuItem1.Text = "字体";
            this.字体ToolStripMenuItem1.Click += new System.EventHandler(this.字体ToolStripMenuItem1_Click);
            // 
            // 背景色ToolStripMenuItem
            // 
            this.背景色ToolStripMenuItem.Name = "背景色ToolStripMenuItem";
            this.背景色ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.背景色ToolStripMenuItem.Text = "背景色";
            this.背景色ToolStripMenuItem.Click += new System.EventHandler(this.背景色ToolStripMenuItem_Click);
            // 
            // 打对色ToolStripMenuItem
            // 
            this.打对色ToolStripMenuItem.Name = "打对色ToolStripMenuItem";
            this.打对色ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.打对色ToolStripMenuItem.Text = "打对色";
            this.打对色ToolStripMenuItem.Click += new System.EventHandler(this.打对色ToolStripMenuItem_Click);
            // 
            // 打错色ToolStripMenuItem
            // 
            this.打错色ToolStripMenuItem.Name = "打错色ToolStripMenuItem";
            this.打错色ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.打错色ToolStripMenuItem.Text = "打错色";
            this.打错色ToolStripMenuItem.Click += new System.EventHandler(this.打错色ToolStripMenuItem_Click);
            // 
            // 最高停留色ToolStripMenuItem
            // 
            this.最高停留色ToolStripMenuItem.Name = "最高停留色ToolStripMenuItem";
            this.最高停留色ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.最高停留色ToolStripMenuItem.Text = "最高停留色";
            this.最高停留色ToolStripMenuItem.Click += new System.EventHandler(this.最高停留色ToolStripMenuItem_Click);
            // 
            // 回改色ToolStripMenuItem
            // 
            this.回改色ToolStripMenuItem.Name = "回改色ToolStripMenuItem";
            this.回改色ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.回改色ToolStripMenuItem.Text = "回改色";
            this.回改色ToolStripMenuItem.Click += new System.EventHandler(this.回改色ToolStripMenuItem_Click);
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEx1.ContextMenuStrip = this.GrightMenu;
            this.textBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEx1.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.textBoxEx1.Location = new System.Drawing.Point(1, 1);
            this.textBoxEx1.Multiline = true;
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEx1.Size = new System.Drawing.Size(422, 103);
            this.textBoxEx1.TabIndex = 0;
            // 
            // GrightMenu
            // 
            this.GrightMenu.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.GrightMenu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.GrightMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重打ToolStripMenuItem,
            this.外观ToolStripMenuItem});
            this.GrightMenu.Name = "GrightMenu";
            this.GrightMenu.Size = new System.Drawing.Size(111, 60);
            // 
            // 重打ToolStripMenuItem
            // 
            this.重打ToolStripMenuItem.Name = "重打ToolStripMenuItem";
            this.重打ToolStripMenuItem.Size = new System.Drawing.Size(110, 28);
            this.重打ToolStripMenuItem.Text = "重打";
            this.重打ToolStripMenuItem.Click += new System.EventHandler(this.重打ToolStripMenuItem_Click);
            // 
            // 外观ToolStripMenuItem
            // 
            this.外观ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.字体ToolStripMenuItem,
            this.背景色ToolStripMenuItem1});
            this.外观ToolStripMenuItem.Image = global::TyGdqJjb.Properties.Resources.外观图标22x22;
            this.外观ToolStripMenuItem.Name = "外观ToolStripMenuItem";
            this.外观ToolStripMenuItem.Size = new System.Drawing.Size(110, 28);
            this.外观ToolStripMenuItem.Text = "外观";
            // 
            // 字体ToolStripMenuItem
            // 
            this.字体ToolStripMenuItem.Name = "字体ToolStripMenuItem";
            this.字体ToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.字体ToolStripMenuItem.Text = "字体";
            this.字体ToolStripMenuItem.Click += new System.EventHandler(this.字体ToolStripMenuItem_Click);
            // 
            // 背景色ToolStripMenuItem1
            // 
            this.背景色ToolStripMenuItem1.Name = "背景色ToolStripMenuItem1";
            this.背景色ToolStripMenuItem1.Size = new System.Drawing.Size(117, 24);
            this.背景色ToolStripMenuItem1.Text = "背景色";
            this.背景色ToolStripMenuItem1.Click += new System.EventHandler(this.背景色ToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(426, 381);
            this.Controls.Add(this.panelHead);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.lblTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(1, 22, 1, 1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelHead.ResumeLayout(false);
            this.DrightMenu.ResumeLayout(false);
            this.GrightMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TyControls.RichTextBoxEx richTextBoxEx1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private TyControls.HeadPanel headPanel1;
        private System.Windows.Forms.Panel panelHead;
        private TyControls.TextBoxEx textBoxEx1;
        private TyControls.RightMenu GrightMenu;
        private System.Windows.Forms.ToolStripMenuItem 重打ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 外观ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体ToolStripMenuItem;
        private TyControls.RightMenu DrightMenu;
        private System.Windows.Forms.ToolStripMenuItem 外观ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 字体ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 载文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 背景色ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打对色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打错色ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel btnSet;
        private System.Windows.Forms.ToolStripMenuItem 最高停留色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 回改色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label lblTime;
        private Timer timer = new Timer();
    }
}

