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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyBoard));
            this.TOP_PANEL = new System.Windows.Forms.Panel();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BOTTEM_PANEL = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ADD_ITEM_P = new System.Windows.Forms.PictureBox();
            this.KEY_LIST = new System.Windows.Forms.ListView();
            this.LEFT_PANEL = new System.Windows.Forms.Panel();
            this.TOP_PANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.BOTTEM_PANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADD_ITEM_P)).BeginInit();
            this.LEFT_PANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // TOP_PANEL
            // 
            this.TOP_PANEL.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.TOP_PANEL.Controls.Add(this.NAME_LABEL);
            this.TOP_PANEL.Controls.Add(this.pictureBox1);
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
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            // 
            // KEY_LIST
            // 
            this.KEY_LIST.AutoArrange = false;
            this.KEY_LIST.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KEY_LIST.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KEY_LIST.Location = new System.Drawing.Point(0, 34);
            this.KEY_LIST.MultiSelect = false;
            this.KEY_LIST.Name = "KEY_LIST";
            this.KEY_LIST.ShowGroups = false;
            this.KEY_LIST.Size = new System.Drawing.Size(198, 436);
            this.KEY_LIST.TabIndex = 2;
            this.KEY_LIST.TileSize = new System.Drawing.Size(168, 60);
            this.KEY_LIST.UseCompatibleStateImageBehavior = false;
            this.KEY_LIST.View = System.Windows.Forms.View.List;
            this.KEY_LIST.SelectedIndexChanged += new System.EventHandler(this.KEY_LIST_SelectedIndexChanged);
            // 
            // LEFT_PANEL
            // 
            this.LEFT_PANEL.Controls.Add(this.KEY_LIST);
            this.LEFT_PANEL.Controls.Add(this.TOP_PANEL);
            this.LEFT_PANEL.Controls.Add(this.BOTTEM_PANEL);
            this.LEFT_PANEL.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT_PANEL.Location = new System.Drawing.Point(0, 0);
            this.LEFT_PANEL.Name = "LEFT_PANEL";
            this.LEFT_PANEL.Size = new System.Drawing.Size(198, 506);
            this.LEFT_PANEL.TabIndex = 3;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.BOTTEM_PANEL.ResumeLayout(false);
            this.BOTTEM_PANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ADD_ITEM_P)).EndInit();
            this.LEFT_PANEL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TOP_PANEL;
        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel BOTTEM_PANEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ADD_ITEM_P;
        private System.Windows.Forms.ListView KEY_LIST;
        private System.Windows.Forms.Panel LEFT_PANEL;
    }
}
