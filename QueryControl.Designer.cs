namespace TeamView
{
    partial class QueryControl
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
            this.mDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.mVersionTextBox = new System.Windows.Forms.TextBox();
            this.mBugNumTextBox = new System.Windows.Forms.TextBox();
            this.mVersionNumber = new System.Windows.Forms.Label();
            this.mBugNumberLabel = new System.Windows.Forms.Label();
            this.mTipLabel = new System.Windows.Forms.Label();
            this.mStateLabel = new System.Windows.Forms.Label();
            this.mDealManlabel = new System.Windows.Forms.Label();
            this.mQueryGroupBox = new System.Windows.Forms.GroupBox();
            this.mPriorityLabel = new System.Windows.Forms.Label();
            this.mProgrammerCheckList = new System.Windows.Forms.CheckedListBox();
            this.mDescriptionLabel = new System.Windows.Forms.Label();
            this.mQueryButton = new System.Windows.Forms.Button();
            this.mSatesCheckList = new System.Windows.Forms.CheckedListBox();
            this.mPrioirtyCheckList = new System.Windows.Forms.CheckedListBox();
            this.mQueryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDescriptionTextBox
            // 
            this.mDescriptionTextBox.Location = new System.Drawing.Point(445, 75);
            this.mDescriptionTextBox.Name = "mDescriptionTextBox";
            this.mDescriptionTextBox.Size = new System.Drawing.Size(124, 21);
            this.mDescriptionTextBox.TabIndex = 11;
            // 
            // mVersionTextBox
            // 
            this.mVersionTextBox.Location = new System.Drawing.Point(445, 47);
            this.mVersionTextBox.Name = "mVersionTextBox";
            this.mVersionTextBox.Size = new System.Drawing.Size(100, 21);
            this.mVersionTextBox.TabIndex = 9;
            // 
            // mBugNumTextBox
            // 
            this.mBugNumTextBox.Location = new System.Drawing.Point(445, 20);
            this.mBugNumTextBox.Name = "mBugNumTextBox";
            this.mBugNumTextBox.Size = new System.Drawing.Size(100, 21);
            this.mBugNumTextBox.TabIndex = 7;
            // 
            // mVersionNumber
            // 
            this.mVersionNumber.AutoSize = true;
            this.mVersionNumber.Location = new System.Drawing.Point(383, 50);
            this.mVersionNumber.Name = "mVersionNumber";
            this.mVersionNumber.Size = new System.Drawing.Size(53, 12);
            this.mVersionNumber.TabIndex = 8;
            this.mVersionNumber.Text = "Version:";
            // 
            // mBugNumberLabel
            // 
            this.mBugNumberLabel.AutoSize = true;
            this.mBugNumberLabel.Location = new System.Drawing.Point(383, 21);
            this.mBugNumberLabel.Name = "mBugNumberLabel";
            this.mBugNumberLabel.Size = new System.Drawing.Size(53, 12);
            this.mBugNumberLabel.TabIndex = 6;
            this.mBugNumberLabel.Text = "Bug Num:";
            // 
            // mTipLabel
            // 
            this.mTipLabel.AutoSize = true;
            this.mTipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTipLabel.ForeColor = System.Drawing.Color.Maroon;
            this.mTipLabel.Location = new System.Drawing.Point(421, 105);
            this.mTipLabel.Name = "mTipLabel";
            this.mTipLabel.Size = new System.Drawing.Size(0, 15);
            this.mTipLabel.TabIndex = 1;
            // 
            // mStateLabel
            // 
            this.mStateLabel.AutoSize = true;
            this.mStateLabel.Location = new System.Drawing.Point(126, 17);
            this.mStateLabel.Name = "mStateLabel";
            this.mStateLabel.Size = new System.Drawing.Size(41, 12);
            this.mStateLabel.TabIndex = 2;
            this.mStateLabel.Text = "State:";
            // 
            // mDealManlabel
            // 
            this.mDealManlabel.AutoSize = true;
            this.mDealManlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mDealManlabel.Location = new System.Drawing.Point(6, 17);
            this.mDealManlabel.Name = "mDealManlabel";
            this.mDealManlabel.Size = new System.Drawing.Size(65, 12);
            this.mDealManlabel.TabIndex = 0;
            this.mDealManlabel.Text = "Programer:";
            // 
            // mQueryGroupBox
            // 
            this.mQueryGroupBox.Controls.Add(this.mPrioirtyCheckList);
            this.mQueryGroupBox.Controls.Add(this.mSatesCheckList);
            this.mQueryGroupBox.Controls.Add(this.mPriorityLabel);
            this.mQueryGroupBox.Controls.Add(this.mProgrammerCheckList);
            this.mQueryGroupBox.Controls.Add(this.mDescriptionTextBox);
            this.mQueryGroupBox.Controls.Add(this.mDescriptionLabel);
            this.mQueryGroupBox.Controls.Add(this.mVersionTextBox);
            this.mQueryGroupBox.Controls.Add(this.mBugNumTextBox);
            this.mQueryGroupBox.Controls.Add(this.mVersionNumber);
            this.mQueryGroupBox.Controls.Add(this.mBugNumberLabel);
            this.mQueryGroupBox.Controls.Add(this.mStateLabel);
            this.mQueryGroupBox.Controls.Add(this.mDealManlabel);
            this.mQueryGroupBox.Controls.Add(this.mQueryButton);
            this.mQueryGroupBox.Location = new System.Drawing.Point(3, 3);
            this.mQueryGroupBox.Name = "mQueryGroupBox";
            this.mQueryGroupBox.Size = new System.Drawing.Size(659, 119);
            this.mQueryGroupBox.TabIndex = 2;
            this.mQueryGroupBox.TabStop = false;
            this.mQueryGroupBox.Text = "Query Condition";
            // 
            // mPriorityLabel
            // 
            this.mPriorityLabel.AutoSize = true;
            this.mPriorityLabel.Location = new System.Drawing.Point(244, 17);
            this.mPriorityLabel.Name = "mPriorityLabel";
            this.mPriorityLabel.Size = new System.Drawing.Size(59, 12);
            this.mPriorityLabel.TabIndex = 4;
            this.mPriorityLabel.Text = "Priority:";
            // 
            // mProgrammerCheckList
            // 
            this.mProgrammerCheckList.FormattingEnabled = true;
            this.mProgrammerCheckList.Location = new System.Drawing.Point(8, 35);
            this.mProgrammerCheckList.Name = "mProgrammerCheckList";
            this.mProgrammerCheckList.Size = new System.Drawing.Size(103, 68);
            this.mProgrammerCheckList.TabIndex = 1;
            // 
            // mDescriptionLabel
            // 
            this.mDescriptionLabel.AutoSize = true;
            this.mDescriptionLabel.Location = new System.Drawing.Point(359, 78);
            this.mDescriptionLabel.Name = "mDescriptionLabel";
            this.mDescriptionLabel.Size = new System.Drawing.Size(77, 12);
            this.mDescriptionLabel.TabIndex = 10;
            this.mDescriptionLabel.Text = "Description:";
            // 
            // mQueryButton
            // 
            this.mQueryButton.Location = new System.Drawing.Point(575, 82);
            this.mQueryButton.Name = "mQueryButton";
            this.mQueryButton.Size = new System.Drawing.Size(75, 21);
            this.mQueryButton.TabIndex = 12;
            this.mQueryButton.Text = "Query";
            this.mQueryButton.UseVisualStyleBackColor = true;
            this.mQueryButton.Click += new System.EventHandler(this.mQueryButton_Click);
            // 
            // mSatesCheckList
            // 
            this.mSatesCheckList.FormattingEnabled = true;
            this.mSatesCheckList.Location = new System.Drawing.Point(128, 35);
            this.mSatesCheckList.Name = "mSatesCheckList";
            this.mSatesCheckList.Size = new System.Drawing.Size(103, 68);
            this.mSatesCheckList.TabIndex = 3;
            this.mSatesCheckList.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // mPrioirtyCheckList
            // 
            this.mPrioirtyCheckList.FormattingEnabled = true;
            this.mPrioirtyCheckList.Location = new System.Drawing.Point(246, 35);
            this.mPrioirtyCheckList.Name = "mPrioirtyCheckList";
            this.mPrioirtyCheckList.Size = new System.Drawing.Size(103, 68);
            this.mPrioirtyCheckList.TabIndex = 5;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTipLabel);
            this.Controls.Add(this.mQueryGroupBox);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(670, 122);
            this.mQueryGroupBox.ResumeLayout(false);
            this.mQueryGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mDescriptionTextBox;
        private System.Windows.Forms.TextBox mVersionTextBox;
        private System.Windows.Forms.TextBox mBugNumTextBox;
        private System.Windows.Forms.Label mVersionNumber;
        private System.Windows.Forms.Label mBugNumberLabel;
        private System.Windows.Forms.Label mTipLabel;
        private System.Windows.Forms.Label mStateLabel;
        private System.Windows.Forms.Label mDealManlabel;
        private System.Windows.Forms.GroupBox mQueryGroupBox;
        private System.Windows.Forms.Label mDescriptionLabel;
        private System.Windows.Forms.Button mQueryButton;
        private System.Windows.Forms.CheckedListBox mProgrammerCheckList;
        private System.Windows.Forms.Label mPriorityLabel;
        private System.Windows.Forms.CheckedListBox mSatesCheckList;
        private System.Windows.Forms.CheckedListBox mPrioirtyCheckList;
    }
}
