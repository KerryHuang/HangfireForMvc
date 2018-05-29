using System;
using System.Data.Entity;
using System.Linq;

namespace Models
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        #region Properties        
        protected NorthwindEntities Entities
        {
            get;
            private set;
        }
        #endregion

        #region Constructor
        public Repository()
        {
            Entities = new NorthwindEntities();
        }

        public Repository(NorthwindEntities entities)
        {
            this.Entities = entities;
        }
        #endregion

        #region Implement
        public void Create(TEntity entity)
        {
            ArgumentNullException(entity);
            Entities.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            ArgumentNullException(entity);
            Entities.Set<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            if (Entities != null)
            {
                Entities.Dispose();
                Entities = null;
            }
        }

        public TEntity Get(int id)
        {
            return Entities.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            ArgumentNullException(entity);
            Entities.Entry(entity).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return Entities.SaveChanges();
        }
        #endregion

        #region functions
        private void ArgumentNullException(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity), "entity 不可為空值");
        }
        #endregion
    }
}
