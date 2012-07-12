using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Impls;
using TeamView.Abstracts;

namespace TeamView
{
    public sealed class ClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<BugInfoForm>().InstancePerDependency();
            builder.RegisterType<QueryControl>();
            builder.RegisterType<QueryControlModel>();
            builder.RegisterType<MainForm>().PropertiesAutowired().InstancePerDependency();
            builder.RegisterType<AddNewForm>();
            builder.RegisterType<HardLevelImpl>().As<IHardLevel>();
        }
    }
}
