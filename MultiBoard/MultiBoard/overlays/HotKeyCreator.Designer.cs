namespace MultiBoard.overlays
{
    partial class HotKeyCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotKeyCreator));
            this.FirstKeySelectComboBox = new System.Windows.Forms.ComboBox();
            this.SecondKeySelectComboBox = new System.Windows.Forms.ComboBox();
            this.LastKeyTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RandomHotkeyButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CLOSE_B = new System.Windows.Forms.Button();
            this.OK_BUTTON = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SinglePushModeRadioButton = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstKeySelectComboBox
            // 
            this.FirstKeySelectComboBox.DisplayMember = "0";
            this.FirstKeySelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirstKeySelectComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstKeySelectComboBox.FormattingEnabled = true;
            this.FirstKeySelectComboBox.Items.AddRange(new object[] {
            "LWin",
            "RWin",
            "Ctrl",
            "Alt",
            "Shift"});
            this.FirstKeySelectComboBox.Location = new System.Drawing.Point(68, 44);
            this.FirstKeySelectComboBox.Margin = new System.Windows.Forms.Padding(10);
            this.FirstKeySelectComboBox.Name = "FirstKeySelectComboBox";
            this.FirstKeySelectComboBox.Size = new System.Drawing.Size(121, 26);
            this.FirstKeySelectComboBox.TabIndex = 0;
            // 
            // SecondKeySelectComboBox
            // 
            this.SecondKeySelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SecondKeySelectComboBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondKeySelectComboBox.FormattingEnabled = true;
            this.SecondKeySelectComboBox.Items.AddRange(new object[] {
            "NONE",
            "Shift",
            "Alt"});
            this.SecondKeySelectComboBox.Location = new System.Drawing.Point(236, 44);
            this.SecondKeySelectComboBox.Margin = new System.Windows.Forms.Padding(10);
            this.SecondKeySelectComboBox.Name = "SecondKeySelectComboBox";
            this.SecondKeySelectComboBox.Size = new System.Drawing.Size(121, 26);
            this.SecondKeySelectComboBox.TabIndex = 1;
            // 
            // LastKeyTextBox
            // 
            this.LastKeyTextBox.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastKeyTextBox.Location = new System.Drawing.Point(404, 44);
            this.LastKeyTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.LastKeyTextBox.Name = "LastKeyTextBox";
            this.LastKeyTextBox.Size = new System.Drawing.Size(135, 27);
            this.LastKeyTextBox.TabIndex = 2;
            this.LastKeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LastKeyTextBox_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.RandomHotkeyButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.FirstKeySelectComboBox);
            this.panel1.Controls.Add(this.LastKeyTextBox);
            this.panel1.Controls.Add(this.SecondKeySelectComboBox);
            this.panel1.Location = new System.Drawing.Point(10, 61);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 97);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(370, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "+";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "+";
            // 
            // RandomHotkeyButton
            // 
            this.RandomHotkeyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RandomHotkeyButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RandomHotkeyButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RandomHotkeyButton.BackgroundImage")));
            this.RandomHotkeyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RandomHotkeyButton.FlatAppearance.BorderSize = 0;
            this.RandomHotkeyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RandomHotkeyButton.ForeColor = System.Drawing.Color.Black;
            this.RandomHotkeyButton.Location = new System.Drawing.Point(552, 20);
            this.RandomHotkeyButton.Name = "RandomHotkeyButton";
            this.RandomHotkeyButton.Size = new System.Drawing.Size(54, 51);
            this.RandomHotkeyButton.TabIndex = 6;
            this.RandomHotkeyButton.UseVisualStyleBackColor = false;
            this.RandomHotkeyButton.Click += new System.EventHandler(this.RandomHotkeyButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Last key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Second key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "First key";
            // 
            // CLOSE_B
            // 
            this.CLOSE_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CLOSE_B.BackColor = System.Drawing.Color.Transparent;
            this.CLOSE_B.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CLOSE_B.BackgroundImage")));
            this.CLOSE_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CLOSE_B.FlatAppearance.BorderSize = 0;
            this.CLOSE_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLOSE_B.Location = new System.Drawing.Point(607, 0);
            this.CLOSE_B.Name = "CLOSE_B";
            this.CLOSE_B.Size = new System.Drawing.Size(31, 31);
            this.CLOSE_B.TabIndex = 4;
            this.CLOSE_B.UseVisualStyleBackColor = false;
            this.CLOSE_B.Click += new System.EventHandler(this.CLOSE_B_Click);
            // 
            // OK_BUTTON
            // 
            this.OK_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_BUTTON.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OK_BUTTON.FlatAppearance.BorderSize = 0;
            this.OK_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_BUTTON.ForeColor = System.Drawing.Color.Black;
            this.OK_BUTTON.Location = new System.Drawing.Point(578, 274);
            this.OK_BUTTON.Name = "OK_BUTTON";
            this.OK_BUTTON.Size = new System.Drawing.Size(57, 35);
            this.OK_BUTTON.TabIndex = 5;
            this.OK_BUTTON.Text = "OK";
            this.OK_BUTTON.UseVisualStyleBackColor = false;
            this.OK_BUTTON.Click += new System.EventHandler(this.OK_BUTTON_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(7, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hotkey creator";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.SinglePushModeRadioButton);
            this.panel2.Location = new System.Drawing.Point(10, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(615, 51);
            this.panel2.TabIndex = 7;
            // 
            // SinglePushModeRadioButton
            // 
            this.SinglePushModeRadioButton.AutoSize = true;
            this.SinglePushModeRadioButton.Checked = true;
            this.SinglePushModeRadioButton.Location = new System.Drawing.Point(26, 19);
            this.SinglePushModeRadioButton.Name = "SinglePushModeRadioButton";
            this.SinglePushModeRadioButton.Size = new System.Drawing.Size(81, 17);
            this.SinglePushModeRadioButton.TabIndex = 0;
            this.SinglePushModeRadioButton.TabStop = true;
            this.SinglePushModeRadioButton.Text = "Single Push";
            this.SinglePushModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(131, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(94, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Up down push";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // HotKeyCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OK_BUTTON);
            this.Controls.Add(this.CLOSE_B);
            this.Controls.Add(this.panel1);
            this.Name = "HotKeyCreator";
            this.Size = new System.Drawing.Size(638, 312);
            this.Load += new System.EventHandler(this.HotKeyCreator_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FirstKeySelectComboBox;
        private System.Windows.Forms.ComboBox SecondKeySelectComboBox;
        private System.Windows.Forms.TextBox LastKeyTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CLOSE_B;
        private System.Windows.Forms.Button OK_BUTTON;
        private System.Windows.Forms.Button RandomHotkeyButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton SinglePushModeRadioButton;
    }
}
