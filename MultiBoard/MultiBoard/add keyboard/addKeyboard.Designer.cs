namespace MultiBoard.add_keyboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addKeyboard));
            this.AUTO_ADD_PANEL = new System.Windows.Forms.Panel();
            this.REFRESH_BUTTON = new System.Windows.Forms.Button();
            this.AUTO_ADD_LABEL = new System.Windows.Forms.Label();
            this.MANUAL_ADD_PANEL = new System.Windows.Forms.Panel();
            this.MANUALY_ADD_LABEL = new System.Windows.Forms.Label();
            this.CANCEL_PANEL = new System.Windows.Forms.Panel();
            this.CANCEL_LABEL = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CONNECTION_PROBLEMS_BUTTON = new System.Windows.Forms.Button();
            this.BACKGROUND_SCANNER = new System.ComponentModel.BackgroundWorker();
            this.AUTO_ADD_HOVER_TIMER = new System.Windows.Forms.Timer(this.components);
            this.MANUAL_ADD_HOVER_TIMER = new System.Windows.Forms.Timer(this.components);
            this.CANCEL_HOVER_TIMER = new System.Windows.Forms.Timer(this.components);
            this.AUTO_ADD_PANEL.SuspendLayout();
            this.MANUAL_ADD_PANEL.SuspendLayout();
            this.CANCEL_PANEL.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // AUTO_ADD_PANEL
            // 
            this.AUTO_ADD_PANEL.BackColor = System.Drawing.Color.DarkGray;
            this.AUTO_ADD_PANEL.Controls.Add(this.REFRESH_BUTTON);
            this.AUTO_ADD_PANEL.Controls.Add(this.AUTO_ADD_LABEL);
            this.AUTO_ADD_PANEL.Location = new System.Drawing.Point(258, 81);
            this.AUTO_ADD_PANEL.Name = "AUTO_ADD_PANEL";
            this.AUTO_ADD_PANEL.Size = new System.Drawing.Size(353, 72);
            this.AUTO_ADD_PANEL.TabIndex = 0;
            this.AUTO_ADD_PANEL.Click += new System.EventHandler(this.AUTO_ADD_PANEL_Click);
            this.AUTO_ADD_PANEL.MouseEnter += new System.EventHandler(this.AUTO_ADD_PANEL_MouseEnter);
            this.AUTO_ADD_PANEL.MouseLeave += new System.EventHandler(this.AUTO_ADD_PANEL_MouseLeave);
            // 
            // REFRESH_BUTTON
            // 
            this.REFRESH_BUTTON.BackColor = System.Drawing.Color.DarkGray;
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
            this.REFRESH_BUTTON.MouseEnter += new System.EventHandler(this.AUTO_ADD_PANEL_MouseEnter);
            this.REFRESH_BUTTON.MouseLeave += new System.EventHandler(this.AUTO_ADD_PANEL_MouseLeave);
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
            this.AUTO_ADD_LABEL.MouseEnter += new System.EventHandler(this.AUTO_ADD_PANEL_MouseEnter);
            this.AUTO_ADD_LABEL.MouseLeave += new System.EventHandler(this.AUTO_ADD_PANEL_MouseLeave);
            // 
            // MANUAL_ADD_PANEL
            // 
            this.MANUAL_ADD_PANEL.BackColor = System.Drawing.Color.DarkGray;
            this.MANUAL_ADD_PANEL.Controls.Add(this.MANUALY_ADD_LABEL);
            this.MANUAL_ADD_PANEL.Location = new System.Drawing.Point(297, 226);
            this.MANUAL_ADD_PANEL.Name = "MANUAL_ADD_PANEL";
            this.MANUAL_ADD_PANEL.Size = new System.Drawing.Size(273, 53);
            this.MANUAL_ADD_PANEL.TabIndex = 1;
            this.MANUAL_ADD_PANEL.Click += new System.EventHandler(this.MANUAL_ADD_PANEL_Click);
            this.MANUAL_ADD_PANEL.MouseEnter += new System.EventHandler(this.MANUAL_ADD_PANEL_MouseEnter);
            this.MANUAL_ADD_PANEL.MouseLeave += new System.EventHandler(this.MANUAL_ADD_PANEL_MouseLeave);
            // 
            // MANUALY_ADD_LABEL
            // 
            this.MANUALY_ADD_LABEL.AutoSize = true;
            this.MANUALY_ADD_LABEL.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MANUALY_ADD_LABEL.ForeColor = System.Drawing.Color.White;
            this.MANUALY_ADD_LABEL.Location = new System.Drawing.Point(15, 17);
            this.MANUALY_ADD_LABEL.Name = "MANUALY_ADD_LABEL";
            this.MANUALY_ADD_LABEL.Size = new System.Drawing.Size(236, 23);
            this.MANUALY_ADD_LABEL.TabIndex = 1;
            this.MANUALY_ADD_LABEL.Text = "Add keyboard manually";
            this.MANUALY_ADD_LABEL.Click += new System.EventHandler(this.MANUAL_ADD_PANEL_Click);
            this.MANUALY_ADD_LABEL.MouseEnter += new System.EventHandler(this.MANUAL_ADD_PANEL_MouseEnter);
            this.MANUALY_ADD_LABEL.MouseLeave += new System.EventHandler(this.MANUAL_ADD_PANEL_MouseLeave);
            // 
            // CANCEL_PANEL
            // 
            this.CANCEL_PANEL.BackColor = System.Drawing.Color.DarkGray;
            this.CANCEL_PANEL.Controls.Add(this.CANCEL_LABEL);
            this.CANCEL_PANEL.Location = new System.Drawing.Point(358, 311);
            this.CANCEL_PANEL.Name = "CANCEL_PANEL";
            this.CANCEL_PANEL.Size = new System.Drawing.Size(138, 47);
            this.CANCEL_PANEL.TabIndex = 1;
            this.CANCEL_PANEL.Click += new System.EventHandler(this.CANCEL_PANEL_Click);
            this.CANCEL_PANEL.MouseEnter += new System.EventHandler(this.CANCEL_PANEL_MouseEnter);
            this.CANCEL_PANEL.MouseLeave += new System.EventHandler(this.CANCEL_PANEL_MouseLeave);
            // 
            // CANCEL_LABEL
            // 
            this.CANCEL_LABEL.AutoSize = true;
            this.CANCEL_LABEL.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANCEL_LABEL.ForeColor = System.Drawing.Color.White;
            this.CANCEL_LABEL.Location = new System.Drawing.Point(25, 12);
            this.CANCEL_LABEL.Name = "CANCEL_LABEL";
            this.CANCEL_LABEL.Size = new System.Drawing.Size(84, 26);
            this.CANCEL_LABEL.TabIndex = 2;
            this.CANCEL_LABEL.Text = "Cancel";
            this.CANCEL_LABEL.Click += new System.EventHandler(this.CANCEL_PANEL_Click);
            this.CANCEL_LABEL.MouseEnter += new System.EventHandler(this.CANCEL_PANEL_MouseEnter);
            this.CANCEL_LABEL.MouseLeave += new System.EventHandler(this.CANCEL_PANEL_MouseLeave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.CONNECTION_PROBLEMS_BUTTON);
            this.panel4.Controls.Add(this.CANCEL_PANEL);
            this.panel4.Controls.Add(this.AUTO_ADD_PANEL);
            this.panel4.Controls.Add(this.MANUAL_ADD_PANEL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(857, 508);
            this.panel4.TabIndex = 2;
            // 
            // CONNECTION_PROBLEMS_BUTTON
            // 
            this.CONNECTION_PROBLEMS_BUTTON.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.CONNECTION_PROBLEMS_BUTTON.FlatAppearance.BorderSize = 0;
            this.CONNECTION_PROBLEMS_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CONNECTION_PROBLEMS_BUTTON.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CONNECTION_PROBLEMS_BUTTON.ForeColor = System.Drawing.Color.White;
            this.CONNECTION_PROBLEMS_BUTTON.Location = new System.Drawing.Point(348, 170);
            this.CONNECTION_PROBLEMS_BUTTON.Name = "CONNECTION_PROBLEMS_BUTTON";
            this.CONNECTION_PROBLEMS_BUTTON.Size = new System.Drawing.Size(167, 38);
            this.CONNECTION_PROBLEMS_BUTTON.TabIndex = 5;
            this.CONNECTION_PROBLEMS_BUTTON.Text = "Connection problems?";
            this.CONNECTION_PROBLEMS_BUTTON.UseVisualStyleBackColor = false;
            this.CONNECTION_PROBLEMS_BUTTON.Click += new System.EventHandler(this.CONNECTION_PROBLEMS_BUTTON_Click);
            // 
            // BACKGROUND_SCANNER
            // 
            this.BACKGROUND_SCANNER.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BACKGROUND_SCANNER_DoWork);
            // 
            // AUTO_ADD_HOVER_TIMER
            // 
            this.AUTO_ADD_HOVER_TIMER.Interval = 50;
            this.AUTO_ADD_HOVER_TIMER.Tick += new System.EventHandler(this.AUTO_ADD_HOVER_TIMER_Tick);
            // 
            // MANUAL_ADD_HOVER_TIMER
            // 
            this.MANUAL_ADD_HOVER_TIMER.Interval = 50;
            this.MANUAL_ADD_HOVER_TIMER.Tick += new System.EventHandler(this.MANUAL_ADD_HOVER_TIMER_Tick);
            // 
            // CANCEL_HOVER_TIMER
            // 
            this.CANCEL_HOVER_TIMER.Interval = 50;
            this.CANCEL_HOVER_TIMER.Tick += new System.EventHandler(this.CANCEL_HOVER_TIMER_Tick);
            // 
            // addKeyboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
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
        private System.Windows.Forms.Timer AUTO_ADD_HOVER_TIMER;
        private System.Windows.Forms.Timer MANUAL_ADD_HOVER_TIMER;
        private System.Windows.Forms.Timer CANCEL_HOVER_TIMER;
        private System.Windows.Forms.Button CONNECTION_PROBLEMS_BUTTON;
    }
}
