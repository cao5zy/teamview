using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using BugInfoManagement.DaoImpl;
using BugInfoManagement.Dao;
using BugInfo.Common.Logs;
using BugInfo.Common;
using CreatLocalDataBase;

namespace BugInfoManagement
{
    class Starter
    {
        IContainer mContainer;
        public Starter()
        {
            var builder = new ContainerBuilder();


            builder.RegisterType<CreateBugInfoManager>().As<BugInfoManager>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterType<EditBugInfoManager>().As<BugInfoManager>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterType<CreateBugInfoManager>().InstancePerDependency();
            builder.RegisterType<EditBugInfoManager>().InstancePerDependency();
            builder.RegisterType<BugInfoForm>().InstancePerDependency();
            builder.RegisterType<QueryControl>();
            builder.RegisterType<QueryControlModel>();
            builder.RegisterType<DealMenImpl>().As<IDealMen>().InstancePerDependency();
            builder.RegisterType<BugStatesImpl>().As<IBugStates>().InstancePerDependency();
            builder.RegisterType<BugInfoManagementImpl>().As<IBugInfoManagement>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterType<NotificationManagerImpl>().As<INotificationManager>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterType<NotificationSettingImpl>().As<INotificationSetting>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterType<MainForm>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterModule<AssignPointsControlModule>();
            builder.RegisterType<JIRAImporter>().As<IItemImporter>();
            builder.RegisterType<CreateDBForm>();
            builder.RegisterModule<LogsModule>();

            mContainer = builder.Build();
        }
        public MainForm StartMainForm()
        {
            return mContainer.Resolve<MainForm>();
        }

        public CreateDBForm StartCreateDbForm()
        {
            return mContainer.Resolve<CreateDBForm>();
        }
    }
}
