namespace MultiBoard.SettingsElements
{
    partial class GeneralSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TOP_LEFT_LOGO_PICTUREBOX = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.THREAD_PRI_LABEL = new System.Windows.Forms.Label();
            this.PRIORITY_TRACKBAR = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.STAY_HIDDEN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TIME_DELAY_LABEL = new System.Windows.Forms.Label();
            this.TIME_OUT_TRACKBAR = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.SAVE_BUTTON = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SAFE_MODE_SCAN_CHECKBOX = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.UPDATE_CHECK_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TOP_LEFT_LOGO_PICTUREBOX)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PRIORITY_TRACKBAR)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIME_OUT_TRACKBAR)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.TOP_LEFT_LOGO_PICTUREBOX);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 32);
            this.panel1.TabIndex = 0;
            // 
            // TOP_LEFT_LOGO_PICTUREBOX
            // 
            this.TOP_LEFT_LOGO_PICTUREBOX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TOP_LEFT_LOGO_PICTUREBOX.BackgroundImage")));
            this.TOP_LEFT_LOGO_PICTUREBOX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TOP_LEFT_LOGO_PICTUREBOX.Dock = System.Windows.Forms.DockStyle.Left;
            this.TOP_LEFT_LOGO_PICTUREBOX.Location = new System.Drawing.Point(0, 0);
            this.TOP_LEFT_LOGO_PICTUREBOX.Name = "TOP_LEFT_LOGO_PICTUREBOX";
            this.TOP_LEFT_LOGO_PICTUREBOX.Size = new System.Drawing.Size(32, 32);
            this.TOP_LEFT_LOGO_PICTUREBOX.TabIndex = 1;
            this.TOP_LEFT_LOGO_PICTUREBOX.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "General settings";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.THREAD_PRI_LABEL);
            this.panel2.Controls.Add(this.PRIORITY_TRACKBAR);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(6, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 99);
            this.panel2.TabIndex = 1;
            // 
            // THREAD_PRI_LABEL
            // 
            this.THREAD_PRI_LABEL.AutoSize = true;
            this.THREAD_PRI_LABEL.Location = new System.Drawing.Point(7, 68);
            this.THREAD_PRI_LABEL.Name = "THREAD_PRI_LABEL";
            this.THREAD_PRI_LABEL.Size = new System.Drawing.Size(40, 13);
            this.THREAD_PRI_LABEL.TabIndex = 2;
            this.THREAD_PRI_LABEL.Text = "Normal";
            // 
            // PRIORITY_TRACKBAR
            // 
            this.PRIORITY_TRACKBAR.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PRIORITY_TRACKBAR.Cursor = System.Windows.Forms.Cursors.Default;
            this.PRIORITY_TRACKBAR.Location = new System.Drawing.Point(7, 20);
            this.PRIORITY_TRACKBAR.Maximum = 6;
            this.PRIORITY_TRACKBAR.Minimum = 1;
            this.PRIORITY_TRACKBAR.Name = "PRIORITY_TRACKBAR";
            this.PRIORITY_TRACKBAR.Size = new System.Drawing.Size(341, 45);
            this.PRIORITY_TRACKBAR.TabIndex = 1;
            this.PRIORITY_TRACKBAR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.PRIORITY_TRACKBAR.Value = 3;
            this.PRIORITY_TRACKBAR.ValueChanged += new System.EventHandler(this.PRIORITY_TRACKBAR_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thread priority";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.STAY_HIDDEN_CHECKBOX);
            this.panel3.Location = new System.Drawing.Point(6, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 67);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Only when a error occured will MultiBoard pop up";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "On system startup MultiBoard will stay hidden";
            // 
            // STAY_HIDDEN_CHECKBOX
            // 
            this.STAY_HIDDEN_CHECKBOX.AutoSize = true;
            this.STAY_HIDDEN_CHECKBOX.Location = new System.Drawing.Point(7, 3);
            this.STAY_HIDDEN_CHECKBOX.Name = "STAY_HIDDEN_CHECKBOX";
            this.STAY_HIDDEN_CHECKBOX.Size = new System.Drawing.Size(118, 17);
            this.STAY_HIDDEN_CHECKBOX.TabIndex = 1;
            this.STAY_HIDDEN_CHECKBOX.Text = "Stay in background";
            this.STAY_HIDDEN_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.TIME_DELAY_LABEL);
            this.panel4.Controls.Add(this.TIME_OUT_TRACKBAR);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(6, 218);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(366, 132);
            this.panel4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Shorter = slow startup time and less connection errors";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(283, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Longer = faster startup time and more connection problems";
            // 
            // TIME_DELAY_LABEL
            // 
            this.TIME_DELAY_LABEL.AutoSize = true;
            this.TIME_DELAY_LABEL.Location = new System.Drawing.Point(7, 68);
            this.TIME_DELAY_LABEL.Name = "TIME_DELAY_LABEL";
            this.TIME_DELAY_LABEL.Size = new System.Drawing.Size(44, 13);
            this.TIME_DELAY_LABEL.TabIndex = 2;
            this.TIME_DELAY_LABEL.Text = "6000ms";
            // 
            // TIME_OUT_TRACKBAR
            // 
            this.TIME_OUT_TRACKBAR.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TIME_OUT_TRACKBAR.Cursor = System.Windows.Forms.Cursors.Default;
            this.TIME_OUT_TRACKBAR.LargeChange = 1000;
            this.TIME_OUT_TRACKBAR.Location = new System.Drawing.Point(7, 20);
            this.TIME_OUT_TRACKBAR.Maximum = 10000;
            this.TIME_OUT_TRACKBAR.Minimum = 1000;
            this.TIME_OUT_TRACKBAR.Name = "TIME_OUT_TRACKBAR";
            this.TIME_OUT_TRACKBAR.Size = new System.Drawing.Size(341, 45);
            this.TIME_OUT_TRACKBAR.SmallChange = 500;
            this.TIME_OUT_TRACKBAR.TabIndex = 1;
            this.TIME_OUT_TRACKBAR.TickFrequency = 500;
            this.TIME_OUT_TRACKBAR.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.TIME_OUT_TRACKBAR.Value = 6000;
            this.TIME_OUT_TRACKBAR.ValueChanged += new System.EventHandler(this.TIME_OUT_TRACKBAR_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Connection time out delay";
            // 
            // SAVE_BUTTON
            // 
            this.SAVE_BUTTON.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.SAVE_BUTTON.FlatAppearance.BorderSize = 0;
            this.SAVE_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAVE_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAVE_BUTTON.ForeColor = System.Drawing.Color.White;
            this.SAVE_BUTTON.Location = new System.Drawing.Point(594, 467);
            this.SAVE_BUTTON.Name = "SAVE_BUTTON";
            this.SAVE_BUTTON.Size = new System.Drawing.Size(92, 38);
            this.SAVE_BUTTON.TabIndex = 4;
            this.SAVE_BUTTON.Text = "SAVE";
            this.SAVE_BUTTON.UseVisualStyleBackColor = false;
            this.SAVE_BUTTON.Click += new System.EventHandler(this.SAVE_BUTTON_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.SAFE_MODE_SCAN_CHECKBOX);
            this.panel5.Location = new System.Drawing.Point(6, 356);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(249, 67);
            this.panel5.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Only certain device get checked";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Experimental system";
            // 
            // SAFE_MODE_SCAN_CHECKBOX
            // 
            this.SAFE_MODE_SCAN_CHECKBOX.AutoSize = true;
            this.SAFE_MODE_SCAN_CHECKBOX.Location = new System.Drawing.Point(7, 3);
            this.SAFE_MODE_SCAN_CHECKBOX.Name = "SAFE_MODE_SCAN_CHECKBOX";
            this.SAFE_MODE_SCAN_CHECKBOX.Size = new System.Drawing.Size(162, 17);
            this.SAFE_MODE_SCAN_CHECKBOX.TabIndex = 1;
            this.SAFE_MODE_SCAN_CHECKBOX.Text = "Keyboard scan SAFE MODE";
            this.SAFE_MODE_SCAN_CHECKBOX.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Gainsboro;
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.UPDATE_CHECK_COMBOBOX);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Location = new System.Drawing.Point(6, 429);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(249, 76);
            this.panel6.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Check for Updates";
            // 
            // UPDATE_CHECK_COMBOBOX
            // 
            this.UPDATE_CHECK_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UPDATE_CHECK_COMBOBOX.FormattingEnabled = true;
            this.UPDATE_CHECK_COMBOBOX.Items.AddRange(new object[] {
            "No",
            "Yes",
            "Ask"});
            this.UPDATE_CHECK_COMBOBOX.Location = new System.Drawing.Point(4, 21);
            this.UPDATE_CHECK_COMBOBOX.Name = "UPDATE_CHECK_COMBOBOX";
            this.UPDATE_CHECK_COMBOBOX.Size = new System.Drawing.Size(151, 21);
            this.UPDATE_CHECK_COMBOBOX.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "On startup check if new version is available";
            // 
            // GeneralSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.SAVE_BUTTON);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GeneralSettings";
            this.Size = new System.Drawing.Size(689, 508);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TOP_LEFT_LOGO_PICTUREBOX)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PRIORITY_TRACKBAR)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TIME_OUT_TRACKBAR)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label THREAD_PRI_LABEL;
        private System.Windows.Forms.TrackBar PRIORITY_TRACKBAR;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox STAY_HIDDEN_CHECKBOX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label TIME_DELAY_LABEL;
        private System.Windows.Forms.TrackBar TIME_OUT_TRACKBAR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SAVE_BUTTON;
        private System.Windows.Forms.PictureBox TOP_LEFT_LOGO_PICTUREBOX;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox SAFE_MODE_SCAN_CHECKBOX;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox UPDATE_CHECK_COMBOBOX;
    }
}
