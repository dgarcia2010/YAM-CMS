using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyCMS.Domain.Entities;

namespace MyCMS.Web.Models
{
    /// <summary>
    /// View data for the new article form
    /// </summary>
    public class CreateArticleViewModel : ThreeColumnViewModel
    {

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
        /// Determina si está visible online
        /// </summary>
        public bool Published { get; set; }

        /// <summary>
        /// Default cons.
        /// </summary>
        public CreateArticleViewModel()
            : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="middle">Blocks for middle column</param>
        /// <param name="right">Block for rightmost column</param>
        public CreateArticleViewModel(IList<Menu> middle, IList<Menu> right)
            : base(middle, right)
        {
        }
    }
}