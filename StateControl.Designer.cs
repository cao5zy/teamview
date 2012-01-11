namespace TeamView
{
    partial class StateControl
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
            this.mStartButton = new System.Windows.Forms.Button();
            this.mAbortButton = new System.Windows.Forms.Button();
            this.mCompleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mStartButton
            // 
            this.mStartButton.Location = new System.Drawing.Point(3, 3);
            this.mStartButton.Name = "mStartButton";
            this.mStartButton.Size = new System.Drawing.Size(75, 23);
            this.mStartButton.TabIndex = 0;
            this.mStartButton.Text = "Start";
            this.mStartButton.UseVisualStyleBackColor = true;
            this.mStartButton.Click += new System.EventHandler(this.mStartButton_Click);
            // 
            // mAbortButton
            // 
            this.mAbortButton.Location = new System.Drawing.Point(3, 27);
            this.mAbortButton.Name = "mAbortButton";
            this.mAbortButton.Size = new System.Drawing.Size(75, 23);
            this.mAbortButton.TabIndex = 1;
            this.mAbortButton.Text = "Abort";
            this.mAbortButton.UseVisualStyleBackColor = true;
            this.mAbortButton.Click += new System.EventHandler(this.mAbortButton_Click);
            // 
            // mCompleteButton
            // 
            this.mCompleteButton.Location = new System.Drawing.Point(3, 52);
            this.mCompleteButton.Name = "mCompleteButton";
            this.mCompleteButton.Size = new System.Drawing.Size(75, 23);
            this.mCompleteButton.TabIndex = 2;
            this.mCompleteButton.Text = "Complete";
            this.mCompleteButton.UseVisualStyleBackColor = true;
            this.mCompleteButton.Click += new System.EventHandler(this.mCompleteButton_Click);
            // 
            // StateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mCompleteButton);
            this.Controls.Add(this.mAbortButton);
            this.Controls.Add(this.mStartButton);
            this.Name = "StateControl";
            this.Size = new System.Drawing.Size(81, 77);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mStartButton;
        private System.Windows.Forms.Button mAbortButton;
        private System.Windows.Forms.Button mCompleteButton;
    }
}
