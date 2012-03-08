using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyCMS.Domain.Entities;

namespace MyCMS.Web.Models
{
    /// <summary>
    /// View model for pages that show an article to a user
    /// </summary>
    public class ShowArticleViewModel : ThreeColumnViewModel
    {
        /// <summary>
        /// Article to show
        /// </summary>
        public Article Article { get; set; }

        /// <summary>
        /// Default cons
        /// </summary>
        public ShowArticleViewModel()
            : base()
        {
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="art">Article to show</param>
        public ShowArticleViewModel(Article art) 
            : base()
        {
            Article = art;
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="art">Article to show</param>
        /// <param name="middle">items to be drawn in the middle column</param>
        /// <param name="right">items to be drawn in the right column</param>
        public ShowArticleViewModel(Article art, IList<Menu> middle, IList<Menu> right)
            : base(middle, right)
        {
            Article = art;
        }
    }
}