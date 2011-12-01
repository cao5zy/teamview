using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace IniTeamView.UserControls
{
    public class JIRAImportModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<JIRAImportControl>();
            builder.RegisterType<JIRAImportController>();
        }
    }
}
