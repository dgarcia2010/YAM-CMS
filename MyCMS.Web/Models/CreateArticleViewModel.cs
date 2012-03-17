using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

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
        [UIHint("ArticleTitle")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        /// <summary>
        /// Token para la URL amigable
        /// </summary>
        [Display(Name = "Alias")]
        public string Rewrite { get; set; }

        /// <summary>
        /// Cuerpo HTML del artículo
        /// </summary>
        [UIHint("CKEditor")]
        [Display(Name = "Contenido")]
        public string Body { get; set; }

        /// <summary>
        /// Descripción del botón pulsado
        /// </summary>
        public string SubmitButton { get; set; }

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