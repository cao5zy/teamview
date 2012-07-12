using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using TeamView.Dao;
using System.Configuration;
using System.Xml;
using System.Resources;
using System.Collections;
using System.IO;

namespace TeamView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Starter starter = new Starter();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(starter.StartCreateDbForm());
            //if (!GetConnString().Equals(""))
            //{
            //    EditConfig(GetConnString());
            //}
            Application.Run(starter.StartMainForm());
        }

        public static void EditConfig(string connString)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name == "connectionStrings")
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value == "bug_Db")
                        {
                            node.Attributes[1].Value = connString;
                        }
                    }
                }
            }
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static string GetConnString()
        {
            if (File.Exists(Application.StartupPath + @"\ConnectString.resx"))
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
            else
                return "";
        }
    }
}