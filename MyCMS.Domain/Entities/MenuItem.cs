using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCMS.Domain.Entities
{
    /// <summary>
    /// Una opcion ligada a un menú
    /// </summary>
    public class MenuItem
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
        /// Url externa
        /// </summary>
        public string Url { get; set; }
    }
}
