using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Dao;
using System.Data.SqlClient;
using System.Configuration;
using TeamView.Common;
using TeamView.Common.Logs;
using System.Data;

namespace BugManagementReport
{
    class Builder
    {
        IContainer container;
        public Builder()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterInstance(new SqlConnection(ConfigurationManager.ConnectionStrings["bug_Db"].ConnectionString));
            builder.RegisterType<FileProvider>().As<IFileProvider>();
            builder.RegisterType<TaskRecordManager>();
            builder.RegisterModule<LogsModule>();
            builder.RegisterModule<CommonModule>();

            container = builder.Build();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
