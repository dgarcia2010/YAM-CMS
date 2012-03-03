using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyCMS.Domain.Entities;

namespace MyCMS.Domain.Contracts
{
    /// <summary>
    /// Servicio de datos (funciones repositorio) para los lenguages
    /// </summary>
    public interface IArticleDataService : IDataService<Article>
    {
        /// <summary>
        /// Obtiene el artículo más nuevo. Con la fecha de creación más reciente y que esté publicado
        /// </summary>
        /// <returns>El artículo con la fecha de creación más reciente y que esté publicado</returns>
        Article GetNewest();
    }
}
