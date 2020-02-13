namespace MultiBoard.overlays
{
    partial class UpdateOverlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateOverlay));
            this.INSTALL_BUTTON = new System.Windows.Forms.Button();
            this.LATER_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DISABLE_UPDATES_BUTTON = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // INSTALL_BUTTON
            // 
            this.INSTALL_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.INSTALL_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.INSTALL_BUTTON.FlatAppearance.BorderSize = 0;
            this.INSTALL_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.INSTALL_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.INSTALL_BUTTON.ForeColor = System.Drawing.Color.White;
            this.INSTALL_BUTTON.Location = new System.Drawing.Point(299, 402);
            this.INSTALL_BUTTON.Margin = new System.Windows.Forms.Padding(10);
            this.INSTALL_BUTTON.Name = "INSTALL_BUTTON";
            this.INSTALL_BUTTON.Size = new System.Drawing.Size(109, 47);
            this.INSTALL_BUTTON.TabIndex = 13;
            this.INSTALL_BUTTON.Text = "Install";
            this.INSTALL_BUTTON.UseVisualStyleBackColor = false;
            this.INSTALL_BUTTON.Click += new System.EventHandler(this.INSTALL_BUTTON_Click);
            // 
            // LATER_BUTTON
            // 
            this.LATER_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LATER_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LATER_BUTTON.FlatAppearance.BorderSize = 0;
            this.LATER_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LATER_BUTTON.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LATER_BUTTON.ForeColor = System.Drawing.Color.White;
            this.LATER_BUTTON.Location = new System.Drawing.Point(428, 402);
            this.LATER_BUTTON.Margin = new System.Windows.Forms.Padding(10);
            this.LATER_BUTTON.Name = "LATER_BUTTON";
            this.LATER_BUTTON.Size = new System.Drawing.Size(109, 47);
            this.LATER_BUTTON.TabIndex = 12;
            this.LATER_BUTTON.Text = "Later";
            this.LATER_BUTTON.UseVisualStyleBackColor = false;
            this.LATER_BUTTON.Click += new System.EventHandler(this.LATER_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(335, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Install update";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(335, 169);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // DISABLE_UPDATES_BUTTON
            // 
            this.DISABLE_UPDATES_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DISABLE_UPDATES_BUTTON.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.DISABLE_UPDATES_BUTTON.FlatAppearance.BorderSize = 0;
            this.DISABLE_UPDATES_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DISABLE_UPDATES_BUTTON.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DISABLE_UPDATES_BUTTON.ForeColor = System.Drawing.Color.White;
            this.DISABLE_UPDATES_BUTTON.Location = new System.Drawing.Point(653, 403);
            this.DISABLE_UPDATES_BUTTON.Margin = new System.Windows.Forms.Padding(10);
            this.DISABLE_UPDATES_BUTTON.Name = "DISABLE_UPDATES_BUTTON";
            this.DISABLE_UPDATES_BUTTON.Size = new System.Drawing.Size(130, 47);
            this.DISABLE_UPDATES_BUTTON.TabIndex = 14;
            this.DISABLE_UPDATES_BUTTON.Text = "Disable updates";
            this.DISABLE_UPDATES_BUTTON.UseVisualStyleBackColor = false;
            this.DISABLE_UPDATES_BUTTON.Click += new System.EventHandler(this.DISABLE_UPDATES_BUTTON_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(335, 352);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(178, 23);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Visible = false;
            // 
            // UpdateOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.DISABLE_UPDATES_BUTTON);
            this.Controls.Add(this.INSTALL_BUTTON);
            this.Controls.Add(this.LATER_BUTTON);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UpdateOverlay";
            this.Size = new System.Drawing.Size(889, 573);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button INSTALL_BUTTON;
        private System.Windows.Forms.Button LATER_BUTTON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button DISABLE_UPDATES_BUTTON;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
