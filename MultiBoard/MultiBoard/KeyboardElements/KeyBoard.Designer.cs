namespace MultiBoard
{
    partial class KeyBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyBoard));
            this.TOP_PANEL = new System.Windows.Forms.Panel();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.LEFT_TOP_ICON = new System.Windows.Forms.PictureBox();
            this.BOTTEM_PANEL = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ADD_ITEM_P = new System.Windows.Forms.PictureBox();
            this.LEFT_PANEL = new System.Windows.Forms.Panel();
            this.KEYLIST_PANEL = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SEARCH_BUTTON = new System.Windows.Forms.Button();
            this.SEARCH_TEXTBOC = new System.Windows.Forms.TextBox();
            this.TOP_PANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LEFT_TOP_ICON)).BeginInit();
            this.BOTTEM_PANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADD_ITEM_P)).BeginInit();
            this.LEFT_PANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // TOP_PANEL
            // 
            this.TOP_PANEL.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TOP_PANEL.Controls.Add(this.SEARCH_BUTTON);
            this.TOP_PANEL.Controls.Add(this.NAME_LABEL);
            this.TOP_PANEL.Controls.Add(this.LEFT_TOP_ICON);
            this.TOP_PANEL.Controls.Add(this.SEARCH_TEXTBOC);
            this.TOP_PANEL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOP_PANEL.Location = new System.Drawing.Point(0, 0);
            this.TOP_PANEL.Name = "TOP_PANEL";
            this.TOP_PANEL.Size = new System.Drawing.Size(198, 35);
            this.TOP_PANEL.TabIndex = 0;
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.ForeColor = System.Drawing.Color.White;
            this.NAME_LABEL.Location = new System.Drawing.Point(41, 13);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(106, 13);
            this.NAME_LABEL.TabIndex = 1;
            this.NAME_LABEL.Text = "[KEYBOARD NAME]";
            // 
            // LEFT_TOP_ICON
            // 
            this.LEFT_TOP_ICON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LEFT_TOP_ICON.BackgroundImage")));
            this.LEFT_TOP_ICON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LEFT_TOP_ICON.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT_TOP_ICON.Location = new System.Drawing.Point(0, 0);
            this.LEFT_TOP_ICON.Name = "LEFT_TOP_ICON";
            this.LEFT_TOP_ICON.Size = new System.Drawing.Size(35, 35);
            this.LEFT_TOP_ICON.TabIndex = 0;
            this.LEFT_TOP_ICON.TabStop = false;
            // 
            // BOTTEM_PANEL
            // 
            this.BOTTEM_PANEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(163)))), ((int)(((byte)(17)))));
            this.BOTTEM_PANEL.Controls.Add(this.label1);
            this.BOTTEM_PANEL.Controls.Add(this.ADD_ITEM_P);
            this.BOTTEM_PANEL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BOTTEM_PANEL.Location = new System.Drawing.Point(0, 471);
            this.BOTTEM_PANEL.Name = "BOTTEM_PANEL";
            this.BOTTEM_PANEL.Size = new System.Drawing.Size(198, 35);
            this.BOTTEM_PANEL.TabIndex = 1;
            this.BOTTEM_PANEL.Click += new System.EventHandler(this.addNewKeyClicked);
            this.BOTTEM_PANEL.MouseEnter += new System.EventHandler(this.BOTTEM_PANEL_MouseEnter);
            this.BOTTEM_PANEL.MouseLeave += new System.EventHandler(this.BOTTEM_PANEL_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add new key";
            this.label1.Click += new System.EventHandler(this.addNewKeyClicked);
            this.label1.MouseEnter += new System.EventHandler(this.BOTTEM_PANEL_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.BOTTEM_PANEL_MouseLeave);
            // 
            // ADD_ITEM_P
            // 
            this.ADD_ITEM_P.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ADD_ITEM_P.BackgroundImage")));
            this.ADD_ITEM_P.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ADD_ITEM_P.Dock = System.Windows.Forms.DockStyle.Left;
            this.ADD_ITEM_P.Location = new System.Drawing.Point(0, 0);
            this.ADD_ITEM_P.Name = "ADD_ITEM_P";
            this.ADD_ITEM_P.Size = new System.Drawing.Size(35, 35);
            this.ADD_ITEM_P.TabIndex = 1;
            this.ADD_ITEM_P.TabStop = false;
            this.ADD_ITEM_P.Click += new System.EventHandler(this.addNewKeyClicked);
            this.ADD_ITEM_P.MouseEnter += new System.EventHandler(this.BOTTEM_PANEL_MouseEnter);
            this.ADD_ITEM_P.MouseLeave += new System.EventHandler(this.BOTTEM_PANEL_MouseLeave);
            // 
            // LEFT_PANEL
            // 
            this.LEFT_PANEL.Controls.Add(this.KEYLIST_PANEL);
            this.LEFT_PANEL.Controls.Add(this.TOP_PANEL);
            this.LEFT_PANEL.Controls.Add(this.BOTTEM_PANEL);
            this.LEFT_PANEL.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT_PANEL.Location = new System.Drawing.Point(0, 0);
            this.LEFT_PANEL.Name = "LEFT_PANEL";
            this.LEFT_PANEL.Size = new System.Drawing.Size(198, 506);
            this.LEFT_PANEL.TabIndex = 3;
            // 
            // KEYLIST_PANEL
            // 
            this.KEYLIST_PANEL.AutoScroll = true;
            this.KEYLIST_PANEL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.KEYLIST_PANEL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("KEYLIST_PANEL.BackgroundImage")));
            this.KEYLIST_PANEL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.KEYLIST_PANEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KEYLIST_PANEL.Location = new System.Drawing.Point(0, 35);
            this.KEYLIST_PANEL.Margin = new System.Windows.Forms.Padding(0);
            this.KEYLIST_PANEL.Name = "KEYLIST_PANEL";
            this.KEYLIST_PANEL.Size = new System.Drawing.Size(198, 436);
            this.KEYLIST_PANEL.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SEARCH_BUTTON
            // 
            this.SEARCH_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SEARCH_BUTTON.BackgroundImage")));
            this.SEARCH_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SEARCH_BUTTON.FlatAppearance.BorderSize = 0;
            this.SEARCH_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SEARCH_BUTTON.Location = new System.Drawing.Point(163, 0);
            this.SEARCH_BUTTON.Name = "SEARCH_BUTTON";
            this.SEARCH_BUTTON.Size = new System.Drawing.Size(35, 35);
            this.SEARCH_BUTTON.TabIndex = 2;
            this.SEARCH_BUTTON.UseVisualStyleBackColor = true;
            this.SEARCH_BUTTON.Click += new System.EventHandler(this.SEARCH_BUTTON_Click);
            // 
            // SEARCH_TEXTBOC
            // 
            this.SEARCH_TEXTBOC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SEARCH_TEXTBOC.Location = new System.Drawing.Point(3, 6);
            this.SEARCH_TEXTBOC.Name = "SEARCH_TEXTBOC";
            this.SEARCH_TEXTBOC.Size = new System.Drawing.Size(154, 24);
            this.SEARCH_TEXTBOC.TabIndex = 3;
            this.SEARCH_TEXTBOC.Visible = false;
            this.SEARCH_TEXTBOC.TextChanged += new System.EventHandler(this.SEARCH_TEXTBOC_TextChanged);
            // 
            // KeyBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LEFT_PANEL);
            this.Name = "KeyBoard";
            this.Size = new System.Drawing.Size(854, 506);
            this.TOP_PANEL.ResumeLayout(false);
            this.TOP_PANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LEFT_TOP_ICON)).EndInit();
            this.BOTTEM_PANEL.ResumeLayout(false);
            this.BOTTEM_PANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADD_ITEM_P)).EndInit();
            this.LEFT_PANEL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TOP_PANEL;
        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.PictureBox LEFT_TOP_ICON;
        private System.Windows.Forms.Panel BOTTEM_PANEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ADD_ITEM_P;
        private System.Windows.Forms.Panel LEFT_PANEL;
        private System.Windows.Forms.Panel KEYLIST_PANEL;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button SEARCH_BUTTON;
        private System.Windows.Forms.TextBox SEARCH_TEXTBOC;
    }
}
