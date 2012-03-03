using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;

using MyCMS.Domain.Contracts.Infrastructure;

namespace MyCMS.Infrastructure.Ninject
{
    public class InfrastructureLayerDependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoggingService>().To<LoggingService>();
        }
    }
}
