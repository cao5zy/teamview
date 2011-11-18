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
            this.ChoeseCreateButton = new System.Windows.Forms.Button();
            this.ChoeseConnectButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DBNameTextBox = new System.Windows.Forms.TextBox();
            this.PathComboBox = new System.Windows.Forms.ComboBox();
            this.ServerNameComboBox = new System.Windows.Forms.ComboBox();
            this.AuthenticationComboBox = new System.Windows.Forms.ComboBox();
            this.UserNameComboBox = new System.Windows.Forms.ComboBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.CreatButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.CancelOperationButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ChoesePathButton = new System.Windows.Forms.Button();
            this.RememberPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChoeseCreateButton
            // 
            this.ChoeseCreateButton.Location = new System.Drawing.Point(110, 26);
            this.ChoeseCreateButton.Name = "ChoeseCreateButton";
            this.ChoeseCreateButton.Size = new System.Drawing.Size(75, 23);
            this.ChoeseCreateButton.TabIndex = 12;
            this.ChoeseCreateButton.Text = "Create";
            this.ChoeseCreateButton.UseVisualStyleBackColor = true;
            this.ChoeseCreateButton.Click += new System.EventHandler(this.ChoeseCreatButton_Click);
            // 
            // ChoeseConnectButton
            // 
            this.ChoeseConnectButton.Location = new System.Drawing.Point(39, 26);
            this.ChoeseConnectButton.Name = "ChoeseConnectButton";
            this.ChoeseConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ChoeseConnectButton.TabIndex = 11;
            this.ChoeseConnectButton.Text = "connect";
            this.ChoeseConnectButton.UseVisualStyleBackColor = true;
            this.ChoeseConnectButton.Click += new System.EventHandler(this.ChoeseConnectButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "DataBase name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "Server name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Authentication:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "User name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password:";
            // 
            // DBNameTextBox
            // 
            this.DBNameTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.DBNameTextBox.Location = new System.Drawing.Point(140, 68);
            this.DBNameTextBox.Name = "DBNameTextBox";
            this.DBNameTextBox.Size = new System.Drawing.Size(245, 21);
            this.DBNameTextBox.TabIndex = 1;
            // 
            // PathComboBox
            // 
            this.PathComboBox.Enabled = false;
            this.PathComboBox.FormattingEnabled = true;
            this.PathComboBox.Location = new System.Drawing.Point(140, 98);
            this.PathComboBox.Name = "PathComboBox";
            this.PathComboBox.Size = new System.Drawing.Size(202, 20);
            this.PathComboBox.TabIndex = 2;
            // 
            // ServerNameComboBox
            // 
            this.ServerNameComboBox.FormattingEnabled = true;
            this.ServerNameComboBox.Location = new System.Drawing.Point(140, 129);
            this.ServerNameComboBox.Name = "ServerNameComboBox";
            this.ServerNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.ServerNameComboBox.TabIndex = 4;
            this.ServerNameComboBox.Text = "(local)";
            // 
            // AuthenticationComboBox
            // 
            this.AuthenticationComboBox.FormattingEnabled = true;
            this.AuthenticationComboBox.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
            this.AuthenticationComboBox.Location = new System.Drawing.Point(140, 159);
            this.AuthenticationComboBox.Name = "AuthenticationComboBox";
            this.AuthenticationComboBox.Size = new System.Drawing.Size(245, 20);
            this.AuthenticationComboBox.TabIndex = 5;
            this.AuthenticationComboBox.Text = "Windows Authentication";
            this.AuthenticationComboBox.SelectedIndexChanged += new System.EventHandler(this.Authentication_comboBox_SelectedIndexChanged);
            // 
            // UserNameComboBox
            // 
            this.UserNameComboBox.Enabled = false;
            this.UserNameComboBox.FormattingEnabled = true;
            this.UserNameComboBox.Location = new System.Drawing.Point(140, 191);
            this.UserNameComboBox.Name = "UserNameComboBox";
            this.UserNameComboBox.Size = new System.Drawing.Size(245, 20);
            this.UserNameComboBox.TabIndex = 6;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Enabled = false;
            this.PasswordTextBox.Location = new System.Drawing.Point(140, 223);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(171, 21);
            this.PasswordTextBox.TabIndex = 7;
            // 
            // CreatButton
            // 
            this.CreatButton.Location = new System.Drawing.Point(39, 271);
            this.CreatButton.Name = "CreatButton";
            this.CreatButton.Size = new System.Drawing.Size(75, 23);
            this.CreatButton.TabIndex = 8;
            this.CreatButton.Text = "Connect";
            this.CreatButton.UseVisualStyleBackColor = true;
            this.CreatButton.Click += new System.EventHandler(this.Creat_button_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(140, 271);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(75, 23);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.Reset_button_Click);
            // 
            // CancelOperationButton
            // 
            this.CancelOperationButton.Location = new System.Drawing.Point(236, 271);
            this.CancelOperationButton.Name = "CancelOperationButton";
            this.CancelOperationButton.Size = new System.Drawing.Size(75, 23);
            this.CancelOperationButton.TabIndex = 10;
            this.CancelOperationButton.Text = "Cancel";
            this.CancelOperationButton.UseVisualStyleBackColor = true;
            this.CancelOperationButton.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // ChoesePathButton
            // 
            this.ChoesePathButton.Enabled = false;
            this.ChoesePathButton.Location = new System.Drawing.Point(348, 96);
            this.ChoesePathButton.Name = "ChoesePathButton";
            this.ChoesePathButton.Size = new System.Drawing.Size(35, 23);
            this.ChoesePathButton.TabIndex = 3;
            this.ChoesePathButton.Text = "...";
            this.ChoesePathButton.UseVisualStyleBackColor = true;
            this.ChoesePathButton.Click += new System.EventHandler(this.ChoesePath_Click);
            // 
            // RememberPasswordCheckBox
            // 
            this.RememberPasswordCheckBox.AutoSize = true;
            this.RememberPasswordCheckBox.Enabled = false;
            this.RememberPasswordCheckBox.Location = new System.Drawing.Point(317, 225);
            this.RememberPasswordCheckBox.Name = "RememberPasswordCheckBox";
            this.RememberPasswordCheckBox.Size = new System.Drawing.Size(72, 16);
            this.RememberPasswordCheckBox.TabIndex = 16;
            this.RememberPasswordCheckBox.Text = "Remember";
            this.RememberPasswordCheckBox.UseVisualStyleBackColor = true;
            this.RememberPasswordCheckBox.CheckedChanged += new System.EventHandler(this.RememberPassword_CheckedChanged);
            // 
            // CreateDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 347);
            this.Controls.Add(this.RememberPasswordCheckBox);
            this.Controls.Add(this.ChoesePathButton);
            this.Controls.Add(this.CancelOperationButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.CreatButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.UserNameComboBox);
            this.Controls.Add(this.AuthenticationComboBox);
            this.Controls.Add(this.ServerNameComboBox);
            this.Controls.Add(this.PathComboBox);
            this.Controls.Add(this.DBNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ChoeseConnectButton);
            this.Controls.Add(this.ChoeseCreateButton);
            this.Name = "CreateDBForm";
            this.Text = "Connect DataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChoeseCreateButton;
        private System.Windows.Forms.Button ChoeseConnectButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DBNameTextBox;
        private System.Windows.Forms.ComboBox AuthenticationComboBox;
        private System.Windows.Forms.ComboBox UserNameComboBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Button CreatButton;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button CancelOperationButton;
        public System.Windows.Forms.ComboBox ServerNameComboBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ChoesePathButton;
        private System.Windows.Forms.CheckBox RememberPasswordCheckBox;
        public System.Windows.Forms.ComboBox PathComboBox;
    }
}