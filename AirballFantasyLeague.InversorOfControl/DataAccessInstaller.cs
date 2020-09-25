using AirBallFantasyLeague.Data;
using AirBallFantasyLeague.Model.Repositories;
using AirBallFantasyLeague.Repository;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace AirBallFantasyLeague.CrossCutting
{
    public static class DataAccessInstaller
    {
        public static void RegisterComponents (WindsorContainer container)
        {
            container.Register(Component.For(typeof(IDataAccess<,>)).ImplementedBy(typeof(GenericDAO<>)));
            container.Register(Component.For(typeof(IDataAccess<,>)).ImplementedBy(typeof(OfficialGameDAO)));
            container.Register(Component.For(typeof(IGenericRepository<>)).ImplementedBy(typeof(GenericRepository<>)));
        }
    }
}
