namespace CreatLocalDataBase
{
    partial class CreateDBForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.SettingButton = new System.Windows.Forms.Button();
            this.CancelConnectButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ChoesePathButton = new System.Windows.Forms.Button();
            this.RememberPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.UserNameComboBox = new System.Windows.Forms.ComboBox();
            this.AuthenticationComboBox = new System.Windows.Forms.ComboBox();
            this.ServerNameComboBox = new System.Windows.Forms.ComboBox();
            this.PathComboBox = new System.Windows.Forms.ComboBox();
            this.DBNameComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CancelCreateButton = new System.Windows.Forms.Button();
            this.CReset = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CChoesePathButton = new System.Windows.Forms.Button();
            this.CRememberPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.CPasswordTextBox = new System.Windows.Forms.TextBox();
            this.CUserNameComboBox = new System.Windows.Forms.ComboBox();
            this.CAuthenticationComboBox = new System.Windows.Forms.ComboBox();
            this.CServerNameComboBox = new System.Windows.Forms.ComboBox();
            this.CPathComboBox = new System.Windows.Forms.ComboBox();
            this.CDBNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-4, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(414, 311);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.SettingButton);
            this.tabPage1.Controls.Add(this.CancelConnectButton);
            this.tabPage1.Controls.Add(this.ResetButton);
            this.tabPage1.Controls.Add(this.ConnectButton);
            this.tabPage1.Controls.Add(this.ChoesePathButton);
            this.tabPage1.Controls.Add(this.RememberPasswordCheckBox);
            this.tabPage1.Controls.Add(this.PasswordTextBox);
            this.tabPage1.Controls.Add(this.UserNameComboBox);
            this.tabPage1.Controls.Add(this.AuthenticationComboBox);
            this.tabPage1.Controls.Add(this.ServerNameComboBox);
            this.tabPage1.Controls.Add(this.PathComboBox);
            this.tabPage1.Controls.Add(this.DBNameComboBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(406, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connet";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // SettingButton
            // 
            this.SettingButton.Location = new System.Drawing.Point(210, 236);
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.Size = new System.Drawing.Size(75, 23);
            this.SettingButton.TabIndex = 28;
            this.SettingButton.Text = "Setting";
            this.SettingButton.UseVisualStyleBackColor = true;
            this.SettingButton.Click += new System.EventHandler(this.SettingButton_Click);
            // 
            // CancelConnectButton
            // 
            this.CancelConnectButton.Location = new System.Drawing.Point(302, 236);
            this.CancelConnectButton.Name = "CancelConnectButton";
            this.CancelConnectButton.Size = new System.Drawing.Size(75, 23);
            this.CancelConnectButton.TabIndex = 27;
            this.CancelConnectButton.Text = "Cancel";
            this.CancelConnectButton.UseVisualStyleBackColor = true;
            this.CancelConnectButton.Click += new System.EventHandler(this.CancelConnectButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(118, 236);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 26;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(23, 236);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 25;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ChoesePathButton
            // 
            this.ChoesePathButton.Enabled = false;
            this.ChoesePathButton.Location = new System.Drawing.Point(342, 60);
            this.ChoesePathButton.Name = "ChoesePathButton";
            this.ChoesePathButton.Size = new System.Drawing.Size(35, 23);
            this.ChoesePathButton.TabIndex = 24;
            this.ChoesePathButton.Text = "...";
            this.ChoesePathButton.UseVisualStyleBackColor = true;
            // 
            // RememberPasswordCheckBox
            // 
            this.RememberPasswordCheckBox.AutoSize = true;
            this.RememberPasswordCheckBox.Enabled = false;
            this.RememberPasswordCheckBox.Location = new System.Drawing.Point(305, 192);
            this.RememberPasswordCheckBox.Name = "RememberPasswordCheckBox";
            this.RememberPasswordCheckBox.Size = new System.Drawing.Size(72, 16);
            this.RememberPasswordCheckBox.TabIndex = 23;
            this.RememberPasswordCheckBox.Text = "Remember";
            this.RememberPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.Location = new System.Drawing.Point(132, 190);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(171, 21);
            this.PasswordTextBox.TabIndex = 22;
            // 
            // UserNameComboBox
            // 
            this.UserNameComboBox.Enabled = false;
            this.UserNameComboBox.FormattingEnabled = true;
            this.UserNameComboBox.Location = new System.Drawing.Point(132, 158);
            this.UserNameComboBox.Name = "UserNameComboBox";
            this.UserNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.UserNameComboBox.TabIndex = 21;
            // 
            // AuthenticationComboBox
            // 
            this.AuthenticationComboBox.FormattingEnabled = true;
            this.AuthenticationComboBox.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.AuthenticationComboBox.Location = new System.Drawing.Point(132, 126);
            this.AuthenticationComboBox.Name = "AuthenticationComboBox";
            this.AuthenticationComboBox.Size = new System.Drawing.Size(245, 20);
            this.AuthenticationComboBox.TabIndex = 20;
            this.AuthenticationComboBox.Text = "Windows Authentication";
            this.AuthenticationComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthenticationComboBox_SelectedIndexChanged);
            // 
            // ServerNameComboBox
            // 
            this.ServerNameComboBox.FormattingEnabled = true;
            this.ServerNameComboBox.Location = new System.Drawing.Point(132, 94);
            this.ServerNameComboBox.Name = "ServerNameComboBox";
            this.ServerNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.ServerNameComboBox.TabIndex = 19;
            this.ServerNameComboBox.Text = "(local)";
            // 
            // PathComboBox
            // 
            this.PathComboBox.Enabled = false;
            this.PathComboBox.FormattingEnabled = true;
            this.PathComboBox.Location = new System.Drawing.Point(132, 62);
            this.PathComboBox.Name = "PathComboBox";
            this.PathComboBox.Size = new System.Drawing.Size(202, 20);
            this.PathComboBox.TabIndex = 18;
            // 
            // DBNameComboBox
            // 
            this.DBNameComboBox.FormattingEnabled = true;
            this.DBNameComboBox.Location = new System.Drawing.Point(132, 30);
            this.DBNameComboBox.Name = "DBNameComboBox";
            this.DBNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.DBNameComboBox.TabIndex = 17;
            this.DBNameComboBox.SelectedIndexChanged += new System.EventHandler(this.DBNameComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "User name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "Authentication:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Server name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Path:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "DataBase name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CancelCreateButton);
            this.tabPage2.Controls.Add(this.CReset);
            this.tabPage2.Controls.Add(this.CreateButton);
            this.tabPage2.Controls.Add(this.CChoesePathButton);
            this.tabPage2.Controls.Add(this.CRememberPasswordCheckBox);
            this.tabPage2.Controls.Add(this.CPasswordTextBox);
            this.tabPage2.Controls.Add(this.CUserNameComboBox);
            this.tabPage2.Controls.Add(this.CAuthenticationComboBox);
            this.tabPage2.Controls.Add(this.CServerNameComboBox);
            this.tabPage2.Controls.Add(this.CPathComboBox);
            this.tabPage2.Controls.Add(this.CDBNameTextBox);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(406, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CancelCreateButton
            // 
            this.CancelCreateButton.Location = new System.Drawing.Point(236, 236);
            this.CancelCreateButton.Name = "CancelCreateButton";
            this.CancelCreateButton.Size = new System.Drawing.Size(75, 23);
            this.CancelCreateButton.TabIndex = 44;
            this.CancelCreateButton.Text = "Cancel";
            this.CancelCreateButton.UseVisualStyleBackColor = true;
            this.CancelCreateButton.Click += new System.EventHandler(this.CancelCreateButton_Click);
            // 
            // CReset
            // 
            this.CReset.Location = new System.Drawing.Point(129, 236);
            this.CReset.Name = "CReset";
            this.CReset.Size = new System.Drawing.Size(75, 23);
            this.CReset.TabIndex = 43;
            this.CReset.Text = "Reset";
            this.CReset.UseVisualStyleBackColor = true;
            this.CReset.Click += new System.EventHandler(this.CReset_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(23, 236);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 42;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CChoesePathButton
            // 
            this.CChoesePathButton.Location = new System.Drawing.Point(342, 60);
            this.CChoesePathButton.Name = "CChoesePathButton";
            this.CChoesePathButton.Size = new System.Drawing.Size(35, 23);
            this.CChoesePathButton.TabIndex = 41;
            this.CChoesePathButton.Text = "...";
            this.CChoesePathButton.UseVisualStyleBackColor = true;
            this.CChoesePathButton.Click += new System.EventHandler(this.CChoesePathButton_Click);
            // 
            // CRememberPasswordCheckBox
            // 
            this.CRememberPasswordCheckBox.AutoSize = true;
            this.CRememberPasswordCheckBox.Enabled = false;
            this.CRememberPasswordCheckBox.Location = new System.Drawing.Point(305, 192);
            this.CRememberPasswordCheckBox.Name = "CRememberPasswordCheckBox";
            this.CRememberPasswordCheckBox.Size = new System.Drawing.Size(72, 16);
            this.CRememberPasswordCheckBox.TabIndex = 40;
            this.CRememberPasswordCheckBox.Text = "Remember";
            this.CRememberPasswordCheckBox.UseVisualStyleBackColor = true;
            // 
            // CPasswordTextBox
            // 
            this.CPasswordTextBox.Enabled = false;
            this.CPasswordTextBox.Location = new System.Drawing.Point(132, 190);
            this.CPasswordTextBox.Name = "CPasswordTextBox";
            this.CPasswordTextBox.PasswordChar = '*';
            this.CPasswordTextBox.Size = new System.Drawing.Size(171, 21);
            this.CPasswordTextBox.TabIndex = 39;
            // 
            // CUserNameComboBox
            // 
            this.CUserNameComboBox.Enabled = false;
            this.CUserNameComboBox.FormattingEnabled = true;
            this.CUserNameComboBox.Location = new System.Drawing.Point(132, 158);
            this.CUserNameComboBox.Name = "CUserNameComboBox";
            this.CUserNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.CUserNameComboBox.TabIndex = 38;
            // 
            // CAuthenticationComboBox
            // 
            this.CAuthenticationComboBox.FormattingEnabled = true;
            this.CAuthenticationComboBox.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.CAuthenticationComboBox.Location = new System.Drawing.Point(132, 126);
            this.CAuthenticationComboBox.Name = "CAuthenticationComboBox";
            this.CAuthenticationComboBox.Size = new System.Drawing.Size(245, 20);
            this.CAuthenticationComboBox.TabIndex = 37;
            this.CAuthenticationComboBox.Text = "Windows Authentication";
            this.CAuthenticationComboBox.SelectedIndexChanged += new System.EventHandler(this.CAuthenticationComboBox_SelectedIndexChanged);
            // 
            // CServerNameComboBox
            // 
            this.CServerNameComboBox.FormattingEnabled = true;
            this.CServerNameComboBox.Location = new System.Drawing.Point(132, 94);
            this.CServerNameComboBox.Name = "CServerNameComboBox";
            this.CServerNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.CServerNameComboBox.TabIndex = 36;
            this.CServerNameComboBox.Text = "(local)";
            // 
            // CPathComboBox
            // 
            this.CPathComboBox.FormattingEnabled = true;
            this.CPathComboBox.Location = new System.Drawing.Point(132, 62);
            this.CPathComboBox.Name = "CPathComboBox";
            this.CPathComboBox.Size = new System.Drawing.Size(202, 20);
            this.CPathComboBox.TabIndex = 35;
            // 
            // CDBNameTextBox
            // 
            this.CDBNameTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.CDBNameTextBox.Location = new System.Drawing.Point(132, 30);
            this.CDBNameTextBox.Name = "CDBNameTextBox";
            this.CDBNameTextBox.Size = new System.Drawing.Size(245, 21);
            this.CDBNameTextBox.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "User name:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "Authentication:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "Server name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 29;
            this.label14.Text = "Path:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 28;
            this.label15.Text = "DataBase name:";
            // 
            // CreateDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 302);
            this.Controls.Add(this.tabControl1);
            this.Name = "CreateDBForm";
            this.Text = "Connect DataBase";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button CancelConnectButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button ChoesePathButton;
        private System.Windows.Forms.CheckBox RememberPasswordCheckBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.ComboBox UserNameComboBox;
        private System.Windows.Forms.ComboBox AuthenticationComboBox;
        public System.Windows.Forms.ComboBox ServerNameComboBox;
        public System.Windows.Forms.ComboBox PathComboBox;
        private System.Windows.Forms.ComboBox DBNameComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button CancelCreateButton;
        private System.Windows.Forms.Button CReset;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CChoesePathButton;
        private System.Windows.Forms.CheckBox CRememberPasswordCheckBox;
        private System.Windows.Forms.TextBox CPasswordTextBox;
        private System.Windows.Forms.ComboBox CUserNameComboBox;
        private System.Windows.Forms.ComboBox CAuthenticationComboBox;
        public System.Windows.Forms.ComboBox CServerNameComboBox;
        public System.Windows.Forms.ComboBox CPathComboBox;
        private System.Windows.Forms.TextBox CDBNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button SettingButton;
    }
}