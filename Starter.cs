using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Dao;
using TeamView.Common.Logs;
using TeamView.Common;
using IniTeamView;
using TeamView.Impls;
using TeamView.Abstracts;

namespace TeamView
{
    sealed class Starter
    {
        IContainer mContainer;
        public Starter()
        {
            var builder = new ContainerBuilder();


            builder.RegisterModule<IniDbModule>();
            builder.RegisterModule<LogsModule>();
            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<ClientModule>();


            mContainer = builder.Build();
        }
        public MainForm StartMainForm()
        {
            return mContainer.Resolve<MainForm>();
        }

        public CreateDBForm StartCreateDbForm()
        {
            return mContainer.Resolve<CreateDBForm>();
        }
    }
}
