using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

//using BRAINVT.Domain.Entities;

using MyCMS.Domain.Contracts.Data;

namespace MyCMS.Data
{
    /// <summary>
    /// Unidad de trabajo para acceso a datos
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        /// <summary>
        /// Enlace con BDD de Entity Framework
        /// </summary>
        private DatabaseContext _context;

        /// <summary>
        /// estructura privada para almacenar los repositorios creados para que
        /// estos sean utilizados más adelante
        /// </summary>
        private IDictionary<string, object> _repositories;

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitOfWork()
        {
            _context = new DatabaseContext();
            Database.SetInitializer<DatabaseContext>(new ContextInitializer());
            _repositories = new Dictionary<string, object>();
        }

        /// <summary>
        /// Obtiene un repositorio de datos. La unidad de rabajo es responsable del ciclo de vida
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad contrala cual se genera el repo</typeparam>
        /// <returns>Un repositorio genérico de TEntity</returns>
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, new() 
        {
            string typeName = (new TEntity()).GetType().Name;

            if (_repositories.ContainsKey(typeName))
            {
                return _repositories[typeName] as IGenericRepository<TEntity>;
            }
            else
            {
                var repo = new GenericRepository<TEntity>(_context);
                _repositories.Add(typeName, repo);
                return repo;
            }
        }

        /// <summary>
        /// Salva las operaciones de datos acumuladas hasta el moemnto en toda la unidad de trabajo
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
