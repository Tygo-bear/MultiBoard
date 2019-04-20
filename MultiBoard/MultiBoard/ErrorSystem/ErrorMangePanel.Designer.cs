namespace MultiBoard.ErrorSystem
{
    partial class ErrorMangePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMangePanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.CLEAR_LIST_BUTTON = new System.Windows.Forms.Button();
            this.ERROR_LIST_LISTBOX = new System.Windows.Forms.ListBox();
            this.RELOAD_LIST_BUTTON = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 31);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Errors";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RELOAD_LIST_BUTTON);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.CLEAR_LIST_BUTTON);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 477);
            this.panel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reload boards";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // CLEAR_LIST_BUTTON
            // 
            this.CLEAR_LIST_BUTTON.BackColor = System.Drawing.Color.Silver;
            this.CLEAR_LIST_BUTTON.FlatAppearance.BorderSize = 0;
            this.CLEAR_LIST_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLEAR_LIST_BUTTON.Location = new System.Drawing.Point(4, 47);
            this.CLEAR_LIST_BUTTON.Name = "CLEAR_LIST_BUTTON";
            this.CLEAR_LIST_BUTTON.Size = new System.Drawing.Size(190, 35);
            this.CLEAR_LIST_BUTTON.TabIndex = 0;
            this.CLEAR_LIST_BUTTON.Text = "Clear List";
            this.CLEAR_LIST_BUTTON.UseVisualStyleBackColor = false;
            this.CLEAR_LIST_BUTTON.Click += new System.EventHandler(this.CLEAR_LIST_BUTTON_Click);
            // 
            // ERROR_LIST_LISTBOX
            // 
            this.ERROR_LIST_LISTBOX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ERROR_LIST_LISTBOX.FormattingEnabled = true;
            this.ERROR_LIST_LISTBOX.Location = new System.Drawing.Point(200, 31);
            this.ERROR_LIST_LISTBOX.Name = "ERROR_LIST_LISTBOX";
            this.ERROR_LIST_LISTBOX.Size = new System.Drawing.Size(657, 477);
            this.ERROR_LIST_LISTBOX.TabIndex = 2;
            // 
            // RELOAD_LIST_BUTTON
            // 
            this.RELOAD_LIST_BUTTON.BackColor = System.Drawing.Color.Silver;
            this.RELOAD_LIST_BUTTON.FlatAppearance.BorderSize = 0;
            this.RELOAD_LIST_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RELOAD_LIST_BUTTON.Location = new System.Drawing.Point(3, 6);
            this.RELOAD_LIST_BUTTON.Name = "RELOAD_LIST_BUTTON";
            this.RELOAD_LIST_BUTTON.Size = new System.Drawing.Size(190, 35);
            this.RELOAD_LIST_BUTTON.TabIndex = 2;
            this.RELOAD_LIST_BUTTON.Text = "Reload list";
            this.RELOAD_LIST_BUTTON.UseVisualStyleBackColor = false;
            this.RELOAD_LIST_BUTTON.Click += new System.EventHandler(this.RELOAD_LIST_BUTTON_Click);
            // 
            // ErrorMangePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.ERROR_LIST_LISTBOX);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ErrorMangePanel";
            this.Size = new System.Drawing.Size(857, 508);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox ERROR_LIST_LISTBOX;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button CLEAR_LIST_BUTTON;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button RELOAD_LIST_BUTTON;
    }
}
