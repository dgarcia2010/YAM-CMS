using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Activation;

namespace MyCMS.Data.Ninject
{
    /// <summary>
    /// Proveedor de inicializacion de Ninject. Importante se encarga de que todos los servicios 
    /// de la capa de dominio trabajen contra la misma unidad de trabajo
    /// </summary>
    public class UnitOfWorkProvider : Provider<UnitOfWork>
    {
        /// <summary>
        /// Unidad de trabajo actual
        /// </summary>
        private UnitOfWork _unitOfWork = null;

        /// <summary>
        /// Devuelve la instancia actual de la unidad de trabajo de persistencia 
        /// si existe instancia una para la ocasión
        /// </summary>
        /// <param name="context">Contexto de dependecias</param>
        /// <returns>La instancia correcta de la unidad de trabajo</returns>
        protected override UnitOfWork CreateInstance(IContext context)
        {

             _unitOfWork = new UnitOfWork();


            return _unitOfWork;
        }
    }
}
