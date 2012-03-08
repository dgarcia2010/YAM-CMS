using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MyCMS.Domain.Entities;

namespace MyCMS.Web.Models
{
    public class ThreeColumnViewModel
    {
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
        public ThreeColumnViewModel()
        {
            MiddleColumnItems = new List<Menu>();
            RightColumnItems = new List<Menu>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ThreeColumnViewModel(IList<Menu> middle, IList<Menu> right)
        {
            MiddleColumnItems = middle;
            RightColumnItems = right;
        }

    }
}