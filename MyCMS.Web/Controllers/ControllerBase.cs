using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;

using MyCMS.Domain.Entities;
using MyCMS.Domain.Contracts.Infrastructure;

namespace MyCMS.Web.Controllers
{
    /// <summary>
    /// Controlador base con funciones comunes a todos los controllers de la web pública
    /// </summary>
    public class ControllerBase : Controller
    {
        /// <summary>
        /// Logger
        /// </summary>
        protected ILoggingService Log { get; set; }

        /// <summary>
        /// Obtiene el nombre de usuario actual
        /// </summary>
        protected string CurrentUserName
        {
            get
            {
                return User.Identity.Name;
            }
        }

        /// <summary>
        /// Construcción
        /// </summary>
        /// <param name="logger">objeto logger inyectado</param>
        public ControllerBase(ILoggingService logger)
        {
            Log = logger;
            Log.SetLogger(this.GetType());
        }

    }
}