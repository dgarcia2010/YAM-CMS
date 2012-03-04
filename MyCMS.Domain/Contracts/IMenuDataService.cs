using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyCMS.Domain.Entities;

namespace MyCMS.Domain.Contracts
{
    /// <summary>
    /// Data service for menu items
    /// </summary>
    public interface IMenuDataService
    {

        /// <summary>
        /// Get all menues for a given column.
        /// </summary>
        /// <param name="columnName">column names can be 'middle' or 'right'</param>
        /// <returns>A list of Menu entities for that column</returns>
        IList<Menu> GetItemsForColumn(string columnName);

        /// <summary>
        /// Returns a transient (not persistent menu) that holds ordered latests articles
        /// </summary>
        /// <param name="howMany">How many article links will be included</param>
        /// <returns>A transient menu</returns>
        Menu LatestArticles(int howMany);
    }
}
