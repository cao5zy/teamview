using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace TeamView.Common.Logs
{
    public class LogsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DBProvider>().As<IDbProvider>();
            builder.RegisterType<TaskRecordParser>();
            //UpdateConnectionStringsConfig("bug_Db", "server=(local);Integrated Security=true;database=wangde", "System.Data.SqlClient");
            builder.RegisterInstance(new SqlConnection(ConfigurationManager.ConnectionStrings["bug_Db"].ConnectionString));
        }

        ///更新连接字符串  
        ///</summary> 
        ///<param name="newName">连接字符串名称</param> 
        ///<param name="newConString">连接字符串内容</param> 
        ///<param name="newProviderName">数据提供程序名称</param> 
        private static void UpdateConnectionStringsConfig(string newName, string newConString, string newProviderName)
        {
            bool isModified = false;    //记录该连接串是否已经存在  
            //如果要更改的连接串已经存在  
            if (ConfigurationManager.ConnectionStrings[newName] != null)
            {
                isModified = true;
            }  	    //新建一个连接字符串实例  
            ConnectionStringSettings mySettings = new ConnectionStringSettings(newName, newConString, newProviderName);
            // 打开可执行的配置文件*.exe.config  
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // 如果连接串已存在，首先删除它  	   
            if (isModified)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(newName);
            }
            // 将新的连接串添加到配置文件中.  
            config.ConnectionStrings.ConnectionStrings.Add(mySettings);
            // 保存对配置文件所作的更改  
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节  
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
    }
}
