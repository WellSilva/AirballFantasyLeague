using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirBallFantasyLeague.Model;
using System.Reflection;
using System;
using System.Linq;
using AirBallFantasyLeague.EntityFramework;
using AirBallFantasyLeague.Data;
using System.Collections.Generic;

namespace AirBallFantasyLeague.Tests
{
    public static class GenericUnitTestHelper    
    {
        #region GenericDAOMethods
        public static void ShouldAddEntity<TEntity>() where TEntity : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball")) {

                GenericDAO<TEntity> dao = new GenericDAO<TEntity>(context);
                var entityTest = new GenericEntity<TEntity>().CreateValidEntry();
                entityTest.CreatedOn = DateTime.Now;
                entityTest.AlteredOn = DateTime.Now;

                var entity = dao.Add(entityTest);

                var expectedDate = DateTime.Now.ToShortDateString();

                Assert.IsNotNull(entity);
                Assert.AreNotEqual(0, entity.Id);
                Assert.AreEqual(expectedDate, entity.CreatedOn.ToShortDateString());

                context.Database.EnsureDeleted();
            }
        }
               
        public static void ShouldFailAddingEntity<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {
                GenericDAO<T> dao = new GenericDAO<T>(context);

                bool fail = false;
                var unexpectedDate = DateTime.Now.ToShortDateString();

                try
                {
                    var entity = dao.Add(new GenericEntity<T>().CreateInvalidEntry());

                    Assert.IsNull(entity);
                    Assert.AreEqual(0, entity.Id);
                    Assert.AreNotEqual(unexpectedDate, entity.CreatedOn.ToShortDateString());
                    fail = true;
                }
                catch (Exception)
                {
                    fail = true;
                }

                Assert.IsTrue(fail);

                context.Database.EnsureDeleted();
            }
        }

        public static void SaveEntitySuccess<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {
                GenericDAO<T> dao = new GenericDAO<T>(context);
                var entity = new GenericEntity<T>().CreateValidEntry();

                entity.CreatedOn = DateTime.Now;
                entity.AlteredOn = DateTime.Now;
                entity = dao.Add(entity);

                var returnedEntity = dao.Save(entity);

                var expectedDate = DateTime.Now.ToShortDateString();

                Assert.IsNotNull(entity);
                Assert.AreEqual(returnedEntity.Id, entity.Id);
                Assert.IsNotNull(returnedEntity.AlteredOn);
                Assert.AreEqual(expectedDate, entity.AlteredOn.Value.ToShortDateString());

                context.Database.EnsureDeleted();
            }
        }

        public static void SaveEntityError<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {
                GenericDAO<T> dao = new GenericDAO<T>(context);
                var entity = dao.Add(new GenericEntity<T>().CreateValidEntry());

                var unexpectedDate = DateTime.Now.ToShortDateString();
                bool fail = false;

                try
                {
                    entity.Status = Status.Inactive;
                    var returnedEntity = dao.Save(entity); ;

                    Assert.IsNull(returnedEntity);
                    Assert.AreNotEqual(unexpectedDate, entity.AlteredOn.Value.ToShortDateString());
                    fail = true;
                }
                catch (Exception)
                {
                    fail = true;
                }

                Assert.IsTrue(fail);

                context.Database.EnsureDeleted();
            }
        }

        public static void RemoveEntitySuccess<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {
                GenericDAO<T> dao = new GenericDAO<T>(context);

                var entity = dao.Add(new GenericEntity<T>().CreateValidEntry());
                var removed = dao.Remove(entity);

                Assert.IsTrue(removed);

                context.Database.EnsureDeleted();
            }
        }

        public static void RemoveEntityError<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {
                GenericDAO<T> dao = new GenericDAO<T>(context);
                var entity = new GenericEntity<T>().CreateValidEntry();
                var removed = true;
                try
                {
                    removed = dao.Remove(entity);
                }
                catch 
                {
                    removed = false;
                }

                Assert.IsFalse(removed);

                context.Database.EnsureDeleted();
            }
        }

        public static void GetEntitySuccess<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {

                GenericDAO<T> dao = new GenericDAO<T>(context);
                var entity = dao.Add(new GenericEntity<T>().CreateValidEntry());

                var expectedId = 1;
                var returnedEntity = dao.Get(1);

                Assert.IsNotNull(returnedEntity);
                Assert.AreEqual(expectedId, returnedEntity.Id);

                context.Database.EnsureDeleted();
            }

        }

        public static void GetEntityError<T>() where T : Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {
                GenericDAO<T> dao = new GenericDAO<T>(context);
                var returnedEntity = dao.Get(1);
                Assert.IsNull(returnedEntity); //nothing in the database yet, must return nothing

                var entity = dao.Add(new GenericEntity<T>().CreateValidEntry());

                returnedEntity = dao.Get(2);
                Assert.IsNull(returnedEntity);

                context.Database.EnsureDeleted();
            }

        }

        public static void ListAllEntitiesSuccess<T>() where T:Entity
        {
            using (var context = new AirBallInMemoryContext("Airball"))
            {

                GenericDAO<T> dao = new GenericDAO<T>(context);

                List<T> data = new GenericEntity<T>().CreateValidEntries(5);
                foreach (var obj in data)
                    dao.Add(obj);

                var expectedCount = data.Count;

                var returnedData = dao.All().ToList().Count();
                Assert.IsNotNull(returnedData);
                Assert.AreEqual(expectedCount, returnedData);

                context.Database.EnsureDeleted();
            }
        }
        #endregion

        #region GenericClass
        public class GenericEntity<T> where T : class
        {
            public GenericEntity() {

            }
            public T CreateValidEntry () {

                var entity = (T)Activator.CreateInstance(typeof(T));

                try
                {
                    foreach (PropertyInfo info in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (info.Name != "Id" && info.Name != "CreatedOn" && info.Name != "AlteredOn" && info.Name != "DeletedOn" && info.Name != "Status")
                        {
                            SetProperty(entity, info);
                        }
                    }
                }catch (Exception)
                {
                    entity = null;
                }

                return entity;
            }

            public T CreateInvalidEntry()
            {
                var entity = (T)Activator.CreateInstance(typeof(T));

                //creates an invalid key 
                var prop = entity.GetType().GetProperty("Id");
                prop.SetValue(entity, 1);

                return entity;
            }

            public List<T> CreateValidEntries(int number)
            {
                List<T> result = new List<T>();

                for (int x = 0; x < number; x++)
                {
                    var entity = (T)Activator.CreateInstance(typeof(T));

                    foreach (PropertyInfo info in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (info.Name != "Id" && info.Name != "CreatedOn" && info.Name != "AlteredOn" && info.Name != "DeletedOn" && info.Name != "Status")
                        {
                            SetProperty(entity, info);
                        }
                    }

                    var nameProp = entity.GetType().GetProperty("Name");
                    nameProp.SetValue(entity, nameProp.GetValue(entity).ToString() + " " + x);

                    result.Add(entity);
                }

                return result;
            }

            private bool SetProperty(object obj, PropertyInfo info)
            {
                var type = Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType;

                if (info.CanWrite)
                {
                    info.SetValue(obj, GetValuePerType(info.Name, type));
                    return true;
                }
                return false;
            }

            private object GetValuePerType(string name, Type type)
            {
                if (type == typeof(int))
                    return 1;
                if (type == typeof(DateTime))
                    return DateTime.Now;
                if (type == typeof(string))
                    return name + " testing";
                if (type == typeof(DateTime))
                    return DateTime.Now;
                if (type == typeof(bool))
                    return false;

                return null;
            }
        }

        #endregion
    }
}
