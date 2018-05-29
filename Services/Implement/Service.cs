using Models;
using System;
using System.Linq;

namespace Services
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {

        //public IRepository<TEntity> _repository { set; protected get; }

        private IRepository<TEntity> _repository;

        #region Constructor
        public Service(IRepository<TEntity> repository)
        {
            this._repository = repository;
        }
        #endregion

        #region Implement
        public virtual IServiceResult<TEntity> Create(TEntity entity)
        {
            try
            {
                this._repository.Create(entity);
                this._repository.SaveChanges();
                return new ServiceResult<TEntity>(entity, null);
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity>(entity, ex);
            }
        }

        public virtual IServiceResult<TEntity> Delete(TEntity entity)
        {
            try
            {
                this._repository.Delete(entity);
                this._repository.SaveChanges();
                return new ServiceResult<TEntity>(entity, null);
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity>(entity, ex);
            }
        }

        public void Dispose()
        {
            if (_repository != null)
            {
                this._repository.Dispose();
                this._repository = null;
            }
        }

        public virtual IServiceResult<TEntity> Get(int id)
        {
            try
            {
                var entity = this._repository.Get(id);
                return new ServiceResult<TEntity>(entity, null);
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity>(ex);
            }
        }

        public virtual IServiceResult<TEntity> GetAll()
        {
            try
            {
                var entities = this._repository.GetAll().ToList();
                return new ServiceResult<TEntity>(entities, null);
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity>(ex);
            }
        }

        public virtual IServiceResult<TEntity> Update(TEntity entity)
        {
            try
            {
                this._repository.Update(entity);
                this._repository.SaveChanges();
                return new ServiceResult<TEntity>(entity, null);
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity>(entity, ex);
            }
        }
        #endregion
    }
}
