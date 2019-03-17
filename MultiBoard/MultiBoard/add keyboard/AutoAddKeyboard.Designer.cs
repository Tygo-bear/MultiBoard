namespace MultiBoard
{
    partial class AutoAddKeyboard
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
            this.MANUAL_ADD_PANEL = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.SELECT_KEYBOARD_COMBOX = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NAME_TEXT_BOX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ADD_BUTTON = new System.Windows.Forms.Button();
            this.BAKC_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.MANUAL_ADD_PANEL.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MANUAL_ADD_PANEL
            // 
            this.MANUAL_ADD_PANEL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MANUAL_ADD_PANEL.Controls.Add(this.label3);
            this.MANUAL_ADD_PANEL.Controls.Add(this.SELECT_KEYBOARD_COMBOX);
            this.MANUAL_ADD_PANEL.Location = new System.Drawing.Point(242, 104);
            this.MANUAL_ADD_PANEL.Name = "MANUAL_ADD_PANEL";
            this.MANUAL_ADD_PANEL.Size = new System.Drawing.Size(367, 72);
            this.MANUAL_ADD_PANEL.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Selected keyboard";
            // 
            // SELECT_KEYBOARD_COMBOX
            // 
            this.SELECT_KEYBOARD_COMBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SELECT_KEYBOARD_COMBOX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SELECT_KEYBOARD_COMBOX.FormattingEnabled = true;
            this.SELECT_KEYBOARD_COMBOX.Location = new System.Drawing.Point(23, 33);
            this.SELECT_KEYBOARD_COMBOX.Name = "SELECT_KEYBOARD_COMBOX";
            this.SELECT_KEYBOARD_COMBOX.Size = new System.Drawing.Size(330, 21);
            this.SELECT_KEYBOARD_COMBOX.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.NAME_TEXT_BOX);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(242, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(367, 72);
            this.panel2.TabIndex = 5;
            // 
            // NAME_TEXT_BOX
            // 
            this.NAME_TEXT_BOX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NAME_TEXT_BOX.Location = new System.Drawing.Point(23, 33);
            this.NAME_TEXT_BOX.Name = "NAME_TEXT_BOX";
            this.NAME_TEXT_BOX.Size = new System.Drawing.Size(330, 20);
            this.NAME_TEXT_BOX.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Keyboard name";
            // 
            // ADD_BUTTON
            // 
            this.ADD_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ADD_BUTTON.FlatAppearance.BorderSize = 0;
            this.ADD_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ADD_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADD_BUTTON.ForeColor = System.Drawing.Color.White;
            this.ADD_BUTTON.Location = new System.Drawing.Point(332, 323);
            this.ADD_BUTTON.Name = "ADD_BUTTON";
            this.ADD_BUTTON.Size = new System.Drawing.Size(189, 56);
            this.ADD_BUTTON.TabIndex = 6;
            this.ADD_BUTTON.Text = "ADD";
            this.ADD_BUTTON.UseVisualStyleBackColor = false;
            this.ADD_BUTTON.Click += new System.EventHandler(this.ADD_BUTTON_Click);
            // 
            // BAKC_BUTTON
            // 
            this.BAKC_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BAKC_BUTTON.FlatAppearance.BorderSize = 0;
            this.BAKC_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAKC_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAKC_BUTTON.ForeColor = System.Drawing.Color.White;
            this.BAKC_BUTTON.Location = new System.Drawing.Point(3, 452);
            this.BAKC_BUTTON.Name = "BAKC_BUTTON";
            this.BAKC_BUTTON.Size = new System.Drawing.Size(119, 53);
            this.BAKC_BUTTON.TabIndex = 7;
            this.BAKC_BUTTON.Text = "< BACK";
            this.BAKC_BUTTON.UseVisualStyleBackColor = false;
            this.BAKC_BUTTON.Click += new System.EventHandler(this.BAKC_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "All active keyboards have to restart when a new keyboard is added!";
            // 
            // AutoAddKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BAKC_BUTTON);
            this.Controls.Add(this.ADD_BUTTON);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MANUAL_ADD_PANEL);
            this.Name = "AutoAddKeyboard";
            this.Size = new System.Drawing.Size(857, 508);
            this.MANUAL_ADD_PANEL.ResumeLayout(false);
            this.MANUAL_ADD_PANEL.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MANUAL_ADD_PANEL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SELECT_KEYBOARD_COMBOX;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NAME_TEXT_BOX;
        private System.Windows.Forms.Button ADD_BUTTON;
        private System.Windows.Forms.Button BAKC_BUTTON;
        private System.Windows.Forms.Label label1;
    }
}
