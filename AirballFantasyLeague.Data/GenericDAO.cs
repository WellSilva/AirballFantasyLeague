using AirBallFantasyLeague.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirballFantasyLeague.Data
{
    public class GenericDAO<TEntity> where TEntity : AirBallFantasyLeague.Model.Entity
    {
        private AirBallContext context;

        public GenericDAO (AirBallContext airBallContext)
        {
            this.context = airBallContext; 
        }

        public TEntity Add (TEntity value)
        {
            var entity = value;
            try
            {

                entity.Status = AirBallFantasyLeague.Model.Status.Active;
                entity.CreatedOn = DateTime.Now;
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();

            } catch (Exception ex )
            {
                throw (ex);
            }
            return entity;
        }

        public TEntity Save (TEntity value)
        {
            var entity = value;
            try
            {
                entity.AlteredOn = DateTime.Now;

                if (entity.Status == AirBallFantasyLeague.Model.Status.Deleted)
                    entity.DeletedOn = DateTime.Now;

                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            } catch (DbUpdateException ex)
            {
                throw ex;
            }
            return entity;
        }

        public void Remove (TEntity value)
        {
            var entity = value;
            try
            {
                entity.DeletedOn = DateTime.Now;
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public TEntity Get (int Id)
        {
            return context.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> All ()
        {
            return context.Set<TEntity>().AsNoTracking();
        }
    }
}
