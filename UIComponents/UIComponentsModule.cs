using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Controllers;

namespace TeamView.UIComponents
{
    public class UIComponentsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<CurrentTaskListControl>();
        }
    }
}
