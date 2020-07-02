using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Repositories
{
    public interface IGenericRepository<T> where T : Entity
    {
        T GetById(int id);

        ICollection<T> GetAllActives();

        T Update(T entity);

        T Create(T entity);

        //performs a logical exclusion
        bool Delete(T entity);
    }
}
