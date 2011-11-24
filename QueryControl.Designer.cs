namespace BugInfoManagement
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
            this.mBugStatesComboBox = new System.Windows.Forms.ComboBox();
            this.mStateLabel = new System.Windows.Forms.Label();
            this.mDealManlabel = new System.Windows.Forms.Label();
            this.mQueryGroupBox = new System.Windows.Forms.GroupBox();
            this.mPriorityCombo = new System.Windows.Forms.ComboBox();
            this.mPriorityLabel = new System.Windows.Forms.Label();
            this.mProgrammerCheckList = new System.Windows.Forms.CheckedListBox();
            this.mDescriptionLabel = new System.Windows.Forms.Label();
            this.mQueryButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.mQueryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mDescriptionTextBox
            // 
            this.mDescriptionTextBox.Location = new System.Drawing.Point(520, 26);
            this.mDescriptionTextBox.Name = "mDescriptionTextBox";
            this.mDescriptionTextBox.Size = new System.Drawing.Size(158, 21);
            this.mDescriptionTextBox.TabIndex = 35;
            // 
            // mVersionTextBox
            // 
            this.mVersionTextBox.Location = new System.Drawing.Point(305, 69);
            this.mVersionTextBox.Name = "mVersionTextBox";
            this.mVersionTextBox.Size = new System.Drawing.Size(100, 21);
            this.mVersionTextBox.TabIndex = 33;
            // 
            // mBugNumTextBox
            // 
            this.mBugNumTextBox.Location = new System.Drawing.Point(305, 26);
            this.mBugNumTextBox.Name = "mBugNumTextBox";
            this.mBugNumTextBox.Size = new System.Drawing.Size(100, 21);
            this.mBugNumTextBox.TabIndex = 32;
            // 
            // mVersionNumber
            // 
            this.mVersionNumber.AutoSize = true;
            this.mVersionNumber.Location = new System.Drawing.Point(243, 72);
            this.mVersionNumber.Name = "mVersionNumber";
            this.mVersionNumber.Size = new System.Drawing.Size(53, 12);
            this.mVersionNumber.TabIndex = 31;
            this.mVersionNumber.Text = "Version:";
            // 
            // mBugNumberLabel
            // 
            this.mBugNumberLabel.AutoSize = true;
            this.mBugNumberLabel.Location = new System.Drawing.Point(243, 27);
            this.mBugNumberLabel.Name = "mBugNumberLabel";
            this.mBugNumberLabel.Size = new System.Drawing.Size(53, 12);
            this.mBugNumberLabel.TabIndex = 30;
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
            this.mTipLabel.TabIndex = 30;
            // 
            // mBugStatesComboBox
            // 
            this.mBugStatesComboBox.DisplayMember = "StateInfo";
            this.mBugStatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mBugStatesComboBox.FormattingEnabled = true;
            this.mBugStatesComboBox.Location = new System.Drawing.Point(520, 70);
            this.mBugStatesComboBox.Name = "mBugStatesComboBox";
            this.mBugStatesComboBox.Size = new System.Drawing.Size(124, 20);
            this.mBugStatesComboBox.TabIndex = 29;
            this.mBugStatesComboBox.ValueMember = "StateInfo";
            // 
            // mStateLabel
            // 
            this.mStateLabel.AutoSize = true;
            this.mStateLabel.Location = new System.Drawing.Point(448, 73);
            this.mStateLabel.Name = "mStateLabel";
            this.mStateLabel.Size = new System.Drawing.Size(41, 12);
            this.mStateLabel.TabIndex = 28;
            this.mStateLabel.Text = "State:";
            // 
            // mDealManlabel
            // 
            this.mDealManlabel.AutoSize = true;
            this.mDealManlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mDealManlabel.Location = new System.Drawing.Point(5, 26);
            this.mDealManlabel.Name = "mDealManlabel";
            this.mDealManlabel.Size = new System.Drawing.Size(65, 12);
            this.mDealManlabel.TabIndex = 16;
            this.mDealManlabel.Text = "Programer:";
            // 
            // mQueryGroupBox
            // 
            this.mQueryGroupBox.Controls.Add(this.mPriorityCombo);
            this.mQueryGroupBox.Controls.Add(this.mPriorityLabel);
            this.mQueryGroupBox.Controls.Add(this.mProgrammerCheckList);
            this.mQueryGroupBox.Controls.Add(this.mDescriptionTextBox);
            this.mQueryGroupBox.Controls.Add(this.mDescriptionLabel);
            this.mQueryGroupBox.Controls.Add(this.mVersionTextBox);
            this.mQueryGroupBox.Controls.Add(this.mBugNumTextBox);
            this.mQueryGroupBox.Controls.Add(this.mVersionNumber);
            this.mQueryGroupBox.Controls.Add(this.mBugNumberLabel);
            this.mQueryGroupBox.Controls.Add(this.mBugStatesComboBox);
            this.mQueryGroupBox.Controls.Add(this.mStateLabel);
            this.mQueryGroupBox.Controls.Add(this.mDealManlabel);
            this.mQueryGroupBox.Controls.Add(this.mQueryButton);
            this.mQueryGroupBox.Location = new System.Drawing.Point(3, 3);
            this.mQueryGroupBox.Name = "mQueryGroupBox";
            this.mQueryGroupBox.Size = new System.Drawing.Size(829, 117);
            this.mQueryGroupBox.TabIndex = 31;
            this.mQueryGroupBox.TabStop = false;
            this.mQueryGroupBox.Text = "Query Condition";
            // 
            // mPriorityCombo
            // 
            this.mPriorityCombo.FormattingEnabled = true;
            this.mPriorityCombo.Items.AddRange(new object[] {
            "",
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.mPriorityCombo.Location = new System.Drawing.Point(777, 27);
            this.mPriorityCombo.Name = "mPriorityCombo";
            this.mPriorityCombo.Size = new System.Drawing.Size(42, 20);
            this.mPriorityCombo.TabIndex = 38;
            // 
            // mPriorityLabel
            // 
            this.mPriorityLabel.AutoSize = true;
            this.mPriorityLabel.Location = new System.Drawing.Point(712, 29);
            this.mPriorityLabel.Name = "mPriorityLabel";
            this.mPriorityLabel.Size = new System.Drawing.Size(59, 12);
            this.mPriorityLabel.TabIndex = 37;
            this.mPriorityLabel.Text = "Priority:";
            // 
            // mProgrammerCheckList
            // 
            this.mProgrammerCheckList.FormattingEnabled = true;
            this.mProgrammerCheckList.Location = new System.Drawing.Point(76, 26);
            this.mProgrammerCheckList.Name = "mProgrammerCheckList";
            this.mProgrammerCheckList.Size = new System.Drawing.Size(151, 68);
            this.mProgrammerCheckList.TabIndex = 36;
            // 
            // mDescriptionLabel
            // 
            this.mDescriptionLabel.AutoSize = true;
            this.mDescriptionLabel.Location = new System.Drawing.Point(448, 30);
            this.mDescriptionLabel.Name = "mDescriptionLabel";
            this.mDescriptionLabel.Size = new System.Drawing.Size(77, 12);
            this.mDescriptionLabel.TabIndex = 34;
            this.mDescriptionLabel.Text = "Description:";
            // 
            // mQueryButton
            // 
            this.mQueryButton.Location = new System.Drawing.Point(744, 73);
            this.mQueryButton.Name = "mQueryButton";
            this.mQueryButton.Size = new System.Drawing.Size(75, 29);
            this.mQueryButton.TabIndex = 19;
            this.mQueryButton.Text = "Query";
            this.mQueryButton.UseVisualStyleBackColor = true;
            this.mQueryButton.Click += new System.EventHandler(this.mQueryButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(421, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 29;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mTipLabel);
            this.Controls.Add(this.mQueryGroupBox);
            this.Controls.Add(this.label5);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(835, 122);
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
        private System.Windows.Forms.ComboBox mBugStatesComboBox;
        private System.Windows.Forms.Label mStateLabel;
        private System.Windows.Forms.Label mDealManlabel;
        private System.Windows.Forms.GroupBox mQueryGroupBox;
        private System.Windows.Forms.Label mDescriptionLabel;
        private System.Windows.Forms.Button mQueryButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox mProgrammerCheckList;
        private System.Windows.Forms.Label mPriorityLabel;
        private System.Windows.Forms.ComboBox mPriorityCombo;
    }
}
