﻿using AirBallFantasyLeague.EntityFramework;
using AirBallFantasyLeague.IDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AirBallFantasyLeague.Data
{
    public class GenericDAO<TEntity> : IDataAccess<TEntity> where TEntity : AirBallFantasyLeague.Model.Entity
    {
        private IDbContext context;

        public GenericDAO (IDbContext airBallContext)
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
            }
            catch (Exception ex)
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

        public bool Remove (TEntity value)
        {
            var entity = value;
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

        public TEntity Get (object Id)
        {
            return context.Set<TEntity>().Find(Id);
        }

        public IQueryable<TEntity> All ()
        {
            return context.Set<TEntity>().AsNoTracking();
        }
    }
}
