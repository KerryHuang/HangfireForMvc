using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity Get(int id);

        IQueryable<TEntity> GetAll();

        int SaveChanges();
    }
}
