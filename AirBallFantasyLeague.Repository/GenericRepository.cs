using AirBallFantasyLeague.Data;
using AirBallFantasyLeague.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using AirBallFantasyLeague.Model.Repositories;

namespace AirBallFantasyLeague.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private readonly IDataAccess<T, int> dataAccess;

        public GenericRepository (IDataAccess<T, int> dao)
        {
            this.dataAccess = dao;
        }

        public T GetById(int id)
        {
            T entity = dataAccess.Get(id);
            if (entity.Status != Status.Active)
                throw new Exception("The requested entity is inactive or deleted.");
            return entity;
        }

        public ICollection<T> GetAllActives()
        {
            return dataAccess.All().Where(e => e.Status == Status.Active).ToList();
        }

        public T Update (T entity)
        {
            entity.AlteredOn = DateTime.Now;
            return dataAccess.Save(entity);
        }

        public T Create (T entity)
        {
            entity.Status = AirBallFantasyLeague.Model.Status.Active;
            entity.CreatedOn = DateTime.Now;
            entity.AlteredOn = entity.CreatedOn;

            return dataAccess.Add(entity);
        }
        //performs a logical exclusion
        public bool Delete (T entity)
        {
            entity.Status = AirBallFantasyLeague.Model.Status.Deleted;
            entity.AlteredOn = DateTime.Now;

            var objReturned = dataAccess.Save(entity);

            return objReturned.Status == Status.Deleted;
        }
               
    }
}
