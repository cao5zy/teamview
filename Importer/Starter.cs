using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Common;

namespace JIRAImporter
{
    sealed class Starter
    {
        IContainer mContainer;

        public Starter()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JIRAImportController>();
            builder.RegisterType<JIRAImporter>().As<IItemImporter>();
            builder.RegisterModule<CommonModule>();

            mContainer = builder.Build();
        }

        public JIRAImportController BuildJIRAImportContainer()
        {
            return mContainer.Resolve<JIRAImportController>();
        }
    }
}
