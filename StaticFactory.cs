using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace BugInfoManagement
{
    static class StaticFactory
    {
        static IUnityContainer CONTAINER;
        static StaticFactory()
        {
            var config = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            CONTAINER = new UnityContainer();
            config.Containers[0].Configure(CONTAINER);
        }
        public static T Create<T>()
        {
            return CONTAINER.Resolve<T>();
        }
    }
}
