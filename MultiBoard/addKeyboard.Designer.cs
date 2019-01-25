namespace MultiBoard
{
    partial class addKeyboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addKeyboard));
            this.AUTO_ADD_PANEL = new System.Windows.Forms.Panel();
            this.REFRESH_BUTTON = new System.Windows.Forms.Button();
            this.AUTO_ADD_LABEL = new System.Windows.Forms.Label();
            this.MANUAL_ADD_PANEL = new System.Windows.Forms.Panel();
            this.MANUALY_ADD_LABEL = new System.Windows.Forms.Label();
            this.CANCEL_PANEL = new System.Windows.Forms.Panel();
            this.CANCEL_LABEL = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BACKGROUND_SCANNER = new System.ComponentModel.BackgroundWorker();
            this.AUTO_ADD_PANEL.SuspendLayout();
            this.MANUAL_ADD_PANEL.SuspendLayout();
            this.CANCEL_PANEL.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // AUTO_ADD_PANEL
            // 
            this.AUTO_ADD_PANEL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AUTO_ADD_PANEL.Controls.Add(this.REFRESH_BUTTON);
            this.AUTO_ADD_PANEL.Controls.Add(this.AUTO_ADD_LABEL);
            this.AUTO_ADD_PANEL.Location = new System.Drawing.Point(258, 81);
            this.AUTO_ADD_PANEL.Name = "AUTO_ADD_PANEL";
            this.AUTO_ADD_PANEL.Size = new System.Drawing.Size(353, 72);
            this.AUTO_ADD_PANEL.TabIndex = 0;
            this.AUTO_ADD_PANEL.Click += new System.EventHandler(this.AUTO_ADD_PANEL_Click);
            // 
            // REFRESH_BUTTON
            // 
            this.REFRESH_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.REFRESH_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("REFRESH_BUTTON.BackgroundImage")));
            this.REFRESH_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.REFRESH_BUTTON.FlatAppearance.BorderSize = 0;
            this.REFRESH_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.REFRESH_BUTTON.ForeColor = System.Drawing.SystemColors.ControlText;
            this.REFRESH_BUTTON.Location = new System.Drawing.Point(288, 12);
            this.REFRESH_BUTTON.Margin = new System.Windows.Forms.Padding(0);
            this.REFRESH_BUTTON.Name = "REFRESH_BUTTON";
            this.REFRESH_BUTTON.Size = new System.Drawing.Size(50, 50);
            this.REFRESH_BUTTON.TabIndex = 1;
            this.REFRESH_BUTTON.UseVisualStyleBackColor = false;
            this.REFRESH_BUTTON.Click += new System.EventHandler(this.REFRESH_BUTTON_Click);
            // 
            // AUTO_ADD_LABEL
            // 
            this.AUTO_ADD_LABEL.AutoSize = true;
            this.AUTO_ADD_LABEL.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AUTO_ADD_LABEL.ForeColor = System.Drawing.Color.White;
            this.AUTO_ADD_LABEL.Location = new System.Drawing.Point(12, 24);
            this.AUTO_ADD_LABEL.Name = "AUTO_ADD_LABEL";
            this.AUTO_ADD_LABEL.Size = new System.Drawing.Size(266, 26);
            this.AUTO_ADD_LABEL.TabIndex = 0;
            this.AUTO_ADD_LABEL.Text = "No keyboards detected";
            this.AUTO_ADD_LABEL.Click += new System.EventHandler(this.AUTO_ADD_PANEL_Click);
            // 
            // MANUAL_ADD_PANEL
            // 
            this.MANUAL_ADD_PANEL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MANUAL_ADD_PANEL.Controls.Add(this.MANUALY_ADD_LABEL);
            this.MANUAL_ADD_PANEL.Location = new System.Drawing.Point(258, 192);
            this.MANUAL_ADD_PANEL.Name = "MANUAL_ADD_PANEL";
            this.MANUAL_ADD_PANEL.Size = new System.Drawing.Size(353, 72);
            this.MANUAL_ADD_PANEL.TabIndex = 1;
            this.MANUAL_ADD_PANEL.Click += new System.EventHandler(this.MANUAL_ADD_PANEL_Click);
            // 
            // MANUALY_ADD_LABEL
            // 
            this.MANUALY_ADD_LABEL.AutoSize = true;
            this.MANUALY_ADD_LABEL.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MANUALY_ADD_LABEL.ForeColor = System.Drawing.Color.White;
            this.MANUALY_ADD_LABEL.Location = new System.Drawing.Point(37, 23);
            this.MANUALY_ADD_LABEL.Name = "MANUALY_ADD_LABEL";
            this.MANUALY_ADD_LABEL.Size = new System.Drawing.Size(273, 26);
            this.MANUALY_ADD_LABEL.TabIndex = 1;
            this.MANUALY_ADD_LABEL.Text = "Add keyboard manually";
            this.MANUALY_ADD_LABEL.Click += new System.EventHandler(this.MANUAL_ADD_PANEL_Click);
            // 
            // CANCEL_PANEL
            // 
            this.CANCEL_PANEL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CANCEL_PANEL.Controls.Add(this.CANCEL_LABEL);
            this.CANCEL_PANEL.Location = new System.Drawing.Point(343, 324);
            this.CANCEL_PANEL.Name = "CANCEL_PANEL";
            this.CANCEL_PANEL.Size = new System.Drawing.Size(185, 56);
            this.CANCEL_PANEL.TabIndex = 1;
            this.CANCEL_PANEL.Click += new System.EventHandler(this.CANCEL_PANEL_Click);
            // 
            // CANCEL_LABEL
            // 
            this.CANCEL_LABEL.AutoSize = true;
            this.CANCEL_LABEL.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANCEL_LABEL.ForeColor = System.Drawing.Color.White;
            this.CANCEL_LABEL.Location = new System.Drawing.Point(49, 17);
            this.CANCEL_LABEL.Name = "CANCEL_LABEL";
            this.CANCEL_LABEL.Size = new System.Drawing.Size(84, 26);
            this.CANCEL_LABEL.TabIndex = 2;
            this.CANCEL_LABEL.Text = "Cancel";
            this.CANCEL_LABEL.Click += new System.EventHandler(this.CANCEL_PANEL_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CANCEL_PANEL);
            this.panel4.Controls.Add(this.AUTO_ADD_PANEL);
            this.panel4.Controls.Add(this.MANUAL_ADD_PANEL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(857, 508);
            this.panel4.TabIndex = 2;
            // 
            // BACKGROUND_SCANNER
            // 
            this.BACKGROUND_SCANNER.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BACKGROUND_SCANNER_DoWork);
            // 
            // addKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Name = "addKeyboard";
            this.Size = new System.Drawing.Size(857, 508);
            this.AUTO_ADD_PANEL.ResumeLayout(false);
            this.AUTO_ADD_PANEL.PerformLayout();
            this.MANUAL_ADD_PANEL.ResumeLayout(false);
            this.MANUAL_ADD_PANEL.PerformLayout();
            this.CANCEL_PANEL.ResumeLayout(false);
            this.CANCEL_PANEL.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AUTO_ADD_PANEL;
        private System.Windows.Forms.Button REFRESH_BUTTON;
        private System.Windows.Forms.Label AUTO_ADD_LABEL;
        private System.Windows.Forms.Panel MANUAL_ADD_PANEL;
        private System.Windows.Forms.Label MANUALY_ADD_LABEL;
        private System.Windows.Forms.Panel CANCEL_PANEL;
        private System.Windows.Forms.Label CANCEL_LABEL;
        private System.Windows.Forms.Panel panel4;
        private System.ComponentModel.BackgroundWorker BACKGROUND_SCANNER;
    }
}
