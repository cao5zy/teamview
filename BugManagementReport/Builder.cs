using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using System.Data.SqlClient;
using System.Configuration;
using BugInfo.Common;
using BugInfo.Common.Logs;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace BugManagementReport
{
    class Builder
    {
        IContainer container;
        public Builder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<BugInfoManagementImpl>().As<IBugInfoManagement>();

            builder.RegisterInstance(new SqlConnection(ConfigurationManager.ConnectionStrings["bug_Db"].ConnectionString));
            builder.RegisterType<FileProvider>().As<IFileProvider>();
            builder.RegisterType<TaskRecordManager>();
            builder.RegisterType<Snapshot>().PropertiesAutowired();
            builder.RegisterModule<LogsModule>();

            container = builder.Build();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
