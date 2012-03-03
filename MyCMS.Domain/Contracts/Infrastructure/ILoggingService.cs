using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCMS.Domain.Contracts.Infrastructure
{
    /// <summary>
    /// Logea información
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Devuelve o establece el nombre del logger. en el archivo de log
        /// figurará como origen del mensaje
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Estable el nombre dle logger. en el archivo de log
        /// figurará como origen del mensaje
        /// </summary>
        /// <param name="name">Nuevo nombre para el logger</param>
        void SetLogger(string name);

        /// <summary>
        /// Estable el nombre dle logger. en el archivo de log
        /// figurará como origen del mensaje 
        /// </summary>
        /// <param name="type">Tipo cuyo nombre se asignará al logger</param>
        void SetLogger(Type type);

        /// <summary>
        /// Logea la entrada a una acción de controlador
        /// </summary>
        /// <param name="actionDesc">descriptior de la acción</param>
        void Entering(string actionDesc);

        /// <summary>
        /// Logea la salida de una acción de controlador
        /// </summary>
        /// <param name="actionDesc">descriptior de la acción</param>
        void Leaving(string actionDesc);

        /// <summary>
        /// Registra info
        /// </summary>
        /// <param name="msg">información</param>
        void Info(string msg);

        /// <summary>
        /// Registra información
        /// </summary>
        /// <param name="msg">información</param>
        /// <param name="e">excepción</param>
        void Info(string msg, Exception e);

        /// <summary>
        /// Registra aviso
        /// </summary>
        /// <param name="msg">aviso</param>
        void Warn(string msg);

        /// <summary>
        /// Registra aviso
        /// </summary>
        /// <param name="msg">aviso</param>
        /// <param name="e">excepción</param>
        void Warn(string msg, Exception e);

        /// <summary>
        /// Registra debug info
        /// </summary>
        /// <param name="msg">aviso</param>
        void Debug(string msg);

        /// <summary>
        /// Registra debug
        /// </summary>
        /// <param name="msg">debug info</param>
        /// <param name="e">excepción</param>
        void Debug(string msg, Exception e);

        /// <summary>
        /// Registra error
        /// </summary>
        /// <param name="msg">mensaje de error</param>
        void Error(string msg);

        /// <summary>
        /// Registra error
        /// </summary>
        /// <param name="msg">mensaje de error</param>
        /// <param name="e">excepción</param>
        void Error(string msg, Exception e);

        /// <summary>
        /// Registra un error fatal
        /// </summary>
        /// <param name="msg">mensaje de error</param>
        void Fatal(string msg);

        /// <summary>
        /// Registra un error fatal
        /// </summary>
        /// <param name="msg">mensaje de error</param>
        /// <param name="e">excepción</param>
        void Fatal(string msg, Exception e);
    }
}
