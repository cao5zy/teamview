using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace BugInfoManagement
{
    class AssignPointsControlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DealMenImpl>().As<IDealMen>();
            builder.RegisterType<AssignPointsControl>();
        }
    }
}
