using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.IO;
using System.Xml;
using System.Configuration;
using BugInfo.Common;

namespace CreatLocalDataBase
{
    public partial class CreateDBForm : Form
    {
        private bool isCreatDB = false;
        public static string DbName = "";

        private IItemImporter mImporter;
        public CreateDBForm(IItemImporter importer):this()
        {
            mImporter = importer;
        }
        public CreateDBForm()
        {
            InitializeComponent();
            if (File.Exists(Application.StartupPath + @"\DbRecord.resx"))
            {
                using (ResXResourceReader resr = new ResXResourceReader(@"DbRecord.resx"))
                {
                    string DbString = "";
                    foreach (DictionaryEntry d in resr)
                    {
                        DbString = d.Value as string;
                    }
                    DBNameComboBox.Items.Clear();
                    DBNameComboBox.Items.AddRange(DbString.Split(','));
                }
            }

            if (File.Exists(Application.StartupPath + @"\ConnectRecord.resx"))
            {
                using (ResXResourceReader resr = new ResXResourceReader(@"ConnectRecord.resx"))
                {
                    string[] ConnectRecord = new string[6];
                    int i = 0;
                    foreach (DictionaryEntry d in resr)
                    {
                        ConnectRecord[i] = d.Value as string;
                        i++;
                    }
                    DBNameComboBox.Text = ConnectRecord[1];
                    ServerNameComboBox.Text = ConnectRecord[2];
                    AuthenticationComboBox.Text = ConnectRecord[3];
                    if (ConnectRecord[3] == "SQL Server Authentication")
                    {
                        UserNameComboBox.Text = ConnectRecord[4];
                        if (ConnectRecord[0] == "true")
                        {
                            PasswordTextBox.Text = ConnectRecord[5];
                            RememberPasswordCheckBox.Checked = true;
                        }
                    }
                }
            }
            if (File.Exists(Application.StartupPath + @"\CreateRecord.resx"))
            {
                using (ResXResourceReader resr = new ResXResourceReader(@"CreateRecord.resx"))
                {
                    string[] CreateRecord = new string[7];
                    int i = 0;
                    foreach (DictionaryEntry d in resr)
                    {
                        CreateRecord[i] = d.Value as string;
                        i++;
                    }
                    CPathComboBox.Text = CreateRecord[2];
                    CServerNameComboBox.Text = CreateRecord[3];
                    CAuthenticationComboBox.Text = CreateRecord[4];
                    if (CreateRecord[4] == "SQL Server Authentication")
                    {
                        CUserNameComboBox.Text = CreateRecord[5];
                        if (CreateRecord[0] == "true")
                        {
                            CPasswordTextBox.Text = CreateRecord[6];
                            CRememberPasswordCheckBox.Checked = true;
                        }
                    }
                }
            }


        }

        private string GetConn()
        {
            if (isCreatDB)
            {
                if (CAuthenticationComboBox.Text == "Windows Authentication")
                {
                    return "server=" + CServerNameComboBox.Text + ";Integrated Security=true";
                }
                else
                {
                    return "server=" + CServerNameComboBox.Text + ";Integrated Security=false;User ID=" + CUserNameComboBox.Text + ";password=" + CPasswordTextBox.Text;
                }
            }
            else
            {
                if (AuthenticationComboBox.Text == "Windows Authentication")
                {
                    return "server=" + ServerNameComboBox.Text + ";Integrated Security=true";
                }
                else
                {
                    return "server=" + ServerNameComboBox.Text + ";Integrated Security=false;User ID=" + UserNameComboBox.Text + ";password=" + PasswordTextBox.Text;
                }
            }
        }

        private void CreatResourceFile()
        {
            if (isCreatDB)
            {
                string ConnectString = GetConn() + ";database=" + CDBNameTextBox.Text;
                using (ResXResourceWriter resx = new ResXResourceWriter(@"ConnectString.resx"))
                {
                    resx.AddResource("ConnectString", ConnectString);
                }
                using (ResXResourceWriter resx = new ResXResourceWriter(@"DbRecord.resx"))
                {
                    string DbString = "";
                    if (DBNameComboBox.Items.IndexOf(CDBNameTextBox.Text) < 0)
                    {
                        DbString = CDBNameTextBox.Text;
                        for (int i = 0; i < DBNameComboBox.Items.Count; i++)
                        {
                            DbString += "," + DBNameComboBox.Items[i].ToString();
                        }
                    }
                    else
                    {
                        if (DBNameComboBox.Items.Count > 1)
                            DbString = DBNameComboBox.Items[0].ToString();
                        for (int i = 1; i < DBNameComboBox.Items.Count; i++)
                        {
                            DbString += "," + DBNameComboBox.Items[i].ToString();
                        }
                    }
                    resx.AddResource("DbString",DbString);
                }
                using (ResXResourceWriter resx = new ResXResourceWriter(@"CreateRecord.resx"))
                {
                    if (CRememberPasswordCheckBox.Checked)
                        resx.AddResource("isRememberPassword", "true");
                    else
                        resx.AddResource("isRememberPassword", "false");
                    resx.AddResource("DBName", CDBNameTextBox.Text);
                    resx.AddResource("Path",CPathComboBox.Text);
                    resx.AddResource("ServerName", CServerNameComboBox.Text);
                    resx.AddResource("Authentication", CAuthenticationComboBox.Text);
                    if (CAuthenticationComboBox.Text.Equals("SQL Server Authentication"))
                    {
                        resx.AddResource("UserName", CUserNameComboBox.Text);
                        resx.AddResource("Password", CPasswordTextBox.Text);
                    }
                }
            }
            else
            {
                string ConnectString = GetConn() + ";database=" + DBNameComboBox.Text;
                using (ResXResourceWriter resx = new ResXResourceWriter(@"ConnectString.resx"))
                {
                    resx.AddResource("ConnectString", ConnectString);
                }
                using (ResXResourceWriter resx = new ResXResourceWriter(@"ConnectRecord.resx"))
                {
                    if (RememberPasswordCheckBox.Checked)
                        resx.AddResource("isRememberPassword", "true");
                    else
                        resx.AddResource("isRememberPassword", "false");
                    resx.AddResource("DBName", DBNameComboBox.Text);
                    resx.AddResource("ServerName", ServerNameComboBox.Text);
                    resx.AddResource("Authentication", AuthenticationComboBox.Text);
                    if (AuthenticationComboBox.Text.Equals("SQL Server Authentication"))
                    {
                        resx.AddResource("UserName", UserNameComboBox.Text);
                        resx.AddResource("Password", PasswordTextBox.Text);
                    }
                }
                using (ResXResourceWriter resx = new ResXResourceWriter(DBNameComboBox.Text+@"ConnectRecord.resx"))
                {
                    if (RememberPasswordCheckBox.Checked)
                        resx.AddResource("isRememberPassword", "true");
                    else
                        resx.AddResource("isRememberPassword", "false");
                    resx.AddResource("DBName", DBNameComboBox.Text);
                    resx.AddResource("ServerName", ServerNameComboBox.Text);
                    resx.AddResource("Authentication", AuthenticationComboBox.Text);
                    if (AuthenticationComboBox.Text.Equals("SQL Server Authentication"))
                    {
                        resx.AddResource("UserName", UserNameComboBox.Text);
                        resx.AddResource("Password", PasswordTextBox.Text);
                    }
                }
                using (ResXResourceWriter resx = new ResXResourceWriter(@"DbRecord.resx"))
                {
                    string DbString = "";
                    if (DBNameComboBox.Items.IndexOf(DBNameComboBox.Text) < 0)
                    {
                        DbString = DBNameComboBox.Text;
                        for (int i = 0; i < DBNameComboBox.Items.Count; i++)
                        {
                            DbString += "," + DBNameComboBox.Items[i].ToString();
                        }
                    }
                    else
                    {
                        if (DBNameComboBox.Items.Count > 1)
                            DbString = DBNameComboBox.Items[0].ToString();
                        for (int i = 1; i < DBNameComboBox.Items.Count; i++)
                        {
                            DbString += "," + DBNameComboBox.Items[i].ToString();
                        }
                    }
                    resx.AddResource("DbString", DbString);
                }
            }
        }

