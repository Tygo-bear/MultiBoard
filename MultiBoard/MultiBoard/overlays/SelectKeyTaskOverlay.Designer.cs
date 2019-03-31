namespace MultiBoard.overlays
{
    partial class SelectKeyTaskOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectKeyTaskOverlay));
            this.F_KEY_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.OK_BUTTON = new System.Windows.Forms.Button();
            this.CLOSE_B = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.F_KEYS_RADIOBUTTON = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NORML_KEY_RADUIBUTTON = new System.Windows.Forms.RadioButton();
            this.NORMAL_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UND_KEY_RADIOBUTTON = new System.Windows.Forms.RadioButton();
            this.UND_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // F_KEY_COMBOBOX
            // 
            this.F_KEY_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.F_KEY_COMBOBOX.FormattingEnabled = true;
            this.F_KEY_COMBOBOX.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24"});
            this.F_KEY_COMBOBOX.Location = new System.Drawing.Point(126, 11);
            this.F_KEY_COMBOBOX.Name = "F_KEY_COMBOBOX";
            this.F_KEY_COMBOBOX.Size = new System.Drawing.Size(121, 21);
            this.F_KEY_COMBOBOX.TabIndex = 0;
            // 
            // OK_BUTTON
            // 
            this.OK_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.OK_BUTTON.FlatAppearance.BorderSize = 0;
            this.OK_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_BUTTON.ForeColor = System.Drawing.Color.White;
            this.OK_BUTTON.Location = new System.Drawing.Point(334, 248);
            this.OK_BUTTON.Name = "OK_BUTTON";
            this.OK_BUTTON.Size = new System.Drawing.Size(57, 35);
            this.OK_BUTTON.TabIndex = 1;
            this.OK_BUTTON.Text = "OK";
            this.OK_BUTTON.UseVisualStyleBackColor = false;
            this.OK_BUTTON.Click += new System.EventHandler(this.OK_BUTTON_Click);
            // 
            // CLOSE_B
            // 
            this.CLOSE_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CLOSE_B.BackColor = System.Drawing.Color.Transparent;
            this.CLOSE_B.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CLOSE_B.BackgroundImage")));
            this.CLOSE_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CLOSE_B.FlatAppearance.BorderSize = 0;
            this.CLOSE_B.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLOSE_B.Location = new System.Drawing.Point(363, 0);
            this.CLOSE_B.Name = "CLOSE_B";
            this.CLOSE_B.Size = new System.Drawing.Size(31, 31);
            this.CLOSE_B.TabIndex = 3;
            this.CLOSE_B.UseVisualStyleBackColor = false;
            this.CLOSE_B.Click += new System.EventHandler(this.CLOSE_B_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.F_KEYS_RADIOBUTTON);
            this.panel1.Controls.Add(this.F_KEY_COMBOBOX);
            this.panel1.Location = new System.Drawing.Point(64, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 49);
            this.panel1.TabIndex = 4;
            // 
            // F_KEYS_RADIOBUTTON
            // 
            this.F_KEYS_RADIOBUTTON.AutoSize = true;
            this.F_KEYS_RADIOBUTTON.Location = new System.Drawing.Point(3, 15);
            this.F_KEYS_RADIOBUTTON.Name = "F_KEYS_RADIOBUTTON";
            this.F_KEYS_RADIOBUTTON.Size = new System.Drawing.Size(56, 17);
            this.F_KEYS_RADIOBUTTON.TabIndex = 1;
            this.F_KEYS_RADIOBUTTON.TabStop = true;
            this.F_KEYS_RADIOBUTTON.Text = "F keys";
            this.F_KEYS_RADIOBUTTON.UseVisualStyleBackColor = true;
            this.F_KEYS_RADIOBUTTON.Click += new System.EventHandler(this.OnCheckRadioButton);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.NORML_KEY_RADUIBUTTON);
            this.panel2.Controls.Add(this.NORMAL_COMBOBOX);
            this.panel2.Location = new System.Drawing.Point(64, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 49);
            this.panel2.TabIndex = 5;
            // 
            // NORML_KEY_RADUIBUTTON
            // 
            this.NORML_KEY_RADUIBUTTON.AutoSize = true;
            this.NORML_KEY_RADUIBUTTON.Checked = true;
            this.NORML_KEY_RADUIBUTTON.Location = new System.Drawing.Point(3, 15);
            this.NORML_KEY_RADUIBUTTON.Name = "NORML_KEY_RADUIBUTTON";
            this.NORML_KEY_RADUIBUTTON.Size = new System.Drawing.Size(83, 17);
            this.NORML_KEY_RADUIBUTTON.TabIndex = 1;
            this.NORML_KEY_RADUIBUTTON.TabStop = true;
            this.NORML_KEY_RADUIBUTTON.Text = "Normal keys";
            this.NORML_KEY_RADUIBUTTON.UseVisualStyleBackColor = true;
            this.NORML_KEY_RADUIBUTTON.Click += new System.EventHandler(this.OnCheckRadioButton);
            // 
            // NORMAL_COMBOBOX
            // 
            this.NORMAL_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NORMAL_COMBOBOX.FormattingEnabled = true;
            this.NORMAL_COMBOBOX.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.NORMAL_COMBOBOX.Location = new System.Drawing.Point(126, 15);
            this.NORMAL_COMBOBOX.Name = "NORMAL_COMBOBOX";
            this.NORMAL_COMBOBOX.Size = new System.Drawing.Size(121, 21);
            this.NORMAL_COMBOBOX.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.UND_KEY_RADIOBUTTON);
            this.panel3.Controls.Add(this.UND_COMBOBOX);
            this.panel3.Location = new System.Drawing.Point(64, 167);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 49);
            this.panel3.TabIndex = 5;
            // 
            // UND_KEY_RADIOBUTTON
            // 
            this.UND_KEY_RADIOBUTTON.AutoSize = true;
            this.UND_KEY_RADIOBUTTON.Location = new System.Drawing.Point(3, 15);
            this.UND_KEY_RADIOBUTTON.Name = "UND_KEY_RADIOBUTTON";
            this.UND_KEY_RADIOBUTTON.Size = new System.Drawing.Size(93, 17);
            this.UND_KEY_RADIOBUTTON.TabIndex = 1;
            this.UND_KEY_RADIOBUTTON.TabStop = true;
            this.UND_KEY_RADIOBUTTON.Text = "Undefind keys";
            this.UND_KEY_RADIOBUTTON.UseVisualStyleBackColor = true;
            this.UND_KEY_RADIOBUTTON.Click += new System.EventHandler(this.OnCheckRadioButton);
            // 
            // UND_COMBOBOX
            // 
            this.UND_COMBOBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UND_COMBOBOX.FormattingEnabled = true;
            this.UND_COMBOBOX.Items.AddRange(new object[] {
            "UND1",
            "UND2",
            "UND3",
            "UND4",
            "UND5",
            "UND6",
            "UND7",
            "UND8",
            "UND9",
            "UND10",
            "UND11"});
            this.UND_COMBOBOX.Location = new System.Drawing.Point(126, 11);
            this.UND_COMBOBOX.Name = "UND_COMBOBOX";
            this.UND_COMBOBOX.Size = new System.Drawing.Size(121, 21);
            this.UND_COMBOBOX.TabIndex = 0;
            // 
            // SelectKeyTaskOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CLOSE_B);
            this.Controls.Add(this.OK_BUTTON);
            this.Name = "SelectKeyTaskOverlay";
            this.Size = new System.Drawing.Size(394, 286);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox F_KEY_COMBOBOX;
        private System.Windows.Forms.Button OK_BUTTON;
        private System.Windows.Forms.Button CLOSE_B;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton F_KEYS_RADIOBUTTON;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton NORML_KEY_RADUIBUTTON;
        private System.Windows.Forms.ComboBox NORMAL_COMBOBOX;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton UND_KEY_RADIOBUTTON;
        private System.Windows.Forms.ComboBox UND_COMBOBOX;
    }
}
