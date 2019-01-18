﻿namespace MultiBoard
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TOP_PANEL = new System.Windows.Forms.Panel();
            this.MINIMIZE_B = new System.Windows.Forms.Button();
            this.CLOSE_B = new System.Windows.Forms.Button();
            this.TOP_ICON_PANEL = new System.Windows.Forms.Panel();
            this.MAIN_PANEL = new System.Windows.Forms.Panel();
            this.LEFT_PENEL = new System.Windows.Forms.Panel();
            this.MANAGE_EYBOARDS_BUTTON = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.KEYBOARD_B = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BOTTEM_PANEL = new System.Windows.Forms.Panel();
            this.TOGGLE_B = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.WARRNING_BUTTON = new System.Windows.Forms.Button();
            this.TOP_PANEL.SuspendLayout();
            this.TOP_ICON_PANEL.SuspendLayout();
            this.LEFT_PENEL.SuspendLayout();
            this.BOTTEM_PANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // TOP_PANEL
            // 
            this.TOP_PANEL.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.TOP_PANEL.Controls.Add(this.MINIMIZE_B);
            this.TOP_PANEL.Controls.Add(this.CLOSE_B);
            this.TOP_PANEL.Controls.Add(this.TOP_ICON_PANEL);
            this.TOP_PANEL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOP_PANEL.Location = new System.Drawing.Point(0, 0);
            this.TOP_PANEL.Name = "TOP_PANEL";
            this.TOP_PANEL.Size = new System.Drawing.Size(889, 31);
            this.TOP_PANEL.TabIndex = 0;
            this.TOP_PANEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
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
            this.TOP_ICON_PANEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
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
            this.LEFT_PENEL.Controls.Add(this.MANAGE_EYBOARDS_BUTTON);
            this.LEFT_PENEL.Controls.Add(this.panel1);
            this.LEFT_PENEL.Controls.Add(this.KEYBOARD_B);
            this.LEFT_PENEL.Controls.Add(this.button2);
            this.LEFT_PENEL.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT_PENEL.Location = new System.Drawing.Point(0, 31);
            this.LEFT_PENEL.Name = "LEFT_PENEL";
            this.LEFT_PENEL.Size = new System.Drawing.Size(32, 542);
            this.LEFT_PENEL.TabIndex = 2;
            // 
            // MANAGE_EYBOARDS_BUTTON
            // 
            this.MANAGE_EYBOARDS_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MANAGE_EYBOARDS_BUTTON.BackColor = System.Drawing.Color.Transparent;
            this.MANAGE_EYBOARDS_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MANAGE_EYBOARDS_BUTTON.BackgroundImage")));
            this.MANAGE_EYBOARDS_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MANAGE_EYBOARDS_BUTTON.FlatAppearance.BorderSize = 0;
            this.MANAGE_EYBOARDS_BUTTON.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.MANAGE_EYBOARDS_BUTTON.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MANAGE_EYBOARDS_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MANAGE_EYBOARDS_BUTTON.Location = new System.Drawing.Point(0, 40);
            this.MANAGE_EYBOARDS_BUTTON.Name = "MANAGE_EYBOARDS_BUTTON";
            this.MANAGE_EYBOARDS_BUTTON.Size = new System.Drawing.Size(32, 34);
            this.MANAGE_EYBOARDS_BUTTON.TabIndex = 6;
            this.MANAGE_EYBOARDS_BUTTON.UseVisualStyleBackColor = false;
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
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 508);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 34);
            this.button2.TabIndex = 4;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // BOTTEM_PANEL
            // 
            this.BOTTEM_PANEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BOTTEM_PANEL.BackColor = System.Drawing.Color.Linen;
            this.BOTTEM_PANEL.Controls.Add(this.WARRNING_BUTTON);
            this.BOTTEM_PANEL.Controls.Add(this.TOGGLE_B);
            this.BOTTEM_PANEL.Controls.Add(this.label1);
            this.BOTTEM_PANEL.Location = new System.Drawing.Point(31, 539);
            this.BOTTEM_PANEL.Margin = new System.Windows.Forms.Padding(0);
            this.BOTTEM_PANEL.Name = "BOTTEM_PANEL";
            this.BOTTEM_PANEL.Size = new System.Drawing.Size(858, 34);
            this.BOTTEM_PANEL.TabIndex = 3;
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
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // WARRNING_BUTTON
            // 
            this.WARRNING_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WARRNING_BUTTON.BackColor = System.Drawing.Color.Transparent;
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 573);
            this.Controls.Add(this.LEFT_PENEL);
            this.Controls.Add(this.BOTTEM_PANEL);
            this.Controls.Add(this.TOP_PANEL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TOP_PANEL.ResumeLayout(false);
            this.TOP_ICON_PANEL.ResumeLayout(false);
            this.LEFT_PENEL.ResumeLayout(false);
            this.BOTTEM_PANEL.ResumeLayout(false);
            this.BOTTEM_PANEL.PerformLayout();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button KEYBOARD_B;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MAIN_PANEL;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button MANAGE_EYBOARDS_BUTTON;
        private System.Windows.Forms.Button WARRNING_BUTTON;
    }
}
