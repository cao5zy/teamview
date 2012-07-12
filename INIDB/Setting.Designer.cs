namespace IniTeamView
{
    partial class Setting
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SettingToolStrip = new System.Windows.Forms.ToolStrip();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.QuitButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.MemberTextBox = new System.Windows.Forms.TextBox();
            this.MemberGridView = new System.Windows.Forms.DataGridView();
            this.MemberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddMemberButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteMemberButton = new System.Windows.Forms.ToolStripButton();
            this.SetFirstMemberButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SettingToolStrip.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SettingToolStrip);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            this.splitContainer1.Panel1.Controls.Add(this.MemberTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.MemberGridView);
            this.splitContainer1.Size = new System.Drawing.Size(263, 268);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 0;
            // 
            // SettingToolStrip
            // 
            this.SettingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SettingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SettingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMemberButton,
            this.DeleteMemberButton,
            this.SetFirstMemberButton,
            this.SaveButton,
            this.QuitButton});
            this.SettingToolStrip.Location = new System.Drawing.Point(148, 4);
            this.SettingToolStrip.Name = "SettingToolStrip";
            this.SettingToolStrip.Size = new System.Drawing.Size(149, 25);
            this.SettingToolStrip.TabIndex = 4;
            this.SettingToolStrip.Text = "toolStrip1";
            // 
            // SaveButton
            // 
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveButton.Image = global::IniTeamView.Properties.Resources.Save;
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(23, 22);
            this.SaveButton.Text = "Save Setting";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuitButton.Image = global::IniTeamView.Properties.Resources.Quit;
            this.QuitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(23, 22);
            this.QuitButton.Text = "Quit Setting";
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(164, 4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // MemberTextBox
            // 
            this.MemberTextBox.Location = new System.Drawing.Point(4, 4);
            this.MemberTextBox.Name = "MemberTextBox";
            this.MemberTextBox.Size = new System.Drawing.Size(141, 21);
            this.MemberTextBox.TabIndex = 0;
            // 
            // MemberGridView
            // 
            this.MemberGridView.AllowUserToAddRows = false;
            this.MemberGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MemberGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemberGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemberColumn});
            this.MemberGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberGridView.Location = new System.Drawing.Point(0, 0);
            this.MemberGridView.Name = "MemberGridView";
            this.MemberGridView.ReadOnly = true;
            this.MemberGridView.RowHeadersVisible = false;
            this.MemberGridView.RowTemplate.Height = 23;
            this.MemberGridView.Size = new System.Drawing.Size(263, 236);
            this.MemberGridView.TabIndex = 0;
            // 
            // MemberColumn
            // 
            this.MemberColumn.HeaderText = "The members in the project";
            this.MemberColumn.Name = "MemberColumn";
            this.MemberColumn.ReadOnly = true;
            this.MemberColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AddMemberButton
            // 
            this.AddMemberButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddMemberButton.Image = global::IniTeamView.Properties.Resources.additem;
            this.AddMemberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddMemberButton.Name = "AddMemberButton";
            this.AddMemberButton.Size = new System.Drawing.Size(23, 22);
            this.AddMemberButton.Text = "Add Member";
            this.AddMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // DeleteMemberButton
            // 
            this.DeleteMemberButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteMemberButton.Image = global::IniTeamView.Properties.Resources.reduceitem;
            this.DeleteMemberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteMemberButton.Name = "DeleteMemberButton";
            this.DeleteMemberButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteMemberButton.Text = "Delete Member";
            this.DeleteMemberButton.Click += new System.EventHandler(this.DeleteMemberButton_Click);
            // 
            // SetFirstMemberButton
            // 
            this.SetFirstMemberButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SetFirstMemberButton.Image = global::IniTeamView.Properties.Resources.BindingOperation;
            this.SetFirstMemberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetFirstMemberButton.Name = "SetFirstMemberButton";
            this.SetFirstMemberButton.Size = new System.Drawing.Size(23, 22);
            this.SetFirstMemberButton.Text = "Set First Member";
            this.SetFirstMemberButton.Click += new System.EventHandler(this.SetFirstMemberButton_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 268);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.SettingToolStrip.ResumeLayout(false);
            this.SettingToolStrip.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox MemberTextBox;
        private System.Windows.Forms.ToolStrip SettingToolStrip;
        private System.Windows.Forms.ToolStripButton AddMemberButton;
        private System.Windows.Forms.ToolStripButton DeleteMemberButton;
        private System.Windows.Forms.ToolStripButton SetFirstMemberButton;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.DataGridView MemberGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemberColumn;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton QuitButton;

    }
}