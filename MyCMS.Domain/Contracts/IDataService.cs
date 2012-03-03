using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyCMS.Domain.Contracts
{
    /// <summary>
    /// Un servicio de capa que implementa todas las funcionalidades de un repositorio.
    /// Un servicio de estas caracteristicas es util para controladores de funcioens CRUD, scaffolding...
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDataService<TEntity>
    {
        /// <summary>
        /// Permite obtener colecciones de objetos persistentes del tipo especificado
        /// </summary>
        /// <param name="filter">Expresión que determina los criterios de selección</param>
        /// <param name="orderBy">Expresión que determina los criterios de ordenaqción de los objetos devueltos</param>
        /// <param name="includeProperties">Propiedades a incluir en la consulta (lazy loading)</param>
        /// <returns>Una enumeración de objetos del tipo establecido</returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Obtiene un elemento a dada su clave primaria
        /// </summary>
        /// <param name="id">Clave primaria</param>
        /// <returns>El objeto con la clave coincidente o nulll si no existe</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Persiste un nuevo objeto en la BDD
        /// </summary>
        /// <param name="entity">Objeto a persistir</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Elimina el objeto dado de la BDD
        /// </summary>
        /// <param name="id">Clave primaria del objeto a eliminar</param>
        void Delete(object id);

        /// <summary>
        /// Elimina el objeto dado de la BDD
        /// </summary>
        /// <param name="entityToDelete">Objeto a eliminar</param>
        void Delete(TEntity entityToDelete);

        /// <summary>
        /// Actualiza un objeto en la BDD
        /// </summary>
        /// <param name="entityToUpdate">La entidad a actualizar</param>
        void Update(TEntity entityToUpdate);

        /// <summary>
        /// Persiste en la unidad de trabajo todos los cambios realizados por los gestores
        /// </summary>
        void Save();

        /// <summary>
        /// Destruccion del objeto
        /// </summary>
        void Dispose();
    }
}
