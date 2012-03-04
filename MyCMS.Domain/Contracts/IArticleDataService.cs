using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyCMS.Domain.Entities;

namespace MyCMS.Domain.Contracts
{
    /// <summary>
    /// Data service (repository like interface) for articles
    /// </summary>
    public interface IArticleDataService : IDataService<Article>
    {
        /// <summary>
        /// Obtains newest article. Published and most recent creation date
        /// </summary>
        /// <returns>The newest published article</returns>
        Article GetNewest();
    }
}
