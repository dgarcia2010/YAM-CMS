using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCMS.Domain.Entities
{
    /// <summary>
    /// Conjunto de opciones a presentar en columna
    /// </summary>
    public class Menu
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
        /// Columna donde posiciona puede ser 'middle' o 'right'
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// Orden de dibujado de menús
        /// </summary>
        public byte Order { get; set; }

        /// <summary>
        /// Opciones de este menu
        /// </summary>
        public ICollection<MenuItem> Items { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Menu()
        {
            Items = new List<MenuItem>();
        }
    }
}
