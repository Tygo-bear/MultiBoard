namespace MultiBoard.KeyboardElements.KeyElements
{
    partial class KeyListPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyListPanel));
            this.KEY_PICTURE = new System.Windows.Forms.PictureBox();
            this.KEY_NAME_LABEL = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.KEY_PICTURE)).BeginInit();
            this.SuspendLayout();
            // 
            // KEY_PICTURE
            // 
            this.KEY_PICTURE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("KEY_PICTURE.BackgroundImage")));
            this.KEY_PICTURE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.KEY_PICTURE.Location = new System.Drawing.Point(4, 4);
            this.KEY_PICTURE.Name = "KEY_PICTURE";
            this.KEY_PICTURE.Size = new System.Drawing.Size(47, 43);
            this.KEY_PICTURE.TabIndex = 0;
            this.KEY_PICTURE.TabStop = false;
            this.KEY_PICTURE.Click += new System.EventHandler(this.KeyListPanel_Click);
            this.KEY_PICTURE.MouseEnter += new System.EventHandler(this.KeyListPanel_MouseEnter);
            this.KEY_PICTURE.MouseLeave += new System.EventHandler(this.KeyListPanel_MouseLeave);
            // 
            // KEY_NAME_LABEL
            // 
            this.KEY_NAME_LABEL.AutoSize = true;
            this.KEY_NAME_LABEL.Location = new System.Drawing.Point(58, 18);
            this.KEY_NAME_LABEL.Name = "KEY_NAME_LABEL";
            this.KEY_NAME_LABEL.Size = new System.Drawing.Size(44, 13);
            this.KEY_NAME_LABEL.TabIndex = 1;
            this.KEY_NAME_LABEL.Text = "[NAME]";
            this.KEY_NAME_LABEL.Click += new System.EventHandler(this.KeyListPanel_Click);
            this.KEY_NAME_LABEL.MouseEnter += new System.EventHandler(this.KeyListPanel_MouseEnter);
            this.KEY_NAME_LABEL.MouseLeave += new System.EventHandler(this.KeyListPanel_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // KeyListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.KEY_NAME_LABEL);
            this.Controls.Add(this.KEY_PICTURE);
            this.Name = "KeyListPanel";
            this.Size = new System.Drawing.Size(170, 50);
            this.Click += new System.EventHandler(this.KeyListPanel_Click);
            this.MouseEnter += new System.EventHandler(this.KeyListPanel_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.KeyListPanel_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.KEY_PICTURE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox KEY_PICTURE;
        private System.Windows.Forms.Label KEY_NAME_LABEL;
        private System.Windows.Forms.Timer timer1;
    }
}
