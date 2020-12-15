namespace Newt
{
    partial class ObjectControl
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
            this.PictureBox_Preview = new System.Windows.Forms.PictureBox();
            this.Label_ObjectName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox_Preview
            // 
            this.PictureBox_Preview.Location = new System.Drawing.Point(3, 3);
            this.PictureBox_Preview.Name = "PictureBox_Preview";
            this.PictureBox_Preview.Size = new System.Drawing.Size(100, 53);
            this.PictureBox_Preview.TabIndex = 0;
            this.PictureBox_Preview.TabStop = false;
            // 
            // Label_ObjectName
            // 
            this.Label_ObjectName.CausesValidation = false;
            this.Label_ObjectName.Location = new System.Drawing.Point(109, 3);
            this.Label_ObjectName.Name = "Label_ObjectName";
            this.Label_ObjectName.Size = new System.Drawing.Size(72, 53);
            this.Label_ObjectName.TabIndex = 1;
            this.Label_ObjectName.Text = "Object #";
            this.Label_ObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ObjectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.Controls.Add(this.Label_ObjectName);
            this.Controls.Add(this.PictureBox_Preview);
            this.Name = "ObjectControl";
            this.Size = new System.Drawing.Size(189, 56);
            this.MouseEnter += new System.EventHandler(this.ObjectControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ObjectControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Preview;
        private System.Windows.Forms.Label Label_ObjectName;
    }
}
