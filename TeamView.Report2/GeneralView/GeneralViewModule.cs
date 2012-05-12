using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace TeamView.Report2.GeneralView
{
    sealed class GeneralViewModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<GeneralViewControl>();
            builder.RegisterType<Report>();
        }
    }
}
