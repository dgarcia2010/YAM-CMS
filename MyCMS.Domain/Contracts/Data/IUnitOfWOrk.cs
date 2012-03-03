using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using BRAINVT.Domain.Entities;

namespace MyCMS.Domain.Contracts.Data
{
    /// <summary>
    /// Contrato de servicio de la unidad de trabajo de persistencia
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Obtiene un repositorio de datos. La unidad de rabajo es responsable del ciclo de vida
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad contrala cual se genera el repo</typeparam>
        /// <returns>Un repositorio genérico de TEntity</returns>
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new();

        /// <summary>
        /// Salva las operaciones de datos acumuladas hasta el moemnto en toda la unidad de trabajo
        /// </summary>
        void Commit();

    }
}
