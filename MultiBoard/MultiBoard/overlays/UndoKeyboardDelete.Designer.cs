namespace MultiBoard.overlays
{
    partial class UndoKeyboardDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UndoKeyboardDelete));
            this.UNDO_BUTTON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UNDO_BUTTON
            // 
            this.UNDO_BUTTON.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UNDO_BUTTON.BackgroundImage")));
            this.UNDO_BUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.UNDO_BUTTON.Dock = System.Windows.Forms.DockStyle.Right;
            this.UNDO_BUTTON.FlatAppearance.BorderSize = 0;
            this.UNDO_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UNDO_BUTTON.Location = new System.Drawing.Point(171, 0);
            this.UNDO_BUTTON.Name = "UNDO_BUTTON";
            this.UNDO_BUTTON.Size = new System.Drawing.Size(32, 32);
            this.UNDO_BUTTON.TabIndex = 0;
            this.UNDO_BUTTON.UseVisualStyleBackColor = true;
            this.UNDO_BUTTON.Click += new System.EventHandler(this.UNDO_BUTTON_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Undo keyboard delete";
            // 
            // UndoKeyboardDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UNDO_BUTTON);
            this.Name = "UndoKeyboardDelete";
            this.Size = new System.Drawing.Size(203, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UNDO_BUTTON;
        private System.Windows.Forms.Label label1;
    }
}
