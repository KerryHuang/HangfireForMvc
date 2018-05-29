using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ServiceResult<TEntity> : IServiceResult<TEntity>
        where TEntity : class
    {
        private TEntity _entity { get; set; }
        private IEnumerable<TEntity> _entities { get; set; }
        private Exception _exception { get; set; }

        public ServiceResult(Exception exception)
        {
            this._exception = exception;
        }

        public ServiceResult(TEntity entity, Exception exception)
        {
            this._entity = entity;
            this._exception = exception;
        }

        public ServiceResult(IEnumerable<TEntity> entities, Exception exception)
        {
            this._entities = entities;
            this._exception = exception;
        }

        public bool IsSucceeded
        {
            get
            {
                return _exception == null;
            }
        }

        public bool IsExists
        {
            get
            {
                return _entity != null || (_entities?.Any() == true);
            }
        }

        public int Count
        {
            get
            {
                return _entity != null ? 1 : (_entities?.Count() ?? 0);
            }
        }

        public IEnumerable<TEntity> Entities => _entities;

        public TEntity Entity => _entity;

        public Exception Exception => _exception;
    }
}
