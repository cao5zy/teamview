using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Autofac;
using Autofac.Integration.Web;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using BugInfo.Common;
using BugInfo.Common.Logs;

namespace TeamView.ReportSite
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BugInfoManagementImpl>().As<IBugInfoManagement>();
            builder.RegisterType<JIRAImporter>().As<IItemImporter>();
            builder.RegisterModule<LogsModule>();
            //builder.RegisterType<TaskRecordParser>();
            builder.RegisterType<DBProvider>().As<IDbProvider>();
            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}