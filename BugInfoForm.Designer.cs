﻿using TeamView.Common;
namespace TeamView
{
    partial class BugInfoForm
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
            this.components = new System.ComponentModel.Container();
            this.mVersionTextBox = new System.Windows.Forms.TextBox();
            this.mDataSource = new System.Windows.Forms.BindingSource(this.components);
            this.mBugNumTextBox = new System.Windows.Forms.TextBox();
            this.mDoAddButton = new System.Windows.Forms.Button();
            this.mDiscriptionTextBox = new System.Windows.Forms.TextBox();
            this.BIVersionNum = new System.Windows.Forms.Label();
            this.BIBugNum = new System.Windows.Forms.Label();
            this.BIBugDealMan = new System.Windows.Forms.Label();
            this.BIBugDescription = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mQuitButton = new System.Windows.Forms.Button();
            this.mBaseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.mDealManTextBox = new System.Windows.Forms.TextBox();
            this.mHardLevelTextBox = new System.Windows.Forms.TextBox();
            this.BIAssessment = new System.Windows.Forms.Label();
            this.mPriorityCombo = new System.Windows.Forms.ComboBox();
            this.BIPriority = new System.Windows.Forms.Label();
            this.mSizeTextBox = new System.Windows.Forms.TextBox();
            this.BIPreTakeTime = new System.Windows.Forms.Label();
            this.mFiredTextBox = new System.Windows.Forms.TextBox();
            this.BITakeTime = new System.Windows.Forms.Label();
            this.mCreatedManBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mDealMenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mEditorPanel = new System.Windows.Forms.Panel();
            this.bugInfoSet = new TeamView.BugInfoSet();
            this.mStateControl = new TeamView.StateControl();
            ((System.ComponentModel.ISupportInitialize)(this.mDataSource)).BeginInit();
            this.mBaseInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCreatedManBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDealMenBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bugInfoSet)).BeginInit();
            this.SuspendLayout();
            // 
            // mVersionTextBox
            // 
            this.mVersionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "version", true));
            this.mVersionTextBox.Location = new System.Drawing.Point(86, 14);
            this.mVersionTextBox.Name = "mVersionTextBox";
            this.mVersionTextBox.Size = new System.Drawing.Size(84, 21);
            this.mVersionTextBox.TabIndex = 1;
            // 
            // mDataSource
            // 
            this.mDataSource.DataSource = typeof(TeamView.Common.Entity.BugInfoEntity1);
            // 
            // mBugNumTextBox
            // 
            this.mBugNumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "bugNum", true));
            this.mBugNumTextBox.Location = new System.Drawing.Point(86, 44);
            this.mBugNumTextBox.Name = "mBugNumTextBox";
            this.mBugNumTextBox.ReadOnly = true;
            this.mBugNumTextBox.Size = new System.Drawing.Size(84, 21);
            this.mBugNumTextBox.TabIndex = 3;
            // 
            // mDoAddButton
            // 
            this.mDoAddButton.Location = new System.Drawing.Point(741, 140);
            this.mDoAddButton.Name = "mDoAddButton";
            this.mDoAddButton.Size = new System.Drawing.Size(75, 23);
            this.mDoAddButton.TabIndex = 8;
            this.mDoAddButton.Text = "Save";
            this.mDoAddButton.UseVisualStyleBackColor = true;
            this.mDoAddButton.Click += new System.EventHandler(this.mDoAddButton_Click);
            // 
            // mDiscriptionTextBox
            // 
            this.mDiscriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "Description", true));
            this.mDiscriptionTextBox.Location = new System.Drawing.Point(86, 124);
            this.mDiscriptionTextBox.Multiline = true;
            this.mDiscriptionTextBox.Name = "mDiscriptionTextBox";
            this.mDiscriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mDiscriptionTextBox.Size = new System.Drawing.Size(649, 39);
            this.mDiscriptionTextBox.TabIndex = 6;
            // 
            // BIVersionNum
            // 
            this.BIVersionNum.AutoSize = true;
            this.BIVersionNum.Location = new System.Drawing.Point(21, 17);
            this.BIVersionNum.Name = "BIVersionNum";
            this.BIVersionNum.Size = new System.Drawing.Size(53, 12);
            this.BIVersionNum.TabIndex = 0;
            this.BIVersionNum.Text = "Version:";
            // 
            // BIBugNum
            // 
            this.BIBugNum.AutoSize = true;
            this.BIBugNum.Location = new System.Drawing.Point(21, 47);
            this.BIBugNum.Name = "BIBugNum";
            this.BIBugNum.Size = new System.Drawing.Size(53, 12);
            this.BIBugNum.TabIndex = 2;
            this.BIBugNum.Text = "Bug Num:";
            // 
            // BIBugDealMan
            // 
            this.BIBugDealMan.AutoSize = true;
            this.BIBugDealMan.Location = new System.Drawing.Point(252, 47);
            this.BIBugDealMan.Name = "BIBugDealMan";
            this.BIBugDealMan.Size = new System.Drawing.Size(71, 12);
            this.BIBugDealMan.TabIndex = 6;
            this.BIBugDealMan.Text = "Bug Dealer:";
            // 
            // BIBugDescription
            // 
            this.BIBugDescription.AutoSize = true;
            this.BIBugDescription.Location = new System.Drawing.Point(7, 124);
            this.BIBugDescription.Name = "BIBugDescription";
            this.BIBugDescription.Size = new System.Drawing.Size(77, 12);
            this.BIBugDescription.TabIndex = 16;
            this.BIBugDescription.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightCoral;
            this.label2.Location = new System.Drawing.Point(172, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "*";
            // 
            // mQuitButton
            // 
            this.mQuitButton.Location = new System.Drawing.Point(836, 140);
            this.mQuitButton.Name = "mQuitButton";
            this.mQuitButton.Size = new System.Drawing.Size(75, 23);
            this.mQuitButton.TabIndex = 9;
            this.mQuitButton.Text = "Quit";
            this.mQuitButton.UseVisualStyleBackColor = true;
            this.mQuitButton.Click += new System.EventHandler(this.mQuitButton_Click);
            // 
            // mBaseInfoGroupBox
            // 
            this.mBaseInfoGroupBox.Controls.Add(this.mDealManTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mHardLevelTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.BIAssessment);
            this.mBaseInfoGroupBox.Controls.Add(this.mStateControl);
            this.mBaseInfoGroupBox.Controls.Add(this.mPriorityCombo);
            this.mBaseInfoGroupBox.Controls.Add(this.BIPriority);
            this.mBaseInfoGroupBox.Controls.Add(this.mSizeTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.BIPreTakeTime);
            this.mBaseInfoGroupBox.Controls.Add(this.mFiredTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.BITakeTime);
            this.mBaseInfoGroupBox.Controls.Add(this.BIVersionNum);
            this.mBaseInfoGroupBox.Controls.Add(this.mQuitButton);
            this.mBaseInfoGroupBox.Controls.Add(this.mVersionTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mDoAddButton);
            this.mBaseInfoGroupBox.Controls.Add(this.mBugNumTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mDiscriptionTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.BIBugNum);
            this.mBaseInfoGroupBox.Controls.Add(this.label2);
            this.mBaseInfoGroupBox.Controls.Add(this.BIBugDealMan);
            this.mBaseInfoGroupBox.Controls.Add(this.BIBugDescription);
            this.mBaseInfoGroupBox.Location = new System.Drawing.Point(3, 3);
            this.mBaseInfoGroupBox.Name = "mBaseInfoGroupBox";
            this.mBaseInfoGroupBox.Size = new System.Drawing.Size(921, 172);
            this.mBaseInfoGroupBox.TabIndex = 0;
            this.mBaseInfoGroupBox.TabStop = false;
            this.mBaseInfoGroupBox.Text = "Base Information";
            // 
            // mDealManTextBox
            // 
            this.mDealManTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "dealMan", true));
            this.mDealManTextBox.Location = new System.Drawing.Point(335, 44);
            this.mDealManTextBox.Name = "mDealManTextBox";
            this.mDealManTextBox.ReadOnly = true;
            this.mDealManTextBox.Size = new System.Drawing.Size(59, 21);
            this.mDealManTextBox.TabIndex = 26;
            // 
            // mHardLevelTextBox
            // 
            this.mHardLevelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "hardLevel", true));
            this.mHardLevelTextBox.Location = new System.Drawing.Point(335, 74);
            this.mHardLevelTextBox.Name = "mHardLevelTextBox";
            this.mHardLevelTextBox.ReadOnly = true;
            this.mHardLevelTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mHardLevelTextBox.Size = new System.Drawing.Size(59, 21);
            this.mHardLevelTextBox.TabIndex = 25;
            // 
            // BIAssessment
            // 
            this.BIAssessment.AutoSize = true;
            this.BIAssessment.Location = new System.Drawing.Point(192, 77);
            this.BIAssessment.Name = "BIAssessment";
            this.BIAssessment.Size = new System.Drawing.Size(131, 12);
            this.BIAssessment.TabIndex = 24;
            this.BIAssessment.Text = "Difficult Assessment:";
            // 
            // mPriorityCombo
            // 
            this.mPriorityCombo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "Priority", true));
            this.mPriorityCombo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mDataSource, "Priority", true));
            this.mPriorityCombo.DisplayMember = "Name";
            this.mPriorityCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mPriorityCombo.FormattingEnabled = true;
            this.mPriorityCombo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4"});
            this.mPriorityCombo.Location = new System.Drawing.Point(86, 74);
            this.mPriorityCombo.Name = "mPriorityCombo";
            this.mPriorityCombo.Size = new System.Drawing.Size(84, 20);
            this.mPriorityCombo.TabIndex = 5;
            this.mPriorityCombo.ValueMember = "Name";
            // 
            // BIPriority
            // 
            this.BIPriority.AutoSize = true;
            this.BIPriority.Location = new System.Drawing.Point(6, 77);
            this.BIPriority.Name = "BIPriority";
            this.BIPriority.Size = new System.Drawing.Size(59, 12);
            this.BIPriority.TabIndex = 4;
            this.BIPriority.Text = "Priority:";
            // 
            // mSizeTextBox
            // 
            this.mSizeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "Size", true));
            this.mSizeTextBox.Location = new System.Drawing.Point(335, 15);
            this.mSizeTextBox.Name = "mSizeTextBox";
            this.mSizeTextBox.ReadOnly = true;
            this.mSizeTextBox.Size = new System.Drawing.Size(59, 21);
            this.mSizeTextBox.TabIndex = 11;
            // 
            // BIPreTakeTime
            // 
            this.BIPreTakeTime.AutoSize = true;
            this.BIPreTakeTime.Location = new System.Drawing.Point(204, 19);
            this.BIPreTakeTime.Name = "BIPreTakeTime";
            this.BIPreTakeTime.Size = new System.Drawing.Size(119, 12);
            this.BIPreTakeTime.TabIndex = 10;
            this.BIPreTakeTime.Text = "Time Assessment(H):";
            // 
            // mFiredTextBox
            // 
            this.mFiredTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "fired", true));
            this.mFiredTextBox.Location = new System.Drawing.Point(537, 14);
            this.mFiredTextBox.Name = "mFiredTextBox";
            this.mFiredTextBox.ReadOnly = true;
            this.mFiredTextBox.Size = new System.Drawing.Size(95, 21);
            this.mFiredTextBox.TabIndex = 13;
            // 
            // BITakeTime
            // 
            this.BITakeTime.AutoSize = true;
            this.BITakeTime.Location = new System.Drawing.Point(421, 19);
            this.BITakeTime.Name = "BITakeTime";
            this.BITakeTime.Size = new System.Drawing.Size(113, 12);
            this.BITakeTime.TabIndex = 12;
            this.BITakeTime.Text = "Time consuming(H):";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.mBaseInfoGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mEditorPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 633);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // mEditorPanel
            // 
            this.mEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mEditorPanel.Location = new System.Drawing.Point(3, 181);
            this.mEditorPanel.Name = "mEditorPanel";
            this.mEditorPanel.Size = new System.Drawing.Size(921, 449);
            this.mEditorPanel.TabIndex = 0;
            // 
            // bugInfoSet
            // 
            this.bugInfoSet.DataSetName = "BugInfoSet";
            this.bugInfoSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mStateControl
            // 
            this.mStateControl.CurrentState = TeamView.Common.StatesEnum.Start;
            this.mStateControl.Location = new System.Drawing.Point(537, 41);
            this.mStateControl.Name = "mStateControl";
            this.mStateControl.Size = new System.Drawing.Size(79, 77);
            this.mStateControl.TabIndex = 7;
            this.mStateControl.StateChanged += new System.EventHandler<TeamView.StateControl.StateChangedArgs>(this.mStateControl_StateChanged);
            // 
            // BugInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BugInfoForm";
            this.Text = "Bug新增Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BugInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mDataSource)).EndInit();
            this.mBaseInfoGroupBox.ResumeLayout(false);
            this.mBaseInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCreatedManBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDealMenBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bugInfoSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox mBugNumTextBox;
        private System.Windows.Forms.Button mDoAddButton;
        private System.Windows.Forms.TextBox mDiscriptionTextBox;
        private System.Windows.Forms.Label BIVersionNum;
        private System.Windows.Forms.Label BIBugNum;
        private System.Windows.Forms.Label BIBugDealMan;
        private System.Windows.Forms.Label BIBugDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mVersionTextBox;
        private System.Windows.Forms.Button mQuitButton;
        private System.Windows.Forms.BindingSource mDataSource;
        private System.Windows.Forms.GroupBox mBaseInfoGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource mDealMenBindingSource;
        private System.Windows.Forms.TextBox mFiredTextBox;
        private System.Windows.Forms.Label BITakeTime;
        private System.Windows.Forms.BindingSource mCreatedManBindingSource;
        private System.Windows.Forms.TextBox mSizeTextBox;
        private System.Windows.Forms.Label BIPreTakeTime;
        private System.Windows.Forms.Panel mEditorPanel;
        private System.Windows.Forms.Label BIPriority;
        private System.Windows.Forms.ComboBox mPriorityCombo;
        private StateControl mStateControl;
        private System.Windows.Forms.TextBox mHardLevelTextBox;
        private System.Windows.Forms.Label BIAssessment;
        private BugInfoSet bugInfoSet;
        private System.Windows.Forms.TextBox mDealManTextBox;
    }
}