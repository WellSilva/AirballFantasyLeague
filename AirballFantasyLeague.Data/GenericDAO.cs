using AirBallFantasyLeague.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AirballFantasyLeague.Data
{
    public class GenericDAO<TEntity> where TEntity : class
    {
        private AirBallContext context;

        public GenericDAO (AirBallContext airBallContext)
        {
            this.context = airBallContext; 
        }

        public TEntity Add (TEntity value)
        {
            var entity = value;
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
            return entity;
        }

        public TEntity Save (TEntity value)
        {
            var entity = value;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public void Remove (TEntity value)
        {
            var entity = value;
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
