using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using BugInfo.Common.Logs;

namespace BugInfoManagement
{
    class Starter
    {
        public MainForm Start()
        {
            ContainerBuilder container = new ContainerBuilder();

            IContainer internalContainer = null;

            container.RegisterType<CreateBugInfoManager>().As<BugInfoManager>().PropertiesAutowired().InstancePerDependency();
            container.RegisterType<EditBugInfoManager>().As<BugInfoManager>().PropertiesAutowired().InstancePerDependency();
            container.RegisterType<CreateBugInfoManager>().InstancePerDependency();
            container.RegisterType<EditBugInfoManager>().InstancePerDependency();
            container.RegisterType<BugInfoForm>().InstancePerDependency();
            container.RegisterType<QueryControl>();
            container.RegisterType<QueryControlModel>();
            container.RegisterType<DealMenImpl>().As<IDealMen>().InstancePerDependency();
            container.RegisterType<BugStatesImpl>().As<IBugStates>().InstancePerDependency();
            container.RegisterType<BugInfoManagementImpl>().As<IBugInfoManagement>().PropertiesAutowired().InstancePerDependency();
            container.RegisterType<NotificationManagerImpl>().As<INotificationManager>().PropertiesAutowired().InstancePerDependency();
            container.RegisterType<NotificationSettingImpl>().As<INotificationSetting>().PropertiesAutowired().InstancePerDependency();
            container.RegisterType<MainForm>().PropertiesAutowired().InstancePerDependency();
            container.RegisterModule<AssignPointsControlModule>();
            container.RegisterModule<LogsModule>();


            internalContainer = container.Build();

            return internalContainer.Resolve<MainForm>();
        }
    }
}
