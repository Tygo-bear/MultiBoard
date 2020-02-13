namespace MultiBoard.overlays
{
    partial class CheckForUpdatesOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckForUpdatesOverlay));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LATER_BUTTON = new System.Windows.Forms.Button();
            this.NO_BUTTON = new System.Windows.Forms.Button();
            this.YES_BUTTON = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(354, 124);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(332, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check for updates";
            // 
            // LATER_BUTTON
            // 
            this.LATER_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LATER_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LATER_BUTTON.FlatAppearance.BorderSize = 0;
            this.LATER_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LATER_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LATER_BUTTON.ForeColor = System.Drawing.Color.White;
            this.LATER_BUTTON.Location = new System.Drawing.Point(562, 340);
            this.LATER_BUTTON.Margin = new System.Windows.Forms.Padding(10);
            this.LATER_BUTTON.Name = "LATER_BUTTON";
            this.LATER_BUTTON.Size = new System.Drawing.Size(109, 47);
            this.LATER_BUTTON.TabIndex = 6;
            this.LATER_BUTTON.Text = "Later";
            this.LATER_BUTTON.UseVisualStyleBackColor = false;
            this.LATER_BUTTON.Click += new System.EventHandler(this.LATER_BUTTON_Click);
            // 
            // NO_BUTTON
            // 
            this.NO_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NO_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.NO_BUTTON.FlatAppearance.BorderSize = 0;
            this.NO_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NO_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NO_BUTTON.ForeColor = System.Drawing.Color.White;
            this.NO_BUTTON.Location = new System.Drawing.Point(385, 340);
            this.NO_BUTTON.Margin = new System.Windows.Forms.Padding(10);
            this.NO_BUTTON.Name = "NO_BUTTON";
            this.NO_BUTTON.Size = new System.Drawing.Size(109, 47);
            this.NO_BUTTON.TabIndex = 7;
            this.NO_BUTTON.Text = "No";
            this.NO_BUTTON.UseVisualStyleBackColor = false;
            this.NO_BUTTON.Click += new System.EventHandler(this.NO_BUTTON_Click);
            // 
            // YES_BUTTON
            // 
            this.YES_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.YES_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.YES_BUTTON.FlatAppearance.BorderSize = 0;
            this.YES_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.YES_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YES_BUTTON.ForeColor = System.Drawing.Color.White;
            this.YES_BUTTON.Location = new System.Drawing.Point(256, 340);
            this.YES_BUTTON.Margin = new System.Windows.Forms.Padding(10);
            this.YES_BUTTON.Name = "YES_BUTTON";
            this.YES_BUTTON.Size = new System.Drawing.Size(109, 47);
            this.YES_BUTTON.TabIndex = 8;
            this.YES_BUTTON.Text = "Yes";
            this.YES_BUTTON.UseVisualStyleBackColor = false;
            this.YES_BUTTON.Click += new System.EventHandler(this.YES_BUTTON_Click);
            // 
            // CheckForUpdatesOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.YES_BUTTON);
            this.Controls.Add(this.NO_BUTTON);
            this.Controls.Add(this.LATER_BUTTON);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CheckForUpdatesOverlay";
            this.Size = new System.Drawing.Size(889, 573);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LATER_BUTTON;
        private System.Windows.Forms.Button NO_BUTTON;
        private System.Windows.Forms.Button YES_BUTTON;
    }
}
