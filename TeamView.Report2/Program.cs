using Autofac;
using Dev3Lib;
using Dev3Lib.Web;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace TeamView.Report2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DependencyFactory.SetContainer(() => {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterType<TeamView.Report2.DAL.BugInfo>().As<TeamView.Report2.DAL.Interfaces.IBugInfo>();
                builder.RegisterType<Report2.DAL.ChangeLog>().As<Report2.DAL.Interfaces.IChangeLog>();
                builder.RegisterType<DefaultDbContext>().WithParameter(new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings["bug_db"].ConnectionString)).As<IDbContext>().InstancePerLifetimeScope();

                return builder.Build();
            });
            Application.Run(new ReportForm());
        }
    }
}
