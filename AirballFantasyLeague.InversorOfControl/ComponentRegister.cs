using AirBallFantasyLeague.IDataAccess;
using AirBallFantasyLeague.Data;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using AirBallFantasyLeague.Model.Entities;

namespace AirBallFantasyLeague.InversorOfControl
{
    public static class ComponentRegister
    {
        public static WindsorContainer RegisterComponents (WindsorContainer container)
        {
            container.Register(Component.For(typeof(IDataAccess<>)).ImplementedBy(typeof(GenericDAO<>)));

            return container;
        }
    }
}
