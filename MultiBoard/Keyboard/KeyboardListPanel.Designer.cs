namespace MultiBoard.Keyboard
{
    partial class KeyboardListPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardListPanel));
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.UUID_LABEL = new System.Windows.Forms.Label();
            this.SETTINGS_BUTTON = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NAME_LABEL.ForeColor = System.Drawing.Color.White;
            this.NAME_LABEL.Location = new System.Drawing.Point(14, 13);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(63, 20);
            this.NAME_LABEL.TabIndex = 0;
            this.NAME_LABEL.Text = "[NAME]";
            this.NAME_LABEL.Click += new System.EventHandler(this.KeyboardListPanel_Click);
            // 
            // UUID_LABEL
            // 
            this.UUID_LABEL.AutoSize = true;
            this.UUID_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UUID_LABEL.ForeColor = System.Drawing.Color.White;
            this.UUID_LABEL.Location = new System.Drawing.Point(15, 39);
            this.UUID_LABEL.Name = "UUID_LABEL";
            this.UUID_LABEL.Size = new System.Drawing.Size(40, 13);
            this.UUID_LABEL.TabIndex = 1;
            this.UUID_LABEL.Text = "[UUID]";
            this.UUID_LABEL.Click += new System.EventHandler(this.KeyboardListPanel_Click);
            // 
            // SETTINGS_BUTTON
            // 
            this.SETTINGS_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SETTINGS_BUTTON.BackgroundImage")));
            this.SETTINGS_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SETTINGS_BUTTON.FlatAppearance.BorderSize = 0;
            this.SETTINGS_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SETTINGS_BUTTON.Location = new System.Drawing.Point(336, 12);
            this.SETTINGS_BUTTON.Name = "SETTINGS_BUTTON";
            this.SETTINGS_BUTTON.Size = new System.Drawing.Size(40, 40);
            this.SETTINGS_BUTTON.TabIndex = 2;
            this.SETTINGS_BUTTON.UseVisualStyleBackColor = true;
            this.SETTINGS_BUTTON.Click += new System.EventHandler(this.SETTINGS_BUTTON_Click);
            // 
            // KeyboardListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.SETTINGS_BUTTON);
            this.Controls.Add(this.UUID_LABEL);
            this.Controls.Add(this.NAME_LABEL);
            this.Name = "KeyboardListPanel";
            this.Size = new System.Drawing.Size(385, 62);
            this.Click += new System.EventHandler(this.KeyboardListPanel_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.Label UUID_LABEL;
        private System.Windows.Forms.Button SETTINGS_BUTTON;
    }
}
