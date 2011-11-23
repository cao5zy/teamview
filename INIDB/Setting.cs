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

namespace CreatLocalDataBase
{
    public partial class Setting : Form
    {
        private int locationOfFirstMember=0;
        private string firstMember="";
        public Setting()
        {
            InitializeComponent();
            this.MemberListBox.Items.Clear();
            if (File.Exists(Application.StartupPath + @"\" + CreateDBForm.DbName + "MemberRecord.resx"))
            {
                using (ResXResourceReader resr = new ResXResourceReader(CreateDBForm.DbName + @"MemberRecord.resx"))
                {
                    string MemberString = "";
                    string[] MemberArray = new string[2];
                    int i = 0;
                    foreach (DictionaryEntry d in resr)
                    {
                        MemberArray[i] = d.Value as string;
                        i++;
                    }
                    MemberString = MemberArray[0];
                    firstMember = MemberArray[1];
                    this.MemberListBox.Items.AddRange(MemberString.Split(','));
                }
            }
            else
            {
                this.MemberListBox.Items.Add("");
            }
            locationOfFirstMember = this.MemberListBox.Items.IndexOf(firstMember);
            this.MemberListBox.Items.RemoveAt(locationOfFirstMember);
            this.MemberListBox.Items.Insert(locationOfFirstMember, firstMember + "*");
        }
            
        private string[] ChangeStringToArray(string s)
        {
            return s.Split(',');
        }

        private string GetMember()
        {
            if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                foreach (XmlElement element in xmlDoc.DocumentElement)
                {
                    if (element.Name == "DealManConfig")
                    {
                        return element.GetAttribute("DealMen");
                    }
                }
            }
            return "";
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

        protected override void OnClosing(CancelEventArgs e)
        {
            MemberListBox.Items.RemoveAt(locationOfFirstMember);
            MemberListBox.Items.Insert(locationOfFirstMember, firstMember);
            string MemberString = MemberListBox.Items[0].ToString();
            for (int i = 1; i < MemberListBox.Items.Count; i++)
            {
                MemberString += "," + MemberListBox.Items[i].ToString();
            }
            SetFirstMember(firstMember);
            SetMember(MemberString);
            using (ResXResourceWriter resx = new ResXResourceWriter(CreateDBForm.DbName+@"MemberRecord.resx"))
            {
                resx.AddResource("MemberString",MemberString);
                resx.AddResource("firstMember", firstMember);
            }
            base.OnClosing(e);
        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            if (MemberListBox.Items.IndexOf(MemberTextBox.Text) < 0 && MemberListBox.Items.IndexOf(MemberTextBox.Text + "*") < 0)
            {
                MemberListBox.Items.Add(MemberTextBox.Text);
                MemberTextBox.Text = "";
                locationOfFirstMember = MemberListBox.Items.IndexOf(firstMember + "*");
            }
            else
                MessageBox.Show("The name "+MemberTextBox.Text+" already exists.");
        }

        private void MemberListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemberTextBox.Text = MemberListBox.Text;
        }

        private void DeleteMemberButton_Click(object sender, EventArgs e)
        {
            if (MemberListBox.Items.IndexOf(MemberTextBox.Text) > 0)
            {
                if (MemberTextBox.Text == firstMember + "*")
                {
                    firstMember = "";
                    locationOfFirstMember = MemberListBox.Items.IndexOf(firstMember);
                    MemberListBox.Items.RemoveAt(locationOfFirstMember);
                    MemberListBox.Items.Insert(locationOfFirstMember, firstMember + "*");
                }
                MemberListBox.Items.Remove(MemberTextBox.Text);
                locationOfFirstMember = MemberListBox.Items.IndexOf(firstMember + "*");
            }
            else
                MessageBox.Show("Please choese one correct member to delete.");
        }

        private void SetFirstMemberButton_Click(object sender, EventArgs e)
        {
            if (MemberTextBox.Text != "")
            {
                MemberListBox.Items.RemoveAt(locationOfFirstMember);
                MemberListBox.Items.Insert(locationOfFirstMember, firstMember);
                firstMember = MemberTextBox.Text;
                locationOfFirstMember = MemberListBox.Items.IndexOf(firstMember);
                MemberListBox.Items.RemoveAt(locationOfFirstMember);
                MemberListBox.Items.Insert(locationOfFirstMember, firstMember + "*");
            }
        }
    }
}
