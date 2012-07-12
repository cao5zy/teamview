using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace IniTeamView
{
    public class IniDbModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<CreateDBForm>();
            builder.RegisterType<Setting>();
            builder.RegisterModule<UserControls.JIRAImportModule>();
        }
    }
}
