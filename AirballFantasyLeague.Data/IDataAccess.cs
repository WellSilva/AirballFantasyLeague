using System;
using System.Linq;

namespace AirBallFantasyLeague.Data
{
    public interface IDataAccess<TEntity, TPK> where TEntity : class
    {
        TEntity Add(TEntity entity);

        TEntity Save(TEntity entity);

        bool Remove(TEntity entity);

        TEntity Get(TPK Id);

        IQueryable<TEntity> All();
    }
}
