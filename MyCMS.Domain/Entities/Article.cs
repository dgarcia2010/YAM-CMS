using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCMS.Domain.Entities
{
    /// <summary>
    /// Representa una entrada de blog
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Clave primaria
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Título
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Token para la URL amigable
        /// </summary>
        public string Rewrite { get; set; }

        /// <summary>
        /// Cuerpo HTML del artículo
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Determina si está visible online
        /// </summary>
        public bool Published { get; set; }
    }
}
