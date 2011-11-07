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
            this.estimatedByLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.mPointsCombox = new System.Windows.Forms.ComboBox();
            this.mEsitmatedByComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // estimatedByLabel
            // 
            this.estimatedByLabel.AutoSize = true;
            this.estimatedByLabel.Location = new System.Drawing.Point(7, 34);
            this.estimatedByLabel.Name = "estimatedByLabel";
            this.estimatedByLabel.Size = new System.Drawing.Size(77, 12);
            this.estimatedByLabel.TabIndex = 0;
            this.estimatedByLabel.Text = "estimated by";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AllowDrop = true;
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Location = new System.Drawing.Point(7, 3);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(41, 12);
            this.pointsLabel.TabIndex = 2;
            this.pointsLabel.Text = "points";
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
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.estimatedByLabel);
            this.Name = "AssignPointsControl";
            this.Size = new System.Drawing.Size(182, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label estimatedByLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.ComboBox mPointsCombox;
        private System.Windows.Forms.ComboBox mEsitmatedByComboBox;
    }
}
