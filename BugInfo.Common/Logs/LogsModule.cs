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

namespace BugInfo.Common.Logs
{
    public class LogsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DBProvider>().As<IDbProvider>();
            builder.RegisterType<TaskRecordParser>();
            builder.RegisterInstance(new SqlConnection(ConfigurationManager.ConnectionStrings["bug_Db"].ConnectionString));

        }
    }
}
