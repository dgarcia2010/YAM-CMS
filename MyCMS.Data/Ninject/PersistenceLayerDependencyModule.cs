using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;

using MyCMS.Domain.Contracts.Data;

namespace MyCMS.Data.Ninject
{
    /// <summary>
    /// Modulo de dependencias Ninject. Establece las dependencias de la capa de persistencia
    /// </summary>
    public class DataLayerDependencyModule : NinjectModule
    {
        /// <summary>
        /// Bindings de DI container
        /// </summary>
        public override void Load()
        {
            Bind<IUnitOfWork>().ToProvider(new UnitOfWorkProvider()).InRequestScope();
        }
    }
}
