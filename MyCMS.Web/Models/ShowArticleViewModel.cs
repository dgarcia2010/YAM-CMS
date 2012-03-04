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
    public class ShowArticleViewModel
    {
        /// <summary>
        /// Article to show
        /// </summary>
        public Article Article { get; set; }

        /// <summary>
        /// Menus that must be drawn in the middle column
        /// </summary>
        public IList<Menu> MiddleColumnItems { get; set; }

        /// <summary>
        /// Menus that must be drawn in the right column
        /// </summary>
        public IList<Menu> RightColumnItems { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ShowArticleViewModel()
        {
            MiddleColumnItems = new List<Menu>();
            RightColumnItems = new List<Menu>();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="art">Article to show</param>
        public ShowArticleViewModel(Article art)
        {
            Article = art;
            MiddleColumnItems = new List<Menu>();
            RightColumnItems = new List<Menu>();
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="art">Article to show</param>
        /// <param name="middle">items to be drawn in the middle column</param>
        /// <param name="right">items to be drawn in the right column</param>
        public ShowArticleViewModel(Article art, IList<Menu> middle, IList<Menu> right)
        {
            Article = art;
            MiddleColumnItems = middle;
            RightColumnItems = right;
        }
    }
}