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

namespace CreatLocalDataBase
{
    public partial class CreateDBForm : Form
    {
        private bool isCreatDB = false;
        private bool isRememberPassword = false;

        public CreateDBForm()
        {
            InitializeComponent();
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
                        Console.WriteLine(ConnectRecord);
                    }
                    DBNameTextBox.Text = ConnectRecord[1];
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

        private string GetConn()
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

        private void CreatTable()
        {
            string source = GetConn() + ";database=" + DBNameTextBox.Text;

            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.Open();
                string sqlOne = "CREATE TABLE bugInfo" + "(version VARCHAR(15) not null,bugNum VARCHAR(500) PRIMARY KEY,bugStatus VARCHAR(20),dealMan VARCHAR(50), description VARCHAR(500),detailDoc IMAGE, createdBy VARCHAR(50),size int not null, timeStamp datetime not null, priority smallint not null, createdTime datetime not null)";
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

        private void CreatDBFun()
        {
            string source = GetConn() + ";database=" + DBNameTextBox.Text;
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

        private bool CreatFile()
        {
            try
            {
                string DBName = DBNameTextBox.Text;
                string connStr = GetConn();
                string s1 = PathComboBox.Text + @"\" + DBName + ".mdf";
                string s2 = PathComboBox.Text + @"\" + DBName + "_log.ldf";
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

        private bool ConnectFile()
        {
            try
            {
                string source = GetConn() + ";database=" + DBNameTextBox.Text;
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

        private void Authentication_comboBox_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Reset_button_Click(object sender, EventArgs e)
        {
            DBNameTextBox.Text = "";
            PasswordTextBox.Text = "";
            PathComboBox.Text = "";
            ServerNameComboBox.Text = "(local)";
            AuthenticationComboBox.Text = "Windows Authentication";
            UserNameComboBox.Text = "";
        }

        private void Creat_button_Click(object sender, EventArgs e)
        {
            CreateDb();

        }

        private void CreateDb()
        {
            if (AuthenticationComboBox.Text == "Windows Authentication" || AuthenticationComboBox.Text == "SQL Server Authentication")
            {
                if (DBNameTextBox.Text == "")
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
                    if (isCreatDB)
                    {
                        if (PathComboBox.Text == "")
                        {
                            MessageBox.Show("The path cann't be empty.");
                        }
                        else
                        {
                            if (CreatFile())
                            {
                                CreatResourceFile();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (ConnectFile())
                        {
                            CreatResourceFile();
                            base.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choese the correct Authentication Method.");
            }
        }

        private void ChoeseCreatButton_Click(object sender, EventArgs e)
        {
            if (!isCreatDB)
            {
                this.Text = "Create DataBase";
                DBNameTextBox.Text = "";
                PathComboBox.Enabled = true;
                ChoesePathButton.Enabled = true;
                CreatButton.Text = "Create";
                isCreatDB = true;
            }
        }

        private void ChoeseConnectButton_Click(object sender, EventArgs e)
        {
            if (isCreatDB)
            {
                this.Text = "Connect DataBase";
                DBNameTextBox.Text = "";
                PathComboBox.Enabled = false;
                PathComboBox.Text = "";
                ChoesePathButton.Enabled = false;
                CreatButton.Text = "Connect";
                isCreatDB = false;
            }
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChoesePath_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                this.PathComboBox.Text = this.folderBrowserDialog1.SelectedPath;
        }



        private void RememberPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (RememberPasswordCheckBox.Checked)
                isRememberPassword = true;
            else
                isRememberPassword = false;
        }

        private void CreatResourceFile()
        {
            string ConnectString = GetConn() + ";database=" + DBNameTextBox.Text;
            using (ResXResourceWriter resx = new ResXResourceWriter(@"ConnectString.resx"))
            {
                resx.AddResource("ConnectString", ConnectString);
            }
            using (ResXResourceWriter resx = new ResXResourceWriter(@"ConnectRecord.resx"))
            {
                if (isRememberPassword)
                    resx.AddResource("isRememberPassword", "true");
                else
                    resx.AddResource("isRememberPassword", "false");
                resx.AddResource("DBName", DBNameTextBox.Text);
                resx.AddResource("ServerName", ServerNameComboBox.Text);
                resx.AddResource("Authentication", AuthenticationComboBox.Text);
                if (AuthenticationComboBox.Text.Equals("SQL Server Authentication"))
                {
                    resx.AddResource("UserName", UserNameComboBox.Text);
                    resx.AddResource("Password", PasswordTextBox.Text);
                }
            }
        }

    }
}