using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace TeamView.Controllers
{
    public class ControllerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<TaskController>();
        }
    }
}
