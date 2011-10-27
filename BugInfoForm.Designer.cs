using BugInfoManagement.Common;
namespace BugInfoManagement
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
            this.l1 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.c1 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mQuitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mBaseInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.mAssignPointsControlContainer = new System.Windows.Forms.Panel();
            this.mBugStatusTextBox = new System.Windows.Forms.TextBox();
            this.mStateControl = new BugInfoManagement.StateControl();
            this.mPriorityCombo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mSizeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mCreatedComboBox = new System.Windows.Forms.ComboBox();
            this.mCreatedManBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.mTotalHoursBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mDealManComboBox = new System.Windows.Forms.ComboBox();
            this.mDealMenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mdisposeResultTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mEditorPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mDataSource)).BeginInit();
            this.mBaseInfoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCreatedManBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDealMenBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mVersionTextBox
            // 
            this.mVersionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "Version", true));
            this.mVersionTextBox.Location = new System.Drawing.Point(61, 13);
            this.mVersionTextBox.Name = "mVersionTextBox";
            this.mVersionTextBox.Size = new System.Drawing.Size(100, 21);
            this.mVersionTextBox.TabIndex = 1;
            // 
            // mDataSource
            // 
            this.mDataSource.DataSource = typeof(BugInfoManagement.Entity.BugInfoEntity);
            // 
            // mBugNumTextBox
            // 
            this.mBugNumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "BugNum", true));
            this.mBugNumTextBox.Location = new System.Drawing.Point(260, 13);
            this.mBugNumTextBox.Name = "mBugNumTextBox";
            this.mBugNumTextBox.Size = new System.Drawing.Size(100, 21);
            this.mBugNumTextBox.TabIndex = 3;
            // 
            // mDoAddButton
            // 
            this.mDoAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mDoAddButton.Location = new System.Drawing.Point(673, 157);
            this.mDoAddButton.Name = "mDoAddButton";
            this.mDoAddButton.Size = new System.Drawing.Size(75, 23);
            this.mDoAddButton.TabIndex = 21;
            this.mDoAddButton.Text = "保存";
            this.mDoAddButton.UseVisualStyleBackColor = true;
            this.mDoAddButton.Click += new System.EventHandler(this.mDoAddButton_Click);
            // 
            // mDiscriptionTextBox
            // 
            this.mDiscriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "Description", true));
            this.mDiscriptionTextBox.Location = new System.Drawing.Point(77, 72);
            this.mDiscriptionTextBox.Multiline = true;
            this.mDiscriptionTextBox.Name = "mDiscriptionTextBox";
            this.mDiscriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mDiscriptionTextBox.Size = new System.Drawing.Size(590, 39);
            this.mDiscriptionTextBox.TabIndex = 17;
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(6, 17);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(53, 12);
            this.l1.TabIndex = 0;
            this.l1.Text = "版本号：";
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Location = new System.Drawing.Point(200, 17);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(59, 12);
            this.l2.TabIndex = 2;
            this.l2.Text = "Bug编号：";
            // 
            // c1
            // 
            this.c1.AutoSize = true;
            this.c1.Location = new System.Drawing.Point(6, 49);
            this.c1.Name = "c1";
            this.c1.Size = new System.Drawing.Size(59, 12);
            this.c1.TabIndex = 8;
            this.c1.Text = "Bug状态：";
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Location = new System.Drawing.Point(564, 17);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(71, 12);
            this.l3.TabIndex = 6;
            this.l3.Text = "bug处理人：";
            // 
            // l8
            // 
            this.l8.AutoSize = true;
            this.l8.Location = new System.Drawing.Point(6, 72);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(59, 12);
            this.l8.TabIndex = 16;
            this.l8.Text = "Bug描述：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "处理记录：";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightCoral;
            this.label4.Location = new System.Drawing.Point(538, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "*";
            // 
            // mQuitButton
            // 
            this.mQuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mQuitButton.Location = new System.Drawing.Point(754, 157);
            this.mQuitButton.Name = "mQuitButton";
            this.mQuitButton.Size = new System.Drawing.Size(75, 23);
            this.mQuitButton.TabIndex = 22;
            this.mQuitButton.Text = "退出";
            this.mQuitButton.UseVisualStyleBackColor = true;
            this.mQuitButton.Click += new System.EventHandler(this.mQuitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightCoral;
            this.label1.Location = new System.Drawing.Point(736, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "*";
            // 
            // mBaseInfoGroupBox
            // 
            this.mBaseInfoGroupBox.Controls.Add(this.textBox1);
            this.mBaseInfoGroupBox.Controls.Add(this.label9);
            this.mBaseInfoGroupBox.Controls.Add(this.mAssignPointsControlContainer);
            this.mBaseInfoGroupBox.Controls.Add(this.mBugStatusTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mStateControl);
            this.mBaseInfoGroupBox.Controls.Add(this.mPriorityCombo);
            this.mBaseInfoGroupBox.Controls.Add(this.label8);
            this.mBaseInfoGroupBox.Controls.Add(this.mSizeTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.label6);
            this.mBaseInfoGroupBox.Controls.Add(this.mCreatedComboBox);
            this.mBaseInfoGroupBox.Controls.Add(this.label5);
            this.mBaseInfoGroupBox.Controls.Add(this.mTotalHoursBox);
            this.mBaseInfoGroupBox.Controls.Add(this.label3);
            this.mBaseInfoGroupBox.Controls.Add(this.mDealManComboBox);
            this.mBaseInfoGroupBox.Controls.Add(this.l1);
            this.mBaseInfoGroupBox.Controls.Add(this.label1);
            this.mBaseInfoGroupBox.Controls.Add(this.mQuitButton);
            this.mBaseInfoGroupBox.Controls.Add(this.mVersionTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mDoAddButton);
            this.mBaseInfoGroupBox.Controls.Add(this.mBugNumTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mDiscriptionTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.mdisposeResultTextBox);
            this.mBaseInfoGroupBox.Controls.Add(this.label4);
            this.mBaseInfoGroupBox.Controls.Add(this.l2);
            this.mBaseInfoGroupBox.Controls.Add(this.label2);
            this.mBaseInfoGroupBox.Controls.Add(this.c1);
            this.mBaseInfoGroupBox.Controls.Add(this.l3);
            this.mBaseInfoGroupBox.Controls.Add(this.l8);
            this.mBaseInfoGroupBox.Controls.Add(this.label7);
            this.mBaseInfoGroupBox.Location = new System.Drawing.Point(3, 3);
            this.mBaseInfoGroupBox.Name = "mBaseInfoGroupBox";
            this.mBaseInfoGroupBox.Size = new System.Drawing.Size(961, 187);
            this.mBaseInfoGroupBox.TabIndex = 0;
            this.mBaseInfoGroupBox.TabStop = false;
            this.mBaseInfoGroupBox.Text = "基本信息";
            // 
            // mAssignPointsControlContainer
            // 
            this.mAssignPointsControlContainer.Location = new System.Drawing.Point(771, 20);
            this.mAssignPointsControlContainer.Name = "mAssignPointsControlContainer";
            this.mAssignPointsControlContainer.Size = new System.Drawing.Size(181, 131);
            this.mAssignPointsControlContainer.TabIndex = 23;
            // 
            // mBugStatusTextBox
            // 
            this.mBugStatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "BugStatus", true));
            this.mBugStatusTextBox.Enabled = false;
            this.mBugStatusTextBox.Location = new System.Drawing.Point(77, 46);
            this.mBugStatusTextBox.Name = "mBugStatusTextBox";
            this.mBugStatusTextBox.Size = new System.Drawing.Size(84, 21);
            this.mBugStatusTextBox.TabIndex = 9;
            // 
            // mStateControl
            // 
            this.mStateControl.CurrentState = BugInfoManagement.Common.StatesEnum.Start;
            this.mStateControl.Location = new System.Drawing.Point(684, 74);
            this.mStateControl.Name = "mStateControl";
            this.mStateControl.Size = new System.Drawing.Size(81, 77);
            this.mStateControl.TabIndex = 18;
            this.mStateControl.StateChanged += new System.EventHandler<BugInfoManagement.StateControl.StateChangedArgs>(this.mStateControl_StateChanged);
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
            this.mPriorityCombo.Location = new System.Drawing.Point(637, 41);
            this.mPriorityCombo.Name = "mPriorityCombo";
            this.mPriorityCombo.Size = new System.Drawing.Size(46, 20);
            this.mPriorityCombo.TabIndex = 15;
            this.mPriorityCombo.ValueMember = "Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(582, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "优先级：";
            // 
            // mSizeTextBox
            // 
            this.mSizeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "Size", true));
            this.mSizeTextBox.Location = new System.Drawing.Point(260, 45);
            this.mSizeTextBox.Name = "mSizeTextBox";
            this.mSizeTextBox.Size = new System.Drawing.Size(100, 21);
            this.mSizeTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "估计耗时(H)：";
            // 
            // mCreatedComboBox
            // 
            this.mCreatedComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "CreatedBy", true));
            this.mCreatedComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mDataSource, "CreatedBy", true));
            this.mCreatedComboBox.DataSource = this.mCreatedManBindingSource;
            this.mCreatedComboBox.DisplayMember = "Name";
            this.mCreatedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mCreatedComboBox.FormattingEnabled = true;
            this.mCreatedComboBox.Location = new System.Drawing.Point(437, 13);
            this.mCreatedComboBox.Name = "mCreatedComboBox";
            this.mCreatedComboBox.Size = new System.Drawing.Size(90, 20);
            this.mCreatedComboBox.TabIndex = 5;
            this.mCreatedComboBox.ValueMember = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "创建人：";
            // 
            // mTotalHoursBox
            // 
            this.mTotalHoursBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "TotalHours", true));
            this.mTotalHoursBox.Location = new System.Drawing.Point(437, 45);
            this.mTotalHoursBox.Name = "mTotalHoursBox";
            this.mTotalHoursBox.ReadOnly = true;
            this.mTotalHoursBox.Size = new System.Drawing.Size(90, 21);
            this.mTotalHoursBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "耗时(H)：";
            // 
            // mDealManComboBox
            // 
            this.mDealManComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "DealMan", true));
            this.mDealManComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mDataSource, "DealMan", true));
            this.mDealManComboBox.DataSource = this.mDealMenBindingSource;
            this.mDealManComboBox.DisplayMember = "Name";
            this.mDealManComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mDealManComboBox.FormattingEnabled = true;
            this.mDealManComboBox.Location = new System.Drawing.Point(637, 13);
            this.mDealManComboBox.Name = "mDealManComboBox";
            this.mDealManComboBox.Size = new System.Drawing.Size(90, 20);
            this.mDealManComboBox.TabIndex = 7;
            this.mDealManComboBox.ValueMember = "Name";
            // 
            // mdisposeResultTextBox
            // 
            this.mdisposeResultTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "DisposeResult", true));
            this.mdisposeResultTextBox.Location = new System.Drawing.Point(77, 117);
            this.mdisposeResultTextBox.Multiline = true;
            this.mdisposeResultTextBox.Name = "mdisposeResultTextBox";
            this.mdisposeResultTextBox.ReadOnly = true;
            this.mdisposeResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mdisposeResultTextBox.Size = new System.Drawing.Size(283, 63);
            this.mdisposeResultTextBox.TabIndex = 20;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 193F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(967, 633);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // mEditorPanel
            // 
            this.mEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mEditorPanel.Location = new System.Drawing.Point(3, 196);
            this.mEditorPanel.Name = "mEditorPanel";
            this.mEditorPanel.Size = new System.Drawing.Size(961, 434);
            this.mEditorPanel.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 24;
            this.label9.Text = "难度评价：";
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mDataSource, "LevelHistroy", true));
            this.textBox1.Location = new System.Drawing.Point(437, 117);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(230, 63);
            this.textBox1.TabIndex = 25;
            // 
            // BugInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 633);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BugInfoForm";
            this.Text = "Bug新增Form";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BugInfoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mDataSource)).EndInit();
            this.mBaseInfoGroupBox.ResumeLayout(false);
            this.mBaseInfoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCreatedManBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDealMenBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox mBugNumTextBox;
        private System.Windows.Forms.Button mDoAddButton;
        private System.Windows.Forms.TextBox mDiscriptionTextBox;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label c1;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mVersionTextBox;
        private System.Windows.Forms.Button mQuitButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource mDataSource;
        private System.Windows.Forms.GroupBox mBaseInfoGroupBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox mDealManComboBox;
        private System.Windows.Forms.BindingSource mDealMenBindingSource;
        private System.Windows.Forms.TextBox mTotalHoursBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox mCreatedComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource mCreatedManBindingSource;
        private System.Windows.Forms.TextBox mdisposeResultTextBox;
        private System.Windows.Forms.TextBox mSizeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel mEditorPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox mPriorityCombo;
        private StateControl mStateControl;
        private System.Windows.Forms.TextBox mBugStatusTextBox;
        private System.Windows.Forms.Panel mAssignPointsControlContainer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
    }
}