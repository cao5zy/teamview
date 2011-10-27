namespace BugInfoManagement
{
    partial class AssignPointsControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mPointsCombox = new System.Windows.Forms.ComboBox();
            this.mEsitmatedByComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "estimated by";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "points";
            // 
            // mPointsCombox
            // 
            this.mPointsCombox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mPointsCombox.FormattingEnabled = true;
            this.mPointsCombox.Location = new System.Drawing.Point(102, 3);
            this.mPointsCombox.Name = "mPointsCombox";
            this.mPointsCombox.Size = new System.Drawing.Size(80, 20);
            this.mPointsCombox.TabIndex = 4;
            // 
            // mEsitmatedByComboBox
            // 
            this.mEsitmatedByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mEsitmatedByComboBox.FormattingEnabled = true;
            this.mEsitmatedByComboBox.Location = new System.Drawing.Point(102, 34);
            this.mEsitmatedByComboBox.Name = "mEsitmatedByComboBox";
            this.mEsitmatedByComboBox.Size = new System.Drawing.Size(80, 20);
            this.mEsitmatedByComboBox.TabIndex = 5;
            // 
            // AssignPointsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mEsitmatedByComboBox);
            this.Controls.Add(this.mPointsCombox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "AssignPointsControl";
            this.Size = new System.Drawing.Size(182, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mPointsCombox;
        private System.Windows.Forms.ComboBox mEsitmatedByComboBox;
    }
}
