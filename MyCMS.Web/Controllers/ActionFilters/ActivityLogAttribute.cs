using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

using Ninject;

using MyCMS.Domain.Contracts.Infrastructure;

namespace MyCMS.Web.Controllers.ActionFilters
{
    /// <summary>
    /// Filtro de acciones para el registro de actividades de controladores en el log. A través de infraestructura.
    /// Registra las entradas y salidas de todas las acciones (si colocas el attributo a nivel de controlador) Y 
    /// también las excepciones no controladas. A la salida de las acciones también se registra el tiempo de 
    /// ejecución de la acción en milisegundos.
    /// </summary>
    public class ActivityLogAttribute : ActionFilterAttribute, IActionFilter
    {

        /// <summary>
        /// Referencia al servicio de logging. Inyectado
        /// </summary>
        [Inject]
        public ILoggingService Log { get; set; }

        /// <summary>
        /// Cronómetro pra medir el tiempo de duración de las acciones
        /// </summary>
        private Stopwatch StopWatch { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ActivityLogAttribute()
            : base()
        {
            StopWatch = new Stopwatch();
        }

        /// <summary>
        /// Se ejecuta antes de cada acción. Registra la entrada a la acción y resetea el cronómetro 
        /// para medir el tiempo
        /// </summary>
        /// <param name="filterContext">contexto del filtro</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //entrada
            Log.SetLogger(filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name);

            Log.Entering(string.Format("{2} {0}.{1}()", 
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name, 
                filterContext.ActionDescriptor.ActionName, 
                filterContext.HttpContext.Request.HttpMethod == "POST" ? "[POST]" : "").Trim());

            //timing
            StopWatch.Restart();

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Procedimiento ejecutado al finalizar la acción. Registra la salida de la acción
        /// (con su tiempo de duración) y si ha ocurrado una excepción también la registra.
        /// </summary>
        /// <param name="filterContext">Contexto del filtro</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log.SetLogger(filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name);

            //si ha habido una excepción...
            if (filterContext.Exception != null)
            {
                Log.Error("Ha ocurrido una excepción no controlada", filterContext.Exception);
                if (filterContext.Exception.InnerException != null)
                {
                    Log.Error("Excepción interna", filterContext.Exception.InnerException);
                }
            }

            //timing
            StopWatch.Stop();
            
            //salida
            Log.Leaving(string.Format("{2} {0}.{1}() ({3}ms)",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerType.Name,
                filterContext.ActionDescriptor.ActionName,
                filterContext.HttpContext.Request.HttpMethod == "POST" ? "[POST]" : "",
                StopWatch.ElapsedMilliseconds).Trim());

            base.OnActionExecuted(filterContext);
        }
    }
}