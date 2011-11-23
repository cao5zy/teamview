namespace BugInfoManagement
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label5 = new System.Windows.Forms.Label();
            this.mAddButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.mQueryButton = new System.Windows.Forms.Button();
            this.mDealManlabel = new System.Windows.Forms.Label();
            this.mBugInfoListDataGridView = new System.Windows.Forms.DataGridView();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bugNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bugStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disposeResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mFlowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mEditButton = new System.Windows.Forms.Button();
            this.mTipLabel = new System.Windows.Forms.Label();
            this.mDealManComboBox = new System.Windows.Forms.ComboBox();
            this.mQueryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mDealManBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mQueryGroupBox = new System.Windows.Forms.GroupBox();
            this.mDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.mDescriptionLabel = new System.Windows.Forms.Label();
            this.mVersionTextBox = new System.Windows.Forms.TextBox();
            this.mBugNumTextBox = new System.Windows.Forms.TextBox();
            this.mVersionNumber = new System.Windows.Forms.Label();
            this.mBugNumberLabel = new System.Windows.Forms.Label();
            this.mBugStatesComboBox = new System.Windows.Forms.ComboBox();
            this.mStatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mStateLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mNotifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mShowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mTimer = new System.Windows.Forms.Timer(this.components);
            this.mImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoListDataGridView)).BeginInit();
            this.mFlowMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mQueryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDealManBindingSource)).BeginInit();
            this.mQueryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mStatesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.mNotifyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(467, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 24;
            // 
            // mAddButton
            // 
            this.mAddButton.Location = new System.Drawing.Point(721, 81);
            this.mAddButton.Name = "mAddButton";
            this.mAddButton.Size = new System.Drawing.Size(71, 29);
            this.mAddButton.TabIndex = 22;
            this.mAddButton.Text = "Add New";
            this.mAddButton.UseVisualStyleBackColor = true;
            this.mAddButton.Click += new System.EventHandler(this.mAddButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Desktop;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(779, -21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 21;
            // 
            // mQueryButton
            // 
            this.mQueryButton.Location = new System.Drawing.Point(603, 78);
            this.mQueryButton.Name = "mQueryButton";
            this.mQueryButton.Size = new System.Drawing.Size(75, 29);
            this.mQueryButton.TabIndex = 19;
            this.mQueryButton.Text = "Query";
            this.mQueryButton.UseVisualStyleBackColor = true;
            this.mQueryButton.Click += new System.EventHandler(this.mQueryButton_Click);
            // 
            // mDealManlabel
            // 
            this.mDealManlabel.AutoSize = true;
            this.mDealManlabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mDealManlabel.Location = new System.Drawing.Point(5, 26);
            this.mDealManlabel.Name = "mDealManlabel";
            this.mDealManlabel.Size = new System.Drawing.Size(65, 14);
            this.mDealManlabel.TabIndex = 16;
            this.mDealManlabel.Text = "Programer:";
            // 
            // mBugInfoListDataGridView
            // 
            this.mBugInfoListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mBugInfoListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.mBugInfoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mBugInfoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.version,
            this.bugNum,
            this.bugStatus,
            this.dealMan,
            this.description,
            this.disposeResult,
            this.Priority,
            this.Size});
            this.mBugInfoListDataGridView.ContextMenuStrip = this.mFlowMenu;
            this.mBugInfoListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mBugInfoListDataGridView.Location = new System.Drawing.Point(3, 131);
            this.mBugInfoListDataGridView.Name = "mBugInfoListDataGridView";
            this.mBugInfoListDataGridView.ReadOnly = true;
            this.mBugInfoListDataGridView.RowTemplate.Height = 23;
            this.mBugInfoListDataGridView.Size = new System.Drawing.Size(972, 442);
            this.mBugInfoListDataGridView.TabIndex = 15;
            this.mBugInfoListDataGridView.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.mBugInfoListDataGridView_CellContextMenuStripNeeded);
            this.mBugInfoListDataGridView.SelectionChanged += new System.EventHandler(this.mBugInfoListDataGridView_SelectionChanged);
            // 
            // version
            // 
            this.version.DataPropertyName = "Version";
            this.version.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dVersion;
            this.version.Name = "version";
            this.version.ReadOnly = true;
            // 
            // bugNum
            // 
            this.bugNum.DataPropertyName = "bugNum";
            this.bugNum.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dBugNum;
            this.bugNum.Name = "bugNum";
            this.bugNum.ReadOnly = true;
            // 
            // bugStatus
            // 
            this.bugStatus.DataPropertyName = "bugStatus";
            this.bugStatus.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dState;
            this.bugStatus.Name = "bugStatus";
            this.bugStatus.ReadOnly = true;
            // 
            // dealMan
            // 
            this.dealMan.DataPropertyName = "dealMan";
            this.dealMan.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dBugDealer;
            this.dealMan.Name = "dealMan";
            this.dealMan.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dDescription;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // disposeResult
            // 
            this.disposeResult.DataPropertyName = "disposeResult";
            this.disposeResult.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dDealRecord;
            this.disposeResult.Name = "disposeResult";
            this.disposeResult.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dPriority;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "size";
            this.Size.HeaderText = global::BugInfoManagement.BugInfoManagement_Resource.dSize;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // mFlowMenu
            // 
            this.mFlowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.abortToolStripMenuItem,
            this.completeToolStripMenuItem});
            this.mFlowMenu.Name = "mFlowMenu";
            this.mFlowMenu.Size = new System.Drawing.Size(120, 70);
            this.mFlowMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mFlowMenu_ItemClicked);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // abortToolStripMenuItem
            // 
            this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
            this.abortToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.abortToolStripMenuItem.Text = "Abort";
            // 
            // completeToolStripMenuItem
            // 
            this.completeToolStripMenuItem.Name = "completeToolStripMenuItem";
            this.completeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.completeToolStripMenuItem.Text = "Complete";
            // 
            // mEditButton
            // 
            this.mEditButton.AllowDrop = true;
            this.mEditButton.Location = new System.Drawing.Point(823, 81);
            this.mEditButton.Name = "mEditButton";
            this.mEditButton.Size = new System.Drawing.Size(75, 29);
            this.mEditButton.TabIndex = 25;
            this.mEditButton.Text = "Edit";
            this.mEditButton.UseVisualStyleBackColor = true;
            this.mEditButton.Click += new System.EventHandler(this.mEditButton_Click);
            // 
            // mTipLabel
            // 
            this.mTipLabel.AutoSize = true;
            this.mTipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mTipLabel.ForeColor = System.Drawing.Color.Maroon;
            this.mTipLabel.Location = new System.Drawing.Point(467, 98);
            this.mTipLabel.Name = "mTipLabel";
            this.mTipLabel.Size = new System.Drawing.Size(0, 15);
            this.mTipLabel.TabIndex = 26;
            // 
            // mDealManComboBox
            // 
            this.mDealManComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mQueryBindingSource, "Programmer", true));
            this.mDealManComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mQueryBindingSource, "Programmer", true));
            this.mDealManComboBox.DataSource = this.mDealManBindingSource;
            this.mDealManComboBox.DisplayMember = "Name";
            this.mDealManComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mDealManComboBox.FormattingEnabled = true;
            this.mDealManComboBox.Location = new System.Drawing.Point(73, 24);
            this.mDealManComboBox.Name = "mDealManComboBox";
            this.mDealManComboBox.Size = new System.Drawing.Size(124, 22);
            this.mDealManComboBox.TabIndex = 27;
            this.mDealManComboBox.ValueMember = "Name";
            // 
            // mQueryBindingSource
            // 
            this.mQueryBindingSource.DataSource = typeof(BugInfoManagement.Dao.QueryParameter);
            // 
            // mDealManBindingSource
            // 
            this.mDealManBindingSource.DataSource = typeof(BugInfoManagement.Entity.ProgrammerBaseInfo);
            // 
            // mQueryGroupBox
            // 
            this.mQueryGroupBox.Controls.Add(this.mDescriptionTextBox);
            this.mQueryGroupBox.Controls.Add(this.mDescriptionLabel);
            this.mQueryGroupBox.Controls.Add(this.mVersionTextBox);
            this.mQueryGroupBox.Controls.Add(this.mBugNumTextBox);
            this.mQueryGroupBox.Controls.Add(this.mVersionNumber);
            this.mQueryGroupBox.Controls.Add(this.mBugNumberLabel);
            this.mQueryGroupBox.Controls.Add(this.mBugStatesComboBox);
            this.mQueryGroupBox.Controls.Add(this.mStateLabel);
            this.mQueryGroupBox.Controls.Add(this.mDealManComboBox);
            this.mQueryGroupBox.Controls.Add(this.mDealManlabel);
            this.mQueryGroupBox.Controls.Add(this.mQueryButton);
            this.mQueryGroupBox.Location = new System.Drawing.Point(3, 3);
            this.mQueryGroupBox.Name = "mQueryGroupBox";
            this.mQueryGroupBox.Size = new System.Drawing.Size(685, 117);
            this.mQueryGroupBox.TabIndex = 28;
            this.mQueryGroupBox.TabStop = false;
            this.mQueryGroupBox.Text = "Query Condition";
            // 
            // mDescriptionTextBox
            // 
            this.mDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mQueryBindingSource, "Description", true));
            this.mDescriptionTextBox.Location = new System.Drawing.Point(520, 26);
            this.mDescriptionTextBox.Name = "mDescriptionTextBox";
            this.mDescriptionTextBox.Size = new System.Drawing.Size(158, 22);
            this.mDescriptionTextBox.TabIndex = 35;
            // 
            // mDescriptionLabel
            // 
            this.mDescriptionLabel.AutoSize = true;
            this.mDescriptionLabel.Location = new System.Drawing.Point(448, 29);
            this.mDescriptionLabel.Name = "mDescriptionLabel";
            this.mDescriptionLabel.Size = new System.Drawing.Size(73, 14);
            this.mDescriptionLabel.TabIndex = 34;
            this.mDescriptionLabel.Text = "Description:";
            // 
            // mVersionTextBox
            // 
            this.mVersionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mQueryBindingSource, "Version", true));
            this.mVersionTextBox.Location = new System.Drawing.Point(305, 69);
            this.mVersionTextBox.Name = "mVersionTextBox";
            this.mVersionTextBox.Size = new System.Drawing.Size(100, 22);
            this.mVersionTextBox.TabIndex = 33;
            // 
            // mBugNumTextBox
            // 
            this.mBugNumTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mQueryBindingSource, "BugNum", true));
            this.mBugNumTextBox.Location = new System.Drawing.Point(305, 26);
            this.mBugNumTextBox.Name = "mBugNumTextBox";
            this.mBugNumTextBox.Size = new System.Drawing.Size(100, 22);
            this.mBugNumTextBox.TabIndex = 32;
            // 
            // mVersionNumber
            // 
            this.mVersionNumber.AutoSize = true;
            this.mVersionNumber.Location = new System.Drawing.Point(243, 72);
            this.mVersionNumber.Name = "mVersionNumber";
            this.mVersionNumber.Size = new System.Drawing.Size(52, 14);
            this.mVersionNumber.TabIndex = 31;
            this.mVersionNumber.Text = "Version:";
            // 
            // mBugNumberLabel
            // 
            this.mBugNumberLabel.AutoSize = true;
            this.mBugNumberLabel.Location = new System.Drawing.Point(243, 27);
            this.mBugNumberLabel.Name = "mBugNumberLabel";
            this.mBugNumberLabel.Size = new System.Drawing.Size(58, 14);
            this.mBugNumberLabel.TabIndex = 30;
            this.mBugNumberLabel.Text = "Bug Num:";
            // 
            // mBugStatesComboBox
            // 
            this.mBugStatesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mQueryBindingSource, "Status", true));
            this.mBugStatesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mQueryBindingSource, "Status", true));
            this.mBugStatesComboBox.DataSource = this.mStatesBindingSource;
            this.mBugStatesComboBox.DisplayMember = "StateInfo";
            this.mBugStatesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mBugStatesComboBox.FormattingEnabled = true;
            this.mBugStatesComboBox.Location = new System.Drawing.Point(73, 69);
            this.mBugStatesComboBox.Name = "mBugStatesComboBox";
            this.mBugStatesComboBox.Size = new System.Drawing.Size(124, 22);
            this.mBugStatesComboBox.TabIndex = 29;
            this.mBugStatesComboBox.ValueMember = "StateInfo";
            // 
            // mStatesBindingSource
            // 
            this.mStatesBindingSource.DataSource = typeof(BugInfoManagement.Entity.BugStateBaseInfo);
            // 
            // mStateLabel
            // 
            this.mStateLabel.AutoSize = true;
            this.mStateLabel.Location = new System.Drawing.Point(6, 72);
            this.mStateLabel.Name = "mStateLabel";
            this.mStateLabel.Size = new System.Drawing.Size(38, 14);
            this.mStateLabel.TabIndex = 28;
            this.mStateLabel.Text = "State:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mQueryGroupBox);
            this.panel1.Controls.Add(this.mEditButton);
            this.panel1.Controls.Add(this.mTipLabel);
            this.panel1.Controls.Add(this.mAddButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 122);
            this.panel1.TabIndex = 29;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mBugInfoListDataGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 576);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // mNotifyIcon
            // 
            this.mNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.mNotifyIcon.BalloonTipText = "New incomming list";
            this.mNotifyIcon.BalloonTipTitle = "Incomming";
            this.mNotifyIcon.ContextMenuStrip = this.mNotifyContextMenu;
            this.mNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mNotifyIcon.Icon")));
            this.mNotifyIcon.Text = "BugInfoManagement";
            this.mNotifyIcon.Visible = true;
            this.mNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mNotifyIcon_MouseDoubleClick);
            // 
            // mNotifyContextMenu
            // 
            this.mNotifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mShowMenu,
            this.mExitMenu});
            this.mNotifyContextMenu.Name = "mNotifyContextMenu";
            this.mNotifyContextMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // mShowMenu
            // 
            this.mShowMenu.Name = "mShowMenu";
            this.mShowMenu.Size = new System.Drawing.Size(100, 22);
            this.mShowMenu.Text = "Show";
            this.mShowMenu.Click += new System.EventHandler(this.mShowMenu_Click);
            // 
            // mExitMenu
            // 
            this.mExitMenu.Name = "mExitMenu";
            this.mExitMenu.Size = new System.Drawing.Size(100, 22);
            this.mExitMenu.Text = "Exit";
            this.mExitMenu.Click += new System.EventHandler(this.mExitMenu_Click);
            // 
            // mTimer
            // 
            this.mTimer.Tick += new System.EventHandler(this.mTimer_Tick);
            // 
            // mImageList
            // 
            this.mImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mImageList.ImageStream")));
            this.mImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.mImageList.Images.SetKeyName(0, "userL.ico");
            this.mImageList.Images.SetKeyName(1, "state-pickup.ico");
            this.mImageList.Images.SetKeyName(2, "state-reach.ico");
            // 
            // MainForm
            // 
            this.AcceptButton = this.mQueryButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 576);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "TeamView";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoListDataGridView)).EndInit();
            this.mFlowMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mQueryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mDealManBindingSource)).EndInit();
            this.mQueryGroupBox.ResumeLayout(false);
            this.mQueryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mStatesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.mNotifyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button mAddButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mQueryButton;
        private System.Windows.Forms.Label mDealManlabel;
        private System.Windows.Forms.DataGridView mBugInfoListDataGridView;
        private System.Windows.Forms.Button mEditButton;
        private System.Windows.Forms.Label mTipLabel;
        private System.Windows.Forms.ComboBox mDealManComboBox;
        private System.Windows.Forms.GroupBox mQueryGroupBox;
        private System.Windows.Forms.ComboBox mBugStatesComboBox;
        private System.Windows.Forms.Label mStateLabel;
        private System.Windows.Forms.BindingSource mDealManBindingSource;
        private System.Windows.Forms.BindingSource mStatesBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NotifyIcon mNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mNotifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mShowMenu;
        private System.Windows.Forms.ToolStripMenuItem mExitMenu;
        private System.Windows.Forms.Timer mTimer;
        private System.Windows.Forms.ImageList mImageList;
        private System.Windows.Forms.TextBox mVersionTextBox;
        private System.Windows.Forms.TextBox mBugNumTextBox;
        private System.Windows.Forms.Label mVersionNumber;
        private System.Windows.Forms.Label mBugNumberLabel;
        private System.Windows.Forms.BindingSource mQueryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewTextBoxColumn bugNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn bugStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn disposeResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.ContextMenuStrip mFlowMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeToolStripMenuItem;
        private System.Windows.Forms.TextBox mDescriptionTextBox;
        private System.Windows.Forms.Label mDescriptionLabel;
    }
}