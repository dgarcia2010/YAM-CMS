using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyCMS.Domain.Contracts.Data;
using MyCMS.Domain.Contracts.Infrastructure;

namespace MyCMS.Domain.Core
{
    /// <summary>
    /// Clase base para todos los servicios de la capa de dominio. aporta conexión
    /// con servicios de acceso a datos (UoW) y logging
    /// </summary>
    public abstract class ServiceBase
    {

        /// <summary>
        /// Unidad de trabajo que comparten todos los Managers, esto asegura que todos los managers compartan un mismo contexto de cambios en la BD
        /// Esto es muy importante por que si no se respetase podria ser que un Manager hiciera cambios en el sistema
        /// y estos fuesen invisibles para los otros managers.
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        /// Logger, objeto para enviar entradas al log de la aplicación
        /// </summary>
        protected ILoggingService Log { get; set; }

        /// <summary>
        /// Constructor para inyección
        /// </summary>
        /// <param name="uow">unidad de acceso a datos</param>
        /// <param name="logger">servicio de logging</param>
        public ServiceBase(IUnitOfWork uow, ILoggingService logger)
        {
            UnitOfWork = uow;
            Log = logger;
            Log.SetLogger(this.GetType());
        }
    }
}
