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

        /// <summary>
        /// Obtiene articulo por su rewrite
        /// </summary>
        /// <param name="slug">el sufijo url (rewrite)</param>
        /// <returns>EL artículo o null si no hay ninguno con ese rewrite</returns>
        Article Get(string slug);

        /// <summary>
        /// Guarda un nuevo articulo
        /// </summary>
        /// <param name="title">titulo del articulo</param>
        /// <param name="body">contenido HTML</param>
        /// <param name="rewrite">sufijo de la direccion para sef</param>
        /// <returns>El artículo recien creado</returns>
        Article Save(string title, string body, string rewrite);

        /// <summary>
        /// Guarda y publica un artículo
        /// </summary>
        /// <param name="title">titulo del articulo</param>
        /// <param name="body">contenido HTML</param>
        /// <param name="rewrite">sufijo de la direccion para sef</param>
        /// <returns>El artículo recien creado</returns>
        Article SaveAndPublish(string title, string body, string rewrite);
    }
}
