using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Common.Dao;
using TeamView.Common.DaoImpl;
using TeamView.Common.Models;
using TeamView.Common.Abstracts;
using TeamView.Common.Impls;

namespace TeamView.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BugInfoRepository>().As<IBugInfoRepository>();
            builder.RegisterType<BugInfoViewModel>();
            builder.RegisterType<KeyModel>();
            builder.RegisterType<BugInfoQuery>().As<IQuery>();
            builder.RegisterType<BugStatesImpl>().As<IBugStates>();
            builder.RegisterType<DealMenImpl>().As<IDealMen>();
        }
    }
}