        private void CreatDBFun()
        {
            string source = GetConn() + ";database=" + CDBNameTextBox.Text;
            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.Open();
                string sql = @"
                    CREATE function [MergeLog](@BugNum varchar(500))
                    returns varchar(1000)
                    as
                    begin
                        declare @S varchar(1000)
                        select @S=isnull(@S+' , ','') + Convert(varchar(10),L.CreateDate, 120) + ':'  + L.[Description] + char(13) + char(10) from [ChangeLog] L 
                        where L.BugNum = @BugNum
                        return @S
                    end";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ExecuteSql(string conn, string DatabaseName, string Sql)
        {
            System.Data.SqlClient.SqlConnection mySqlConnection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(Sql, mySqlConnection);
            using (Command.Connection)
            {
                Command.Connection.Open();
                Command.Connection.ChangeDatabase(DatabaseName);
                Command.ExecuteNonQuery();
            }
        }

        private void CreatTable()
        {
            string source = GetConn() + ";database=" + CDBNameTextBox.Text;

            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.Open();
                string sqlOne = "CREATE TABLE bugInfo" + "(version VARCHAR(15) not null,bugNum VARCHAR(500) PRIMARY KEY,bugStatus VARCHAR(20),dealMan VARCHAR(50), description VARCHAR(500),detailDoc IMAGE, createdMan VARCHAR(50),size int not null, timeStamp datetime not null, priority smallint not null, createdTime datetime not null)";
                string sqlTwo = "CREATE TABLE ChangeLog" + "(LogID BIGINT PRIMARY KEY,BugNum VARCHAR(500) not null,CreateDate datetime not null, Description VARCHAR(80) not null,LogTypeID int not null)";
                string sqlThree = "CREATE TABLE pointslog" + "(pointslogid BIGINT PRIMARY KEY,bugnum VARCHAR(500) not null,[log] VARCHAR(100) not null, createdtime datetime not null)";

                SqlCommand cmdOne = new SqlCommand(sqlOne, conn);
                SqlCommand cmdTwo = new SqlCommand(sqlTwo, conn);
                SqlCommand cmdThree = new SqlCommand(sqlThree, conn);

                SqlTransaction tx = conn.BeginTransaction();
                cmdOne.Transaction = tx;
                cmdTwo.Transaction = tx;
                cmdThree.Transaction = tx;

                try
                {
                    cmdOne.ExecuteNonQuery();
                    cmdTwo.ExecuteNonQuery();
                    cmdThree.ExecuteNonQuery();
                    tx.Commit();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    tx.Rollback();
                }
            }
        }

