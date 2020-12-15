namespace Newt
{
    partial class SaveForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_Action = new System.Windows.Forms.Label();
            this.Label_Saving = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Action
            // 
            this.Label_Action.Location = new System.Drawing.Point(12, 35);
            this.Label_Action.Name = "Label_Action";
            this.Label_Action.Size = new System.Drawing.Size(232, 17);
            this.Label_Action.TabIndex = 0;
            this.Label_Action.Text = "Action being taken";
            this.Label_Action.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label_Saving
            // 
            this.Label_Saving.AutoSize = true;
            this.Label_Saving.Location = new System.Drawing.Point(104, 9);
            this.Label_Saving.Name = "Label_Saving";
            this.Label_Saving.Size = new System.Drawing.Size(49, 13);
            this.Label_Saving.TabIndex = 1;
            this.Label_Saving.Text = "Saving...";
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 57);
            this.Controls.Add(this.Label_Saving);
            this.Controls.Add(this.Label_Action);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "SaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tileset progress";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Action;
        private System.Windows.Forms.Label Label_Saving;
    }
}