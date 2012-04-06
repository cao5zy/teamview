namespace TeamView
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
            this.mBugInfoListDataGridView = new System.Windows.Forms.DataGridView();
            this.version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bugStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bugNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dealMan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feedBackCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mFlowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mBugInfoSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mBugInfoSet = new TeamView.BugInfoSet();
            this.mEditButton = new System.Windows.Forms.Button();
            this.mTipLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mQueryControlContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mNotifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mShowMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mImageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoListDataGridView)).BeginInit();
            this.mFlowMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoSet)).BeginInit();
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
            this.mAddButton.Location = new System.Drawing.Point(848, 94);
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
            // mBugInfoListDataGridView
            // 
            this.mBugInfoListDataGridView.AutoGenerateColumns = false;
            this.mBugInfoListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mBugInfoListDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.mBugInfoListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.mBugInfoListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.version,
            this.bugStatus,
            this.bugNum,
            this.dealMan,
            this.description,
            this.Priority,
            this.Size,
            this.fired,
            this.feedBackCountDataGridViewTextBoxColumn});
            this.mBugInfoListDataGridView.ContextMenuStrip = this.mFlowMenu;
            this.mBugInfoListDataGridView.DataMember = "BugInfoTable";
            this.mBugInfoListDataGridView.DataSource = this.mBugInfoSetBindingSource;
            this.mBugInfoListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mBugInfoListDataGridView.Location = new System.Drawing.Point(3, 161);
            this.mBugInfoListDataGridView.Name = "mBugInfoListDataGridView";
            this.mBugInfoListDataGridView.ReadOnly = true;
            this.mBugInfoListDataGridView.RowTemplate.Height = 23;
            this.mBugInfoListDataGridView.Size = new System.Drawing.Size(1067, 412);
            this.mBugInfoListDataGridView.TabIndex = 15;
            this.mBugInfoListDataGridView.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.mBugInfoListDataGridView_CellContextMenuStripNeeded);
            this.mBugInfoListDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.mBugInfoListDataGridView_DataError);
            this.mBugInfoListDataGridView.SelectionChanged += new System.EventHandler(this.mBugInfoListDataGridView_SelectionChanged);
            this.mBugInfoListDataGridView.Sorted += new System.EventHandler(this.mBugInfoListDataGridView_Sorted);
            // 
            // version
            // 
            this.version.DataPropertyName = "Version";
            this.version.HeaderText = global::TeamView.BugInfoManagement_Resource.dVersion;
            this.version.Name = "version";
            this.version.ReadOnly = true;
            // 
            // bugStatus
            // 
            this.bugStatus.DataPropertyName = "bugStatus";
            this.bugStatus.HeaderText = "Status";
            this.bugStatus.Name = "bugStatus";
            this.bugStatus.ReadOnly = true;
            // 
            // bugNum
            // 
            this.bugNum.DataPropertyName = "bugNum";
            this.bugNum.HeaderText = global::TeamView.BugInfoManagement_Resource.dBugNum;
            this.bugNum.Name = "bugNum";
            this.bugNum.ReadOnly = true;
            // 
            // dealMan
            // 
            this.dealMan.DataPropertyName = "dealMan";
            this.dealMan.HeaderText = "Handler";
            this.dealMan.Name = "dealMan";
            this.dealMan.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = global::TeamView.BugInfoManagement_Resource.dDescription;
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // Priority
            // 
            this.Priority.DataPropertyName = "Priority";
            this.Priority.HeaderText = global::TeamView.BugInfoManagement_Resource.dPriority;
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            // 
            // Size
            // 
            this.Size.DataPropertyName = "size";
            this.Size.HeaderText = global::TeamView.BugInfoManagement_Resource.dSize;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            // 
            // fired
            // 
            this.fired.DataPropertyName = "fired";
            this.fired.HeaderText = "fired";
            this.fired.Name = "fired";
            this.fired.ReadOnly = true;
            // 
            // feedBackCountDataGridViewTextBoxColumn
            // 
            this.feedBackCountDataGridViewTextBoxColumn.DataPropertyName = "FeedBackCount";
            this.feedBackCountDataGridViewTextBoxColumn.HeaderText = "FeedBackCount";
            this.feedBackCountDataGridViewTextBoxColumn.Name = "feedBackCountDataGridViewTextBoxColumn";
            this.feedBackCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // mFlowMenu
            // 
            this.mFlowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.abortToolStripMenuItem,
            this.completeToolStripMenuItem,
            this.pendingToolStripMenuItem});
            this.mFlowMenu.Name = "mFlowMenu";
            this.mFlowMenu.Size = new System.Drawing.Size(153, 114);
            this.mFlowMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mFlowMenu_ItemClicked);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.startToolStripMenuItem.Text = "Start";
            // 
            // abortToolStripMenuItem
            // 
            this.abortToolStripMenuItem.Name = "abortToolStripMenuItem";
            this.abortToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abortToolStripMenuItem.Text = "Suspend";
            // 
            // completeToolStripMenuItem
            // 
            this.completeToolStripMenuItem.Name = "completeToolStripMenuItem";
            this.completeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.completeToolStripMenuItem.Text = "Complete";
            // 
            // pendingToolStripMenuItem
            // 
            this.pendingToolStripMenuItem.Name = "pendingToolStripMenuItem";
            this.pendingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pendingToolStripMenuItem.Text = "Pending";
            // 
            // mBugInfoSetBindingSource
            // 
            this.mBugInfoSetBindingSource.DataSource = this.mBugInfoSet;
            this.mBugInfoSetBindingSource.Position = 0;
            // 
            // mBugInfoSet
            // 
            this.mBugInfoSet.DataSetName = "BugInfoSet";
            this.mBugInfoSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mEditButton
            // 
            this.mEditButton.AllowDrop = true;
            this.mEditButton.Location = new System.Drawing.Point(950, 94);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.mQueryControlContainer);
            this.panel1.Controls.Add(this.mEditButton);
            this.panel1.Controls.Add(this.mTipLabel);
            this.panel1.Controls.Add(this.mAddButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 152);
            this.panel1.TabIndex = 29;
            // 
            // mQueryControlContainer
            // 
            this.mQueryControlContainer.Location = new System.Drawing.Point(3, 3);
            this.mQueryControlContainer.Name = "mQueryControlContainer";
            this.mQueryControlContainer.Size = new System.Drawing.Size(839, 146);
            this.mQueryControlContainer.TabIndex = 27;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1073, 576);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 576);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MainForm";
            this.Text = "TeamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoListDataGridView)).EndInit();
            this.mFlowMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mBugInfoSet)).EndInit();
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
        private System.Windows.Forms.Button mEditButton;
        private System.Windows.Forms.Label mTipLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NotifyIcon mNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip mNotifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mShowMenu;
        private System.Windows.Forms.ToolStripMenuItem mExitMenu;
        private System.Windows.Forms.ImageList mImageList;
        private System.Windows.Forms.ContextMenuStrip mFlowMenu;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeToolStripMenuItem;
        private System.Windows.Forms.Panel mQueryControlContainer;
        private BugInfoSet mBugInfoSet;
        private System.Windows.Forms.BindingSource mBugInfoSetBindingSource;
        private System.Windows.Forms.DataGridView mBugInfoListDataGridView;
        private System.Windows.Forms.ToolStripMenuItem pendingToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn version;
        private System.Windows.Forms.DataGridViewTextBoxColumn bugStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn bugNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn dealMan;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn fired;
        private System.Windows.Forms.DataGridViewTextBoxColumn feedBackCountDataGridViewTextBoxColumn;
    }
}