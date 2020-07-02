using AirBallFantasyLeague.IDataAccess;
using AirBallFantasyLeague.Data;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using AirBallFantasyLeague.Model.Entities;

namespace AirBallFantasyLeague.CrossCutting
{
    public static class DataAccessInstaller
    {
        public static void RegisterComponents (WindsorContainer container)
        {
            container.Register(Component.For(typeof(IDataAccess<>)).ImplementedBy(typeof(GenericDAO<>)));
        }
    }
}
