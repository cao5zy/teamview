using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CreatLocalDataBase
{
    public partial class CreatDBForm : Form
    {
        public CreatDBForm()
        {
            InitializeComponent();
        }

        //创建表
        private void CreatTable()
        {
            string source = "server=(local);integrated security=SSPI;database=" + textBox1.Text;
            SqlConnection conn1 = new SqlConnection(source);
            conn1.Open();
            string sqlOne = "CREATE TABLE bugInfo" + "(version VARCHAR(15) not null,bugNum VARCHAR(500) PRIMARY KEY,bugStatus VARCHAR(20),dealMan VARCHAR(50), description VARCHAR(500),detailDoc IMAGE, createBy VARCHAR(50),size int not null, timeStamp datetime not null, priority smallint not null, createdTime datetime not null)";
            SqlCommand cmdOne = new SqlCommand(sqlOne, conn1);
            try
            {
                cmdOne.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            string sqlTwo = "CREATE TABLE ChangeLog" + "(LogID BIGINT PRIMARY KEY,BugNum VARCHAR(500) not null,CreatDate datetime not null, Description VARCHAR(80) not null,LogTypeID int not null)";
            SqlCommand cmdTwo = new SqlCommand(sqlTwo, conn1);
            try
            {
                cmdTwo.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            string sqlThree = "CREATE TABLE pointslog" + "(pointslogid BIGINT PRIMARY KEY,bugnum VARCHAR(500) not null,[log] VARCHAR(100) not null, createdtime datetime not null)";
            SqlCommand cmdThree = new SqlCommand(sqlThree, conn1);
            try
            {
                cmdThree.ExecuteNonQuery();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            conn1.Close();
        }

        //创建数据库
        private void ExecuteSql(string conn, string DatabaseName, string Sql)
        {
            System.Data.SqlClient.SqlConnection mySqlConnection = new System.Data.SqlClient.SqlConnection(conn);
            System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(Sql, mySqlConnection);
            Command.Connection.Open();
            Command.Connection.ChangeDatabase(DatabaseName);
            try
            {
                Command.ExecuteNonQuery();
            }
            finally
            {
                Command.Connection.Close();
            }     
        }

        private bool execfile()
        {
            try
            {
                string DBName = textBox1.Text;
                string connStr = "server=(local);integrated security=SSPI";
                string s1 = @"E:\mysql\"+DBName+".mdf";
                string s2 = @"E:\mysql\" + DBName + "_log.ldf";
                string sql = "CREATE DATABASE " + DBName + " ON PRIMARY" + "(name=" + DBName + ",filename ='"+s1+"', size=3," + "maxsize=5,filegrowth=10%)log on" + "(name=" + DBName + "_log,filename='"+s2+"',size=3," + "maxsize=20,filegrowth=1)";
                ExecuteSql(connStr, "master", sql);//调用ExecuteNonQuery()来创建数据库
                CreatTable();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (execfile())
            {
                MessageBox.Show("数据库创建成功");
            }
            else
            {
                MessageBox.Show("数据库创建失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
