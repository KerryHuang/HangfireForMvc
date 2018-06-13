using Models;
using System;
using System.Linq;

namespace Services
{
    public class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        #region Properties
        public IRepository<TEntity> Repository { set; get; }
        #endregion

        #region Constructor
        public Service()
        {
            Repository = new Repository<TEntity>();
        }
        #endregion

        #region Implement
        public virtual IServiceResult<TEntity> Create(TEntity entity)
        {
            try
            {
                Repository.Create(entity);
                Repository.SaveChanges();
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
                Repository.Delete(entity);
                Repository.SaveChanges();
                return new ServiceResult<TEntity>(entity, null);
            }
            catch (Exception ex)
            {
                return new ServiceResult<TEntity>(entity, ex);
            }
        }

        public void Dispose()
        {
            if (Repository != null)
            {
                Repository.Dispose();
                Repository = null;
            }
        }

        public virtual IServiceResult<TEntity> Get(int id)
        {
            try
            {
                var entity = Repository.Get(id);
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
                var entities = Repository.GetAll().ToList();
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
                Repository.Update(entity);
                Repository.SaveChanges();
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
