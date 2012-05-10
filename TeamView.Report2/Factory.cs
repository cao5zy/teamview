using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using TeamView.Common;
using TeamView.Report2.GeneralView;

namespace TeamView.Report2
{
    sealed class Factory
    {
        private static Factory _instance;
        private static object _obj = new object();

        private readonly IContainer _container;
        public static Factory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_obj)
                    {
                        if (_instance == null)
                            _instance = new Factory();
                    }
                }
                return _instance;
            }
        }

        private Factory()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<CommonModule>();
            builder.RegisterModule<GeneralViewModule>();

            _container = builder.Build();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
