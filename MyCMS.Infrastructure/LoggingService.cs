using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MyCMS.Domain.Contracts.Infrastructure;

namespace MyCMS.Infrastructure
{
    /// <summary>
    /// Logea información
    /// </summary>
    public class LoggingService : ILoggingService
    {
        /// <summary>
        /// Objeto interno de Log4Net
        /// </summary>
        private log4net.ILog _log;

        /// <summary>
        /// Constructor
        /// </summary>
        public LoggingService()
        {
            _log = log4net.LogManager.GetLogger("Infrastructure");
        }

        /// <summary>
        /// Devuelve o establece el nombre del logger. en el archivo de log
        /// figurará como origen del mensaje
        /// </summary>
        public string Name
        {
            get
            {
                return _log.Logger.Name;
            }

            set
            {
                _log = log4net.LogManager.GetLogger(value);
            }
        }

        /// <summary>
        /// Estable el nombre dle logger. en el archivo de log
        /// figurará como origen del mensaje
        /// </summary>
        /// <param name="name">Nuevo nombre para el logger</param>
        public void SetLogger(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Estable el nombre dle logger. en el archivo de log
        /// figurará como origen del mensaje 
        /// </summary>
        /// <param name="type">Tipo cuyo nombre se asignará al logger</param>
        public void SetLogger(Type type)
        {
            Name = type.Name;
        }

        /// <summary>
        /// Logea la entrada a una acción de controlador
        /// </summary>
        /// <param name="actionDesc">descriptior de la acción</param>
        public void Entering(string actionDesc)
        {
            _log.Info(string.Format("Entrando en {0}", actionDesc));
        }

        /// <summary>
        /// Logea la salida de una acción de controlador
        /// </summary>
        /// <param name="actionDesc">descriptior de la acción</param>
        public void Leaving(string actionDesc)
        {
            _log.Info(string.Format("Saliendo de {0}", actionDesc));
        }

        #region FuncionePasoATraves

        public void Info(string msg)
        {
            _log.Info(msg);
        }

        public void Info(string msg, Exception e)
        {
            _log.Info(msg, e);
        }

        public void Warn(string msg)
        {
            _log.Warn(msg);
        }

        public void Warn(string msg, Exception e)
        {
            _log.Warn(msg, e);
        }

        public void Debug(string msg)
        {
            _log.Debug(msg);
        }

        public void Debug(string msg, Exception e)
        {
            _log.Debug(msg, e);
        }

        public void Error(string msg)
        {
            _log.Error(msg);
        }

        public void Error(string msg, Exception e)
        {
            _log.Error(msg, e);
        }

        public void Fatal(string msg)
        {
            _log.Fatal(msg);
        }

        public void Fatal(string msg, Exception e)
        {
            _log.Error(msg, e);
        }
        #endregion
    }
}
