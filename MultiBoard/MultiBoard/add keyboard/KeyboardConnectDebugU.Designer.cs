
namespace MultiBoard.add_keyboard
{
    partial class KeyboardConnectDebugU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyboardConnectDebugU));
            this.CLOSE_BUTTON = new System.Windows.Forms.Button();
            this.LOG_TEXTBOX = new System.Windows.Forms.RichTextBox();
            this.REFRESH_BUTTON = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DEBUG_LABEL = new System.Windows.Forms.Label();
            this.SCANNER_BACKWORKER = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CLOSE_BUTTON
            // 
            this.CLOSE_BUTTON.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CLOSE_BUTTON.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CLOSE_BUTTON.FlatAppearance.BorderSize = 0;
            this.CLOSE_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CLOSE_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLOSE_BUTTON.ForeColor = System.Drawing.Color.White;
            this.CLOSE_BUTTON.Location = new System.Drawing.Point(3, 470);
            this.CLOSE_BUTTON.Name = "CLOSE_BUTTON";
            this.CLOSE_BUTTON.Size = new System.Drawing.Size(86, 35);
            this.CLOSE_BUTTON.TabIndex = 6;
            this.CLOSE_BUTTON.Text = "Close";
            this.CLOSE_BUTTON.UseVisualStyleBackColor = false;
            this.CLOSE_BUTTON.Click += new System.EventHandler(this.CLOSE_BUTTON_Click);
            // 
            // LOG_TEXTBOX
            // 
            this.LOG_TEXTBOX.BackColor = System.Drawing.Color.White;
            this.LOG_TEXTBOX.Location = new System.Drawing.Point(189, 101);
            this.LOG_TEXTBOX.Name = "LOG_TEXTBOX";
            this.LOG_TEXTBOX.ReadOnly = true;
            this.LOG_TEXTBOX.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.LOG_TEXTBOX.Size = new System.Drawing.Size(488, 265);
            this.LOG_TEXTBOX.TabIndex = 8;
            this.LOG_TEXTBOX.Text = "";
            // 
            // REFRESH_BUTTON
            // 
            this.REFRESH_BUTTON.BackColor = System.Drawing.Color.DarkGray;
            this.REFRESH_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("REFRESH_BUTTON.BackgroundImage")));
            this.REFRESH_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.REFRESH_BUTTON.Dock = System.Windows.Forms.DockStyle.Right;
            this.REFRESH_BUTTON.FlatAppearance.BorderSize = 0;
            this.REFRESH_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.REFRESH_BUTTON.ForeColor = System.Drawing.SystemColors.ControlText;
            this.REFRESH_BUTTON.Location = new System.Drawing.Point(438, 0);
            this.REFRESH_BUTTON.Margin = new System.Windows.Forms.Padding(0);
            this.REFRESH_BUTTON.Name = "REFRESH_BUTTON";
            this.REFRESH_BUTTON.Size = new System.Drawing.Size(50, 50);
            this.REFRESH_BUTTON.TabIndex = 9;
            this.REFRESH_BUTTON.UseVisualStyleBackColor = false;
            this.REFRESH_BUTTON.Click += new System.EventHandler(this.REFRESH_BUTTON_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.DEBUG_LABEL);
            this.panel1.Controls.Add(this.REFRESH_BUTTON);
            this.panel1.Location = new System.Drawing.Point(189, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(488, 50);
            this.panel1.TabIndex = 10;
            // 
            // DEBUG_LABEL
            // 
            this.DEBUG_LABEL.AutoSize = true;
            this.DEBUG_LABEL.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DEBUG_LABEL.ForeColor = System.Drawing.Color.Black;
            this.DEBUG_LABEL.Location = new System.Drawing.Point(8, 12);
            this.DEBUG_LABEL.Name = "DEBUG_LABEL";
            this.DEBUG_LABEL.Size = new System.Drawing.Size(331, 26);
            this.DEBUG_LABEL.TabIndex = 10;
            this.DEBUG_LABEL.Text = "Debug keyboard connections";
            // 
            // SCANNER_BACKWORKER
            // 
            this.SCANNER_BACKWORKER.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SCANNER_BACKWORKER_DoWork);
            // 
            // KeyboardConnectDebugU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LOG_TEXTBOX);
            this.Controls.Add(this.CLOSE_BUTTON);
            this.Name = "KeyboardConnectDebugU";
            this.Size = new System.Drawing.Size(857, 508);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CLOSE_BUTTON;
        private System.Windows.Forms.RichTextBox LOG_TEXTBOX;
        private System.Windows.Forms.Button REFRESH_BUTTON;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label DEBUG_LABEL;
        private System.ComponentModel.BackgroundWorker SCANNER_BACKWORKER;
    }
}
