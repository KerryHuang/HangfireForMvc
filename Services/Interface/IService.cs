using System;

namespace Services
{
    public interface IService<TEntity> : IDisposable
        where TEntity : class
    {
        IServiceResult<TEntity> Create(TEntity entity);

        IServiceResult<TEntity> Update(TEntity entity);

        IServiceResult<TEntity> Delete(TEntity entity);

        IServiceResult<TEntity> Get(int id);

        IServiceResult<TEntity> GetAll();
    }
}
