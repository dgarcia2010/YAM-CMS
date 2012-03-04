using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;

using MyCMS.Domain;
using MyCMS.Domain.Contracts;
using MyCMS.Domain.Contracts.Data;

namespace MyCMS.Domain.Ninject
{
    public class DomainLayerDependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleDataService>().To<ArticleDataService>();
            Bind<IMenuDataService>().To<MenuDataService>();
        }
    }
}