        private bool CreatFile()
        {
            try
            {
                string DBName = CDBNameTextBox.Text;
                string connStr = GetConn();
                string s1 = CPathComboBox.Text + @"\" + DBName + ".mdf";
                string s2 = CPathComboBox.Text + @"\" + DBName + "_log.ldf";
                string sql = "CREATE DATABASE " + DBName + " ON PRIMARY" + "(name=" + DBName + ",filename ='" + s1 + "', size=3," + "maxsize=5,filegrowth=10%)log on" + "(name=" + DBName + "_log,filename='" + s2 + "',size=3," + "maxsize=20,filegrowth=1)";
                ExecuteSql(connStr, "master", sql);
                CreatTable();
                CreatDBFun();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void CreateDb()
        {
            if (CAuthenticationComboBox.Text == "Windows Authentication" || CAuthenticationComboBox.Text == "SQL Server Authentication")
            {
                if (CDBNameTextBox.Text == "")
                {
                    MessageBox.Show("The DataBase Name cann't be empty.");
                }
                else
                {
                    if (CAuthenticationComboBox.Text == "SQL Server Authentication")
                    {
                        if (CUserNameComboBox.Text == "")
                        {
                            MessageBox.Show("The User Name cann't be empty.");
                            return;
                        }
                        if (CPasswordTextBox.Text == "")
                        {
                            MessageBox.Show("The Password cann't be empty.");
                            return;
                        }
                    }
                    if (CPathComboBox.Text == "")
                    {
                        MessageBox.Show("The path cann't be empty.");
                    }
                    else
                    {
                        if (CreatFile())
                        {
                            CreatResourceFile();
                            MessageBox.Show("Creating the Database has been successful.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choese the correct Authentication Method.");
            }
        }

        private void ConnectDb()
        {
            if (AuthenticationComboBox.Text == "Windows Authentication" || AuthenticationComboBox.Text == "SQL Server Authentication")
            {
                if (DBNameComboBox.Text == "")
                {
                    MessageBox.Show("The DataBase Name cann't be empty.");
                }
                else
                {
                    if (AuthenticationComboBox.Text == "SQL Server Authentication")
                    {
                        if (UserNameComboBox.Text == "")
                        {
                            MessageBox.Show("The User Name cann't be empty.");
                            return;
                        }
                        if (PasswordTextBox.Text == "")
                        {
                            MessageBox.Show("The Password cann't be empty.");
                            return;
                        }
                    }

                    if (ConnectFile())
                    {
                        CreatResourceFile();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choese the correct Authentication Method.");
            }
        }


        private bool ConnectFile()
        {
            try
            {
                string source = GetConn() + ";database=" + DBNameComboBox.Text;
                SqlConnection conn = new SqlConnection(source);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private void CChoesePathButton_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.CPathComboBox.Text = this.folderBrowserDialog1.SelectedPath;
        }

        private void CAuthenticationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CAuthenticationComboBox.Text == "Windows Authentication")
            {
                CUserNameComboBox.Enabled = false;
                CPasswordTextBox.Enabled = false;
                CRememberPasswordCheckBox.Enabled = false;
                CRememberPasswordCheckBox.Checked = false;
                CUserNameComboBox.Text = "";
                CPasswordTextBox.Text = "";
            }
            else
            {
                CUserNameComboBox.Enabled = true;
                CPasswordTextBox.Enabled = true;
                CRememberPasswordCheckBox.Enabled = true;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            isCreatDB = true;
            CreateDb();
            this.tabControl1.SelectedIndex = 0;
        }

        private void CReset_Click(object sender, EventArgs e)
        {
            CDBNameTextBox.Text = "";
            CPathComboBox.Text = "";
            CServerNameComboBox.Text = "(local)";
            CAuthenticationComboBox.Text = "Windows Authentication";
        }

        private void CancelCreateButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AuthenticationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AuthenticationComboBox.Text == "Windows Authentication")
            {
                UserNameComboBox.Enabled = false;
                PasswordTextBox.Enabled = false;
                RememberPasswordCheckBox.Enabled = false;
                RememberPasswordCheckBox.Checked = false;
                UserNameComboBox.Text = "";
                PasswordTextBox.Text = "";
            }
            else
            {
                UserNameComboBox.Enabled = true;
                PasswordTextBox.Enabled = true;
                RememberPasswordCheckBox.Enabled = true;
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            isCreatDB = false;
            ConnectDb();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DBNameComboBox.Text = "";
            PathComboBox.Text = "";
            ServerNameComboBox.Text = "(local)";
            AuthenticationComboBox.Text = "Windows Authentication";
        }

        private void CancelConnectButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void SettingButton_Click(object sender, EventArgs e)
        {
            DbName = DBNameComboBox.Text;
            new Setting().Show();
        }

        private void DBNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\" + DBNameComboBox.Text + "ConnectRecord.resx"))
            {
                using (ResXResourceReader resr = new ResXResourceReader(DBNameComboBox.Text + @"ConnectRecord.resx"))
                {
                    string[] ConnectRecord = new string[6];
                    int i = 0;
                    foreach (DictionaryEntry d in resr)
                    {
                        ConnectRecord[i] = d.Value as string;
                        i++;
                    }
                    DBNameComboBox.Text = ConnectRecord[1];
                    ServerNameComboBox.Text = ConnectRecord[2];
                    AuthenticationComboBox.Text = ConnectRecord[3];
                    if (ConnectRecord[3] == "SQL Server Authentication")
                    {
                        UserNameComboBox.Text = ConnectRecord[4];
                        if (ConnectRecord[0] == "true")
                        {
                            PasswordTextBox.Text = ConnectRecord[5];
                            RememberPasswordCheckBox.Checked = true;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mImporter.Import(@"z:\temp\JIRA.xml", "3.1", "客户", "导入中心", 1);
        }

    }
}