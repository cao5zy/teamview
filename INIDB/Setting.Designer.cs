namespace CreatLocalDataBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.SettingToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddMemberButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteMemberButton = new System.Windows.Forms.ToolStripButton();
            this.SetFirstMemberButton = new System.Windows.Forms.ToolStripButton();
            this.MemberTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MemberListBox = new System.Windows.Forms.ListBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SettingToolStrip.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            this.splitContainer1.Panel1.Controls.Add(this.MemberTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.MemberListBox);
            this.splitContainer1.Size = new System.Drawing.Size(238, 268);
            this.splitContainer1.SplitterDistance = 28;
            this.splitContainer1.TabIndex = 0;
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
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.SettingToolStrip);
            // 
            // SettingToolStrip
            // 
            this.SettingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SettingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SettingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMemberButton,
            this.DeleteMemberButton,
            this.SetFirstMemberButton});
            this.SettingToolStrip.Location = new System.Drawing.Point(3, 0);
            this.SettingToolStrip.Name = "SettingToolStrip";
            this.SettingToolStrip.Size = new System.Drawing.Size(72, 25);
            this.SettingToolStrip.TabIndex = 4;
            this.SettingToolStrip.Text = "toolStrip1";
            // 
            // AddMemberButton
            // 
            this.AddMemberButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddMemberButton.Image = global::CreatLocalDataBase.Properties.Resources.additem;
            this.AddMemberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddMemberButton.Name = "AddMemberButton";
            this.AddMemberButton.Size = new System.Drawing.Size(23, 22);
            this.AddMemberButton.Text = "Add Member";
            this.AddMemberButton.Click += new System.EventHandler(this.AddMemberButton_Click);
            // 
            // DeleteMemberButton
            // 
            this.DeleteMemberButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteMemberButton.Image = global::CreatLocalDataBase.Properties.Resources.reduceitem;
            this.DeleteMemberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteMemberButton.Name = "DeleteMemberButton";
            this.DeleteMemberButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteMemberButton.Text = "Delete Member";
            this.DeleteMemberButton.Click += new System.EventHandler(this.DeleteMemberButton_Click);
            // 
            // SetFirstMemberButton
            // 
            this.SetFirstMemberButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SetFirstMemberButton.Image = ((System.Drawing.Image)(resources.GetObject("SetFirstMemberButton.Image")));
            this.SetFirstMemberButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetFirstMemberButton.Name = "SetFirstMemberButton";
            this.SetFirstMemberButton.Size = new System.Drawing.Size(23, 22);
            this.SetFirstMemberButton.Text = "Set First Member";
            this.SetFirstMemberButton.Click += new System.EventHandler(this.SetFirstMemberButton_Click);
            // 
            // MemberTextBox
            // 
            this.MemberTextBox.Location = new System.Drawing.Point(4, 4);
            this.MemberTextBox.Name = "MemberTextBox";
            this.MemberTextBox.Size = new System.Drawing.Size(141, 21);
            this.MemberTextBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 26);
            this.button1.TabIndex = 3;
            this.button1.Text = "The members in project";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MemberListBox
            // 
            this.MemberListBox.FormattingEnabled = true;
            this.MemberListBox.ItemHeight = 12;
            this.MemberListBox.Location = new System.Drawing.Point(0, 24);
            this.MemberListBox.Name = "MemberListBox";
            this.MemberListBox.Size = new System.Drawing.Size(241, 220);
            this.MemberListBox.TabIndex = 2;
            this.MemberListBox.SelectedIndexChanged += new System.EventHandler(this.MemberListBox_SelectedIndexChanged);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 268);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.SettingToolStrip.ResumeLayout(false);
            this.SettingToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox MemberListBox;
        private System.Windows.Forms.TextBox MemberTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip SettingToolStrip;
        private System.Windows.Forms.ToolStripButton AddMemberButton;
        private System.Windows.Forms.ToolStripButton DeleteMemberButton;
        private System.Windows.Forms.ToolStripButton SetFirstMemberButton;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;

    }
}