using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Resources;
using System.Collections;
using CreatLocalDataBase;

namespace IniTeamView
{
    public partial class Setting : Form
    {
        private string DbName = StaticClass.DBName;
        private int locationOfFirstMember = -1;
        private string firstMember = "";
        private bool saved = true;
        public Setting()
        {
            InitializeComponent();
            if (File.Exists(Application.StartupPath + @"\" + DbName + "MemberRecord.resx"))
            {
                using (ResXResourceReader resr = new ResXResourceReader(DbName + @"MemberRecord.resx"))
                {
                    List<string> MemberArray = new List<string>();
                    string MemberString = "";
                    foreach (DictionaryEntry d in resr)
                    {
                        MemberArray.Add(d.Value as string);
                    }
                    MemberString = MemberArray[0];
                    firstMember = MemberArray[1];
                    if (!(MemberString == ""))
                    {
                        string[] MemberList = MemberString.Split(',');
                        for (int j = 0; j < MemberList.Length; j++)
                        {
                            if (MemberList[j] == firstMember)
                            {
                                this.MemberGridView.Rows.Add(MemberList[j] + "*");
                                locationOfFirstMember = j;
                            }
                            else
                                this.MemberGridView.Rows.Add(MemberList[j]);
                        }
                    }
                }
            }
        }

        private void SetMember(string Member)
        {
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name == "DealManConfig")
                    {
                        element.SetAttribute("DealMen", Member);
                    }
                }
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("DealManConfig");
            }
        }

        private string GetFirstMember()
        {
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name == "NotificationSection")
                    {
                        return element.GetAttribute("Programmer");
                    }
                }
            }
            return "";
        }

        private void SetFirstMember(string People)
        {
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name == "NotificationSection")
                    {
                        element.SetAttribute("Programmer", People);
                    }
                }
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("NotificationSection");
            }
        }

        private void SaveSetting()
        {
            string MemberString = "";
            if (MemberGridView.Rows.Count == 1)
            {
                MemberString = firstMember;
            }
            if (MemberGridView.Rows.Count > 1)
            {
                MemberString = MemberGridView[0, 0].Value as string;
                if (locationOfFirstMember == 0)
                    MemberString = firstMember;
                for (int i = 1; i < MemberGridView.Rows.Count; i++)
                {
                    if (locationOfFirstMember == i)
                        MemberString += "," + firstMember;
                    else
                        MemberString += "," + (MemberGridView[0, i].Value as string);
                }
            }
            SetFirstMember(firstMember);
            SetMember(MemberString);
            using (ResXResourceWriter resx = new ResXResourceWriter(DbName + @"MemberRecord.resx"))
            {
                resx.AddResource("MemberString", MemberString);
                resx.AddResource("firstMember", firstMember);
            }
        }

        private bool hasMember(string member)
        {
            bool result = false;
            int RowCount = this.MemberGridView.Rows.Count;
            for (int i = 0; i < RowCount; i++)
            {
                if (this.MemberGridView[0, i].Value as string == member || this.MemberGridView[0, i].Value as string == (member + "*"))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            if (!(MemberTextBox.Text == ""))
            {
                if (!hasMember(MemberTextBox.Text))
                {
                    if (locationOfFirstMember == -1)
                    {
                        locationOfFirstMember++;
                        firstMember = this.MemberTextBox.Text;
                        this.MemberGridView.Rows.Add(firstMember + "*");
                    }
                    else
                        this.MemberGridView.Rows.Add(this.MemberTextBox.Text);
                    saved = false;
                }
                else
                    MessageBox.Show("The member already exists.");
                MemberTextBox.Text = "";
            }
        }

        private void DeleteMemberButton_Click(object sender, EventArgs e)
        {
            if (this.MemberGridView.Rows.Count > 1)
            {
                if (MemberGridView.CurrentRow.Index == locationOfFirstMember)
                    MessageBox.Show("Cann't not delete the first query member.");
                else
                {
                    if (this.MemberGridView.CurrentRow.Index < locationOfFirstMember)
                        locationOfFirstMember--;
                    this.MemberGridView.Rows.Remove(MemberGridView.CurrentRow);
                    saved = false;
                }
            }
            else if (this.MemberGridView.Rows.Count == 1)
            {
                locationOfFirstMember--;
                this.MemberGridView.Rows.Remove(MemberGridView.CurrentRow);
                saved = false;
            }

        }

        private void SetFirstMemberButton_Click(object sender, EventArgs e)
        {
            if (locationOfFirstMember >= 0)
            {
                saved = false;
                if (firstMember == "")
                    firstMember = this.MemberGridView.CurrentCell.Value as string;
                this.MemberGridView[0, locationOfFirstMember].Value = firstMember;
                firstMember = this.MemberGridView.CurrentCell.Value as string;
                this.MemberGridView.CurrentCell.Value = firstMember + "*";
                locationOfFirstMember = this.MemberGridView.CurrentRow.Index;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveSetting();
            saved = true;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                if (MessageBox.Show("The settings has been changed, do you want to save this?", "Confirm Message", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    SaveSetting();
                    saved = true;
                }
            }
            this.Close();
        }
    }
}
