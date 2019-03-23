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
            this.KEY_COMBOBOX = new System.Windows.Forms.ComboBox();
            this.OK_BUTTON = new System.Windows.Forms.Button();
            this.CLOSE_B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KEY_COMBOBOX
            // 
            this.KEY_COMBOBOX.FormattingEnabled = true;
            this.KEY_COMBOBOX.Items.AddRange(new object[] {
            "vk0x88",
            "vk0x89",
            "vk0x8A",
            "vk0x8B",
            "vk0x8C",
            "vk0x8D",
            "vk0x8E",
            "vk0x8F"});
            this.KEY_COMBOBOX.Location = new System.Drawing.Point(63, 83);
            this.KEY_COMBOBOX.Name = "KEY_COMBOBOX";
            this.KEY_COMBOBOX.Size = new System.Drawing.Size(121, 21);
            this.KEY_COMBOBOX.TabIndex = 0;
            // 
            // OK_BUTTON
            // 
            this.OK_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.OK_BUTTON.FlatAppearance.BorderSize = 0;
            this.OK_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK_BUTTON.ForeColor = System.Drawing.Color.White;
            this.OK_BUTTON.Location = new System.Drawing.Point(199, 159);
            this.OK_BUTTON.Name = "OK_BUTTON";
            this.OK_BUTTON.Size = new System.Drawing.Size(57, 35);
            this.OK_BUTTON.TabIndex = 1;
            this.OK_BUTTON.Text = "OK";
            this.OK_BUTTON.UseVisualStyleBackColor = false;
            this.OK_BUTTON.Click += new System.EventHandler(this.OK_BUTTON_Click);
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
            this.CLOSE_B.Location = new System.Drawing.Point(228, 0);
            this.CLOSE_B.Name = "CLOSE_B";
            this.CLOSE_B.Size = new System.Drawing.Size(31, 31);
            this.CLOSE_B.TabIndex = 3;
            this.CLOSE_B.UseVisualStyleBackColor = false;
            this.CLOSE_B.Click += new System.EventHandler(this.CLOSE_B_Click);
            // 
            // SelectKeyTaskOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CLOSE_B);
            this.Controls.Add(this.OK_BUTTON);
            this.Controls.Add(this.KEY_COMBOBOX);
            this.Name = "SelectKeyTaskOverlay";
            this.Size = new System.Drawing.Size(259, 197);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox KEY_COMBOBOX;
        private System.Windows.Forms.Button OK_BUTTON;
        private System.Windows.Forms.Button CLOSE_B;
    }
}
