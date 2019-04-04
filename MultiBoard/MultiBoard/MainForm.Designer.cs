namespace MultiBoard
{
    partial class MultiBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiBoard));
            this.TOP_PANEL = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.MINIMIZE_B = new System.Windows.Forms.Button();
            this.CLOSE_B = new System.Windows.Forms.Button();
            this.TOP_ICON_PANEL = new System.Windows.Forms.Panel();
            this.MAIN_PANEL = new System.Windows.Forms.Panel();
            this.LEFT_PENEL = new System.Windows.Forms.Panel();
            this.ERROR_MANAGE_BUTTON = new System.Windows.Forms.Button();
            this.PERF_MODE_BUTTON = new System.Windows.Forms.Button();
            this.ADD_KEYBOARD_BUTTON = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KEYBOARD_B = new System.Windows.Forms.Button();
            this.SETTINGS_BUTTON = new System.Windows.Forms.Button();
            this.BOTTEM_PANEL = new System.Windows.Forms.Panel();
            this.ERROR_LABEL = new System.Windows.Forms.Label();
            this.WARRNING_BUTTON = new System.Windows.Forms.Button();
            this.TOGGLE_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.NOTIFY_ICO = new System.Windows.Forms.NotifyIcon(this.components);
            this.NOTIFY_ICO_CONTENT = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.TOP_PANEL.SuspendLayout();
            this.TOP_ICON_PANEL.SuspendLayout();
            this.LEFT_PENEL.SuspendLayout();
            this.BOTTEM_PANEL.SuspendLayout();
            this.NOTIFY_ICO_CONTENT.SuspendLayout();
            this.SuspendLayout();
            // 
            // TOP_PANEL
            // 
            this.TOP_PANEL.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TOP_PANEL.Controls.Add(this.label2);
            this.TOP_PANEL.Controls.Add(this.MINIMIZE_B);
            this.TOP_PANEL.Controls.Add(this.CLOSE_B);
            this.TOP_PANEL.Controls.Add(this.TOP_ICON_PANEL);
            this.TOP_PANEL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOP_PANEL.Location = new System.Drawing.Point(0, 0);
            this.TOP_PANEL.Name = "TOP_PANEL";
            this.TOP_PANEL.Size = new System.Drawing.Size(889, 31);
            this.TOP_PANEL.TabIndex = 0;
            this.TOP_PANEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(38, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Beta V1.0.1.1 ahk test";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            // 
            // MINIMIZE_B
            // 
            this.MINIMIZE_B.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MINIMIZE_B.BackColor = System.Drawing.Color.Transparent;
            this.MINIMIZE_B.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MINIMIZE_B.BackgroundImage")));
            this.MINIMIZE_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MINIMIZE_B.FlatAppearance.BorderSize = 0;
            this.MINIMIZE_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MINIMIZE_B.Location = new System.Drawing.Point(821, 0);
            this.MINIMIZE_B.Name = "MINIMIZE_B";
            this.MINIMIZE_B.Size = new System.Drawing.Size(31, 31);
            this.MINIMIZE_B.TabIndex = 3;
            this.MINIMIZE_B.UseVisualStyleBackColor = false;
            this.MINIMIZE_B.Click += new System.EventHandler(this.MINIMIZE_B_Click);
            // 
            // CLOSE_B
            // 
            this.CLOSE_B.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CLOSE_B.BackColor = System.Drawing.Color.Transparent;
            this.CLOSE_B.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CLOSE_B.BackgroundImage")));
            this.CLOSE_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CLOSE_B.FlatAppearance.BorderSize = 0;
            this.CLOSE_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLOSE_B.Location = new System.Drawing.Point(858, 0);
            this.CLOSE_B.Name = "CLOSE_B";
            this.CLOSE_B.Size = new System.Drawing.Size(31, 31);
            this.CLOSE_B.TabIndex = 2;
            this.CLOSE_B.UseVisualStyleBackColor = false;
            this.CLOSE_B.Click += new System.EventHandler(this.CLOSE_B_Click);
            // 
            // TOP_ICON_PANEL
            // 
            this.TOP_ICON_PANEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.TOP_ICON_PANEL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TOP_ICON_PANEL.BackgroundImage")));
            this.TOP_ICON_PANEL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TOP_ICON_PANEL.Controls.Add(this.MAIN_PANEL);
            this.TOP_ICON_PANEL.Dock = System.Windows.Forms.DockStyle.Left;
            this.TOP_ICON_PANEL.Location = new System.Drawing.Point(0, 0);
            this.TOP_ICON_PANEL.Name = "TOP_ICON_PANEL";
            this.TOP_ICON_PANEL.Size = new System.Drawing.Size(32, 31);
            this.TOP_ICON_PANEL.TabIndex = 1;
            this.TOP_ICON_PANEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            // 
            // MAIN_PANEL
            // 
            this.MAIN_PANEL.Location = new System.Drawing.Point(31, 31);
            this.MAIN_PANEL.Margin = new System.Windows.Forms.Padding(0);
            this.MAIN_PANEL.Name = "MAIN_PANEL";
            this.MAIN_PANEL.Size = new System.Drawing.Size(858, 508);
            this.MAIN_PANEL.TabIndex = 4;
            // 
            // LEFT_PENEL
            // 
            this.LEFT_PENEL.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.LEFT_PENEL.Controls.Add(this.ERROR_MANAGE_BUTTON);
            this.LEFT_PENEL.Controls.Add(this.PERF_MODE_BUTTON);
            this.LEFT_PENEL.Controls.Add(this.ADD_KEYBOARD_BUTTON);
            this.LEFT_PENEL.Controls.Add(this.panel1);
            this.LEFT_PENEL.Controls.Add(this.KEYBOARD_B);
            this.LEFT_PENEL.Controls.Add(this.SETTINGS_BUTTON);
            this.LEFT_PENEL.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT_PENEL.Location = new System.Drawing.Point(0, 31);
            this.LEFT_PENEL.Name = "LEFT_PENEL";
            this.LEFT_PENEL.Size = new System.Drawing.Size(32, 542);
            this.LEFT_PENEL.TabIndex = 2;
            // 
            // ERROR_MANAGE_BUTTON
            // 
            this.ERROR_MANAGE_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ERROR_MANAGE_BUTTON.BackColor = System.Drawing.Color.Transparent;
            this.ERROR_MANAGE_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ERROR_MANAGE_BUTTON.BackgroundImage")));
            this.ERROR_MANAGE_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ERROR_MANAGE_BUTTON.FlatAppearance.BorderSize = 0;
            this.ERROR_MANAGE_BUTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ERROR_MANAGE_BUTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ERROR_MANAGE_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ERROR_MANAGE_BUTTON.Location = new System.Drawing.Point(0, 468);
            this.ERROR_MANAGE_BUTTON.Name = "ERROR_MANAGE_BUTTON";
            this.ERROR_MANAGE_BUTTON.Size = new System.Drawing.Size(32, 34);
            this.ERROR_MANAGE_BUTTON.TabIndex = 8;
            this.ERROR_MANAGE_BUTTON.UseVisualStyleBackColor = false;
            this.ERROR_MANAGE_BUTTON.Click += new System.EventHandler(this.ERROR_MANAGE_BUTTON_Click);
            // 
            // PERF_MODE_BUTTON
            // 
            this.PERF_MODE_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PERF_MODE_BUTTON.BackColor = System.Drawing.Color.Transparent;
            this.PERF_MODE_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PERF_MODE_BUTTON.BackgroundImage")));
            this.PERF_MODE_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PERF_MODE_BUTTON.FlatAppearance.BorderSize = 0;
            this.PERF_MODE_BUTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.PERF_MODE_BUTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PERF_MODE_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PERF_MODE_BUTTON.Location = new System.Drawing.Point(0, 83);
            this.PERF_MODE_BUTTON.Name = "PERF_MODE_BUTTON";
            this.PERF_MODE_BUTTON.Size = new System.Drawing.Size(32, 34);
            this.PERF_MODE_BUTTON.TabIndex = 7;
            this.PERF_MODE_BUTTON.UseVisualStyleBackColor = false;
            this.PERF_MODE_BUTTON.Visible = false;
            this.PERF_MODE_BUTTON.Click += new System.EventHandler(this.PERF_MODE_BUTTON_Click);
            // 
            // ADD_KEYBOARD_BUTTON
            // 
            this.ADD_KEYBOARD_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ADD_KEYBOARD_BUTTON.BackColor = System.Drawing.Color.Transparent;
            this.ADD_KEYBOARD_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ADD_KEYBOARD_BUTTON.BackgroundImage")));
            this.ADD_KEYBOARD_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ADD_KEYBOARD_BUTTON.FlatAppearance.BorderSize = 0;
            this.ADD_KEYBOARD_BUTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.ADD_KEYBOARD_BUTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ADD_KEYBOARD_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ADD_KEYBOARD_BUTTON.Location = new System.Drawing.Point(0, 40);
            this.ADD_KEYBOARD_BUTTON.Name = "ADD_KEYBOARD_BUTTON";
            this.ADD_KEYBOARD_BUTTON.Size = new System.Drawing.Size(32, 34);
            this.ADD_KEYBOARD_BUTTON.TabIndex = 6;
            this.ADD_KEYBOARD_BUTTON.UseVisualStyleBackColor = false;
            this.ADD_KEYBOARD_BUTTON.Click += new System.EventHandler(this.ADD_KEYBOARD_BUTTON_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(32, 1);
            this.panel1.TabIndex = 4;
            // 
            // KEYBOARD_B
            // 
            this.KEYBOARD_B.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KEYBOARD_B.BackColor = System.Drawing.Color.Transparent;
            this.KEYBOARD_B.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("KEYBOARD_B.BackgroundImage")));
            this.KEYBOARD_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.KEYBOARD_B.FlatAppearance.BorderSize = 0;
            this.KEYBOARD_B.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.KEYBOARD_B.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.KEYBOARD_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KEYBOARD_B.Location = new System.Drawing.Point(0, 0);
            this.KEYBOARD_B.Name = "KEYBOARD_B";
            this.KEYBOARD_B.Size = new System.Drawing.Size(32, 34);
            this.KEYBOARD_B.TabIndex = 5;
            this.KEYBOARD_B.UseVisualStyleBackColor = false;
            this.KEYBOARD_B.Click += new System.EventHandler(this.KEYBOARD_LIST_CLICKED);
            // 
            // SETTINGS_BUTTON
            // 
            this.SETTINGS_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SETTINGS_BUTTON.BackColor = System.Drawing.Color.Transparent;
            this.SETTINGS_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SETTINGS_BUTTON.BackgroundImage")));
            this.SETTINGS_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SETTINGS_BUTTON.FlatAppearance.BorderSize = 0;
            this.SETTINGS_BUTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.SETTINGS_BUTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SETTINGS_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SETTINGS_BUTTON.Location = new System.Drawing.Point(0, 508);
            this.SETTINGS_BUTTON.Name = "SETTINGS_BUTTON";
            this.SETTINGS_BUTTON.Size = new System.Drawing.Size(32, 34);
            this.SETTINGS_BUTTON.TabIndex = 4;
            this.SETTINGS_BUTTON.UseVisualStyleBackColor = false;
            this.SETTINGS_BUTTON.Click += new System.EventHandler(this.SETTINGS_BUTTON_Click);
            // 
            // BOTTEM_PANEL
            // 
            this.BOTTEM_PANEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BOTTEM_PANEL.BackColor = System.Drawing.Color.Linen;
            this.BOTTEM_PANEL.Controls.Add(this.ERROR_LABEL);
            this.BOTTEM_PANEL.Controls.Add(this.WARRNING_BUTTON);
            this.BOTTEM_PANEL.Controls.Add(this.TOGGLE_B);
            this.BOTTEM_PANEL.Controls.Add(this.label1);
            this.BOTTEM_PANEL.Location = new System.Drawing.Point(31, 539);
            this.BOTTEM_PANEL.Margin = new System.Windows.Forms.Padding(0);
            this.BOTTEM_PANEL.Name = "BOTTEM_PANEL";
            this.BOTTEM_PANEL.Size = new System.Drawing.Size(858, 34);
            this.BOTTEM_PANEL.TabIndex = 3;
            // 
            // ERROR_LABEL
            // 
            this.ERROR_LABEL.AutoSize = true;
            this.ERROR_LABEL.Location = new System.Drawing.Point(703, 9);
            this.ERROR_LABEL.Name = "ERROR_LABEL";
            this.ERROR_LABEL.Size = new System.Drawing.Size(0, 13);
            this.ERROR_LABEL.TabIndex = 8;
            // 
            // WARRNING_BUTTON
            // 
            this.WARRNING_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WARRNING_BUTTON.BackColor = System.Drawing.Color.Linen;
            this.WARRNING_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("WARRNING_BUTTON.BackgroundImage")));
            this.WARRNING_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.WARRNING_BUTTON.FlatAppearance.BorderSize = 0;
            this.WARRNING_BUTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.WARRNING_BUTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WARRNING_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WARRNING_BUTTON.Location = new System.Drawing.Point(826, 0);
            this.WARRNING_BUTTON.Name = "WARRNING_BUTTON";
            this.WARRNING_BUTTON.Size = new System.Drawing.Size(32, 34);
            this.WARRNING_BUTTON.TabIndex = 7;
            this.WARRNING_BUTTON.UseVisualStyleBackColor = false;
            this.WARRNING_BUTTON.Visible = false;
            this.WARRNING_BUTTON.Click += new System.EventHandler(this.WARRNING_BUTTON_Click);
            // 
            // TOGGLE_B
            // 
            this.TOGGLE_B.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TOGGLE_B.BackColor = System.Drawing.Color.Transparent;
            this.TOGGLE_B.BackgroundImage = global::MultiBoard.Properties.Resources.TOGGLE_ON;
            this.TOGGLE_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TOGGLE_B.FlatAppearance.BorderSize = 0;
            this.TOGGLE_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TOGGLE_B.Location = new System.Drawing.Point(54, 0);
            this.TOGGLE_B.Name = "TOGGLE_B";
            this.TOGGLE_B.Size = new System.Drawing.Size(45, 34);
            this.TOGGLE_B.TabIndex = 4;
            this.TOGGLE_B.UseVisualStyleBackColor = false;
            this.TOGGLE_B.Click += new System.EventHandler(this.TOGGLE_B_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Off/On";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // NOTIFY_ICO
            // 
            this.NOTIFY_ICO.ContextMenuStrip = this.NOTIFY_ICO_CONTENT;
            this.NOTIFY_ICO.Icon = ((System.Drawing.Icon)(resources.GetObject("NOTIFY_ICO.Icon")));
            this.NOTIFY_ICO.Text = "MultiBoard";
            this.NOTIFY_ICO.Visible = true;
            this.NOTIFY_ICO.Click += new System.EventHandler(this.NOTIFY_ICO_Click);
            // 
            // NOTIFY_ICO_CONTENT
            // 
            this.NOTIFY_ICO_CONTENT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.openToolStripMenuItem});
            this.NOTIFY_ICO_CONTENT.Name = "NOTIFY_ICO_CONTENT";
            this.NOTIFY_ICO_CONTENT.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.NOTIFY_ICO_CONTENT.ShowImageMargin = false;
            this.NOTIFY_ICO_CONTENT.Size = new System.Drawing.Size(79, 48);
            this.NOTIFY_ICO_CONTENT.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.NOTIFY_ICO_CONTENT_ItemClicked);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(78, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // MultiBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 573);
            this.Controls.Add(this.LEFT_PENEL);
            this.Controls.Add(this.BOTTEM_PANEL);
            this.Controls.Add(this.TOP_PANEL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MultiBoard";
            this.Text = "MultiBoard";
            this.Shown += new System.EventHandler(this.MultiBoard_Shown);
            this.TOP_PANEL.ResumeLayout(false);
            this.TOP_PANEL.PerformLayout();
            this.TOP_ICON_PANEL.ResumeLayout(false);
            this.LEFT_PENEL.ResumeLayout(false);
            this.BOTTEM_PANEL.ResumeLayout(false);
            this.BOTTEM_PANEL.PerformLayout();
            this.NOTIFY_ICO_CONTENT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TOP_PANEL;
        private System.Windows.Forms.Panel TOP_ICON_PANEL;
        private System.Windows.Forms.Panel LEFT_PENEL;
        private System.Windows.Forms.Panel BOTTEM_PANEL;
        private System.Windows.Forms.Button CLOSE_B;
        private System.Windows.Forms.Button MINIMIZE_B;
        private System.Windows.Forms.Button TOGGLE_B;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SETTINGS_BUTTON;
        private System.Windows.Forms.Button KEYBOARD_B;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MAIN_PANEL;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button ADD_KEYBOARD_BUTTON;
        private System.Windows.Forms.Button WARRNING_BUTTON;
        private System.Windows.Forms.NotifyIcon NOTIFY_ICO;
        private System.Windows.Forms.ContextMenuStrip NOTIFY_ICO_CONTENT;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label ERROR_LABEL;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button PERF_MODE_BUTTON;
        private System.Windows.Forms.Button ERROR_MANAGE_BUTTON;
    }
}

