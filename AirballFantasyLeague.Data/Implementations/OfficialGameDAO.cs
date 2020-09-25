using AirBallFantasyLeague.EntityFramework;
using AirBallFantasyLeague.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AirBallFantasyLeague.Data
{
    public class OfficialGameDAO : IDataAccess<OfficialGame, long>
    {
        private IDbContext context;

        public OfficialGameDAO (IDbContext airBallContext)
        {
            this.context = airBallContext; 
        }

        public OfficialGame Add (OfficialGame entity)
        {
            try
            {
                context.Set<OfficialGame>().Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return entity;
        }

        public OfficialGame Save (OfficialGame entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            } catch (DbUpdateException ex)
            {
                throw ex;
            }
            return entity;
        }

        public bool Remove (OfficialGame entity)
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

        public OfficialGame Get (long Id)
        {
            return context.Set<OfficialGame>().Find(Id);
        }

        public IQueryable<OfficialGame> All ()
        {
            return context.Set<OfficialGame>().AsQueryable();
        }
    }
}
