using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Impls;
using TeamView.Abstracts;

namespace TeamView
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
