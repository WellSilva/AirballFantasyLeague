using AirBallFantasyLeague.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AirBallFantasyLeague.Data
{
    public class GenericDAO<TEntity> : IDataAccess<TEntity, int> where TEntity : AirBallFantasyLeague.Model.Entity
    {
        private IDbContext context;

        public GenericDAO (IDbContext airBallContext)
        {
            this.context = airBallContext; 
        }

        public TEntity Add (TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();

            return entity;
        }

        public TEntity Save (TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity;
        }

        public bool Remove (TEntity entity)
        {
            var success = false;

            try
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
                success = true;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }

            return success;
        }

        public TEntity Get (int Id)
        {
            return context.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> All ()
        {
            return context.Set<TEntity>().AsQueryable();
        }

    }
}
