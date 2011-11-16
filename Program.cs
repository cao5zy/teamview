using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using System.Configuration;
using System.Xml;
using System.Resources;
using System.Collections;

namespace BugInfoManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CreatLocalDataBase.CreateDBForm());
            if (!GetConnString().Equals(""))
            {
                EditConfig(GetConnString());
            }
            Application.Run(new Starter().Start());

        }

        //修改配置文件
        public static void EditConfig(string connString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name=="connectionStrings")
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals("bug_Db"))
                        {
                            node.Attributes[1].Value = connString;
                        }
                    }
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        //获取连接字符串
        public static string GetConnString()
        {
            try
            {
                using (ResXResourceReader resr = new ResXResourceReader(@"ConnectString.resx"))
                {
                    string ConnectString = "";
                    foreach (DictionaryEntry d in resr)
                    {
                        ConnectString = d.Value as string;
                    }
                    return ConnectString;
                }
            }
            catch (Exception e)
            {
                //使用e，消除警告
                string s=e.Message;
                return "";
            }
        }
    }
}
