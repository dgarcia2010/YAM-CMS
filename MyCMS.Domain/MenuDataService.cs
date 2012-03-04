using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyCMS.Domain.Core;
using MyCMS.Domain.Contracts;
using MyCMS.Domain.Contracts.Data;
using MyCMS.Domain.Contracts.Infrastructure;
using MyCMS.Domain.Entities;

namespace MyCMS.Domain
{
    /// <summary>
    /// Data service for menu items
    /// </summary>
    public class MenuDataService : DataService<Menu>, IMenuDataService
    {

        /// <summary>
        /// Constructor for DI
        /// </summary>
        /// <param name="uow">unit of work for data persistence</param>
        /// <param name="logger">logger</param>
        public MenuDataService(IUnitOfWork uow, ILoggingService logger)
            : base(uow, logger)
        {
        }

        /// <summary>
        /// Get all menues for a given column.
        /// </summary>
        /// <param name="columnName">column names can be 'middle' or 'right'</param>
        /// <returns>A list of Menu entities for that column</returns>
        public IList<Menu> GetItemsForColumn(string columnName)
        {
            if (string.IsNullOrEmpty(columnName))
                throw new ArgumentNullException("Argument 'columName' can't be null.");

            if (columnName != "middle" && columnName != "right")
                throw new ArgumentException("Argument 'columName' must contain a valid column name.");

            return UnitOfWork.GetRepository<Menu>().
                Get(x => x.Column == columnName, x => x.OrderByDescending(y => y.Order), "Items").
                ToList<Menu>();

        }

        /// <summary>
        /// Returns a transient (not persistent menu) that holds ordered latests articles
        /// </summary>
        /// <param name="howMany">How many article links will be included</param>
        /// <returns>A transient menu</returns>
        public Menu LatestArticles(int howMany)
        {
            var menu = new Menu
            {
                Title = "Artículos",
                Column = "middle",
                Order = 0,
                Items = new List<MenuItem>()
            };

            var arts = UnitOfWork.GetRepository<Article>().
                Get(null, x => x.OrderByDescending(y => y.DateCreated), "").
                Take(howMany);

            foreach (var a in arts)
            {
                menu.Items.Add(new MenuItem
                    {
                        Title = a.Title,
                        Url= string.Format("~/{0}", a.Rewrite)
                    });
            }

            return menu;
        }

    }
}
