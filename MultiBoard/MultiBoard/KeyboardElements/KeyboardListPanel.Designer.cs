namespace MultiBoard.KeyboardElements
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardListPanel));
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.UUID_LABEL = new System.Windows.Forms.Label();
            this.SETTINGS_BUTTON = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.NAME_LABEL.MouseEnter += new System.EventHandler(this.KeyboardListPanel_MouseEnter);
            this.NAME_LABEL.MouseLeave += new System.EventHandler(this.KeyboardListPanel_MouseLeave);
            // 
            // UUID_LABEL
            // 
            this.UUID_LABEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.UUID_LABEL.AutoSize = true;
            this.UUID_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UUID_LABEL.ForeColor = System.Drawing.Color.White;
            this.UUID_LABEL.Location = new System.Drawing.Point(15, 39);
            this.UUID_LABEL.Name = "UUID_LABEL";
            this.UUID_LABEL.Size = new System.Drawing.Size(40, 13);
            this.UUID_LABEL.TabIndex = 1;
            this.UUID_LABEL.Text = "[UUID]";
            this.UUID_LABEL.Click += new System.EventHandler(this.KeyboardListPanel_Click);
            this.UUID_LABEL.MouseEnter += new System.EventHandler(this.KeyboardListPanel_MouseEnter);
            this.UUID_LABEL.MouseLeave += new System.EventHandler(this.KeyboardListPanel_MouseLeave);
            // 
            // SETTINGS_BUTTON
            // 
            this.SETTINGS_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.SETTINGS_BUTTON.MouseEnter += new System.EventHandler(this.KeyboardListPanel_MouseEnter);
            this.SETTINGS_BUTTON.MouseLeave += new System.EventHandler(this.KeyboardListPanel_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // KeyboardListPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.SETTINGS_BUTTON);
            this.Controls.Add(this.UUID_LABEL);
            this.Controls.Add(this.NAME_LABEL);
            this.Name = "KeyboardListPanel";
            this.Size = new System.Drawing.Size(385, 62);
            this.Click += new System.EventHandler(this.KeyboardListPanel_Click);
            this.MouseEnter += new System.EventHandler(this.KeyboardListPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.KeyboardListPanel_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.Label UUID_LABEL;
        private System.Windows.Forms.Button SETTINGS_BUTTON;
        private System.Windows.Forms.Timer timer1;
    }
}
