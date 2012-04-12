using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Common;

namespace Importer
{
    sealed class Starter
    {
        IContainer mContainer;

        public Starter()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JIRAImportController>();
            builder.RegisterModule<CommonModule>();

            mContainer = builder.Build();
        }

        public JIRAImportController BuildJIRAImportContainer()
        {
            return mContainer.Resolve<JIRAImportController>();
        }
    }
}
