using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using MyCMS.Domain.Core;
using MyCMS.Domain.Contracts;
using MyCMS.Domain.Contracts.Data;
using MyCMS.Domain.Contracts.Infrastructure;
using MyCMS.Domain.Entities;

namespace MyCMS.Domain
{
    /// <summary>
    /// Gestor de lenguages. Lógica de negocio para lenguages soportados
    /// </summary>
    public class ArticleDataService : DataService<Article>, IArticleDataService
    {
        /// <summary>
        /// Constructor para IoC
        /// </summary>
        /// <param name="uow">Unidad de trabajo para persistencia</param>
        /// <param name="logger">logger</param>
        public ArticleDataService(IUnitOfWork uow, ILoggingService logger)
            : base(uow, logger)
        {
        }

        public Article GetNewest()
        {
            /// <summary>
            /// Obtiene el artículo más nuevo. Con la fecha de creación más reciente y que esté publicado
            /// </summary>
            /// <returns>El artículo con la fecha de creación más reciente y que esté publicado</returns>
            return this.Get(x => x.Published == true, x => x.OrderByDescending(a => a.DateCreated), "").First();
        }

        /// <summary>
        /// Guarda un nuevo articulo
        /// </summary>
        /// <param name="title">titulo del articulo</param>
        /// <param name="body">contenido HTML</param>
        /// <param name="rewrite">sufijo de la direccion para sef</param>
        /// <returns>El artículo recien creado</returns>
        public Article Save(string title, string body, string rewrite)
        {
            var a = new Article
            {
                Title = title,
                Rewrite = rewrite,
                Body = body,
                DateCreated = DateTime.Now,
                Published = false
            };

            UnitOfWork.GetRepository<Article>().Insert(a);
            UnitOfWork.Commit();
            return a;
        }

        /// <summary>
        /// Guarda y publica un artículo
        /// </summary>
        /// <param name="title">titulo del articulo</param>
        /// <param name="body">contenido HTML</param>
        /// <param name="rewrite">sufijo de la direccion para sef</param>
        /// <returns>El artículo recien creado</returns>
        public Article SaveAndPublish(string title, string body, string rewrite)
        {
            var a = Save(title, body, rewrite);

            a.Published = true;
            UnitOfWork.GetRepository<Article>().Update(a);
            UnitOfWork.Commit();
            return a;
        }
    }
}
