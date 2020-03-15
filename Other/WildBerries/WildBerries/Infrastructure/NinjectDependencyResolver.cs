using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Web.Mvc;
using WildBerries.DAL;

namespace WildBerries.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ICoinsRepository>().To<DbCoinsRepository>();
            //kernel.Bind<ICoinsRepository>().To<XmlCoinsRepository>();
            kernel.Bind<IDrinksRepository>().To<DbDrinksRepository>();
            //kernel.Bind<IDrinksRepository>().To<XmlDrinksRepository>();
        }
    }
}