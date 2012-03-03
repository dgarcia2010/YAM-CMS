using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using MyCMS.Domain.Contracts;
using MyCMS.Domain.Contracts.Data;
using MyCMS.Domain.Contracts.Infrastructure;

namespace MyCMS.Domain.Core
{
    /// <summary>
    /// Clase base para servicios de capa que necesiten implementar la funcionalidad de un repositorio d eobjetosCon el objeto de poder 
    /// ser usado por los controladores CRUD como si fuera un repositorio, esto permite aprovechar las funciones de "scaffolding"
    /// de Visual Studio lo cual ahorra mucho tiempo en crear vistas
    /// </summary>
    /// <typeparam name="TEntity">Tipo base a gestionar, se creará un repositorio generico sobre este tipo</typeparam>
    public abstract class DataService<TEntity> : ServiceBase, IDataService<TEntity> where TEntity : class, new()
    {

        /// <summary>
        /// Repositorio generico subyacente que servirá para implementar las capacidades de repositorio del objeto
        /// </summary>
        private IGenericRepository<TEntity> _repository;

        /// <summary>
        /// Propiedad accesora del repositorio subyecente
        /// </summary>
        private IGenericRepository<TEntity> Repository
        {
            get
            {
                if (_repository == null)
                    _repository = UnitOfWork.GetRepository<TEntity>();

                return _repository;
            }
        }

        /// <summary>
        /// Constructor para inyección de dependencias
        /// </summary>
        /// <param name="uow">Referencia a la unidad de trabajo de persistencia</param>
        /// <param name="logger">logging service</param>
        public DataService(IUnitOfWork uow, ILoggingService logger)
            : base(uow, logger)
        {
        }

        /// <summary>
        /// Permite obtener colecciones de objetos persistentes del tipo especificado
        /// </summary>
        /// <param name="filter">Expresión que determina los criterios de selección</param>
        /// <param name="orderBy">Expresión que determina los criterios de ordenaqción de los objetos devueltos</param>
        /// <param name="includeProperties">Propiedades a incluir en la consulta (lazy loading)</param>
        /// <returns>Una enumeración de objetos del tipo establecido</returns>
        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }

        /// <summary>
        /// Obtiene un elemento a dada su clave primaria
        /// </summary>
        /// <param name="id">Clave primaria</param>
        /// <returns>El objeto con la clave coincidente o nulll si no existe</returns>
        public TEntity GetById(object id)
        {
            return Repository.GetById(id);
        }

        /// <summary>
        /// Persiste un nuevo objeto en la BDD
        /// </summary>
        /// <param name="entity">Objeto a persistir</param>
        public void Insert(TEntity entity)
        {
            Repository.Insert(entity);
        }

        /// <summary>
        /// Elimina el objeto dado de la BDD
        /// </summary>
        /// <param name="id">Clave primaria del objeto a eliminar</param>
        public void Delete(object id)
        {
            Repository.Delete(id);
        }

        /// <summary>
        /// Elimina el objeto dado de la BDD
        /// </summary>
        /// <param name="entityToDelete">Objeto a eliminar</param>
        public void Delete(TEntity entityToDelete)
        {
            Repository.Delete(entityToDelete);
        }

        /// <summary>
        /// Actualiza un objeto en la BDD
        /// </summary>
        /// <param name="entityToUpdate">La entidad a actualizar</param>
        public void Update(TEntity entityToUpdate)
        {
            Repository.Update(entityToUpdate);
        }

        /// <summary>
        /// Persiste en la unidad de trabajo todos los cambios realizados por los gestores
        /// </summary>
        public void Save()
        {
            UnitOfWork.Commit();
        }

        /// <summary>
        /// Destruccion del objeto
        /// </summary>
        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
