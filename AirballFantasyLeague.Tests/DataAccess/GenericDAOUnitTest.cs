using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirBallFantasyLeague.Model.Entities;
using System.Reflection;
using System;
using AirBallFantasyLeague.EntityFramework;
using AirballFantasyLeague.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirballFantasyLeague.Tests
{
    [TestClass]
    public class GenericDAOUnitTest    
    {

        [TestMethod]
        public void ShouldAddNewEntity()
        {
            using (var context = new AirBallContext("Airball")) {

                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);
                var entity = dao.Add(new GenericEntity<User>().CreateValidEntry(new User()));

                //setup
                var expectedName = "Name testing";
                var expectedDate = DateTime.Now.ToShortDateString();

                //results
                Assert.IsNotNull(entity);
                Assert.AreNotEqual(0, entity.Id);
                Assert.AreEqual(expectedDate, entity.CreatedOn.ToShortDateString());
                Assert.AreEqual(expectedName, entity.Name);

                //clear database
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ShouldFailAddingNewEntity()
        {
            using (var context = new AirBallContext("Airball"))
            {
                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);

                //setup
                bool fail = false;
                var unexpectedDate = DateTime.Now.ToShortDateString();
                try
                {
                    var entity = dao.Add(new GenericEntity<User>().CreateInvalidEntry(new User()));

                    Assert.IsNull(entity);
                    Assert.AreEqual(0, entity.Id);
                    Assert.AreNotEqual(unexpectedDate, entity.CreatedOn.ToShortDateString());
                    fail = true;
                }
                catch (Exception)
                {
                    fail = true;
                }

                //results
                Assert.IsTrue(fail);

                //clear database
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void SaveEntitySuccess()
        {
            using (var context = new AirBallContext("Airball"))
            {
                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);
                var entity = dao.Add(new GenericEntity<User>().CreateValidEntry(new User()));
                entity.Name = "Name testing edited";
                var returnedEntity = dao.Save(entity);

                //setup
                var expectedName = "Name testing edited";
                var expectedDate = DateTime.Now.ToShortDateString();

                //results
                Assert.IsNotNull(entity);
                Assert.AreEqual(returnedEntity.Id, entity.Id);
                Assert.IsNotNull(returnedEntity.AlteredOn);
                Assert.AreEqual(expectedDate, entity.AlteredOn.Value.ToShortDateString());
                Assert.AreEqual(expectedName, entity.Name);

                //clear database
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void SaveEntityError()
        {
            using (var context = new AirBallContext("Airball"))
            {
                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);
                var entity = dao.Add(new GenericEntity<User>().CreateValidEntry(new User()));

                //setup
                var unexpectedDate = DateTime.Now.ToShortDateString();
                bool fail = false;

                try
                {
                    entity.Name = String.Empty;
                    var returnedEntity = dao.Save(entity); ;

                    Assert.IsNull(returnedEntity);
                    Assert.AreNotEqual(unexpectedDate, entity.AlteredOn.Value.ToShortDateString());
                    fail = true;
                }
                catch (Exception)
                {
                    fail = true;
                }

                //results
                Assert.IsTrue(fail);

                //clear database
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void GetEntitySuccess()
        {
            using (var context = new AirBallContext("Airball"))
            {
                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);
                var entity = dao.Add(new GenericEntity<User>().CreateValidEntry(new User()));

                //setup
                var expectedName = "Name testing";
                var expectedId = 1;
                var returnedEntity = dao.Get(1);

                //results
                Assert.IsNotNull(returnedEntity);
                Assert.AreEqual(expectedId, returnedEntity.Id);
                Assert.AreEqual(expectedName, returnedEntity.Name);

                //clear database
                context.Database.EnsureDeleted();
            }

        }

        [TestMethod]
        public void GetEntityError()
        {
            using (var context = new AirBallContext("Airball"))
            {

                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);
                var returnedEntity = dao.Get(1);
                Assert.IsNull(returnedEntity); //nohting in the database yet, must return nothing
                var entity = dao.Add(new GenericEntity<User>().CreateValidEntry(new User()));

                //setup
                returnedEntity = dao.Get(2);

                //results
                Assert.IsNull(returnedEntity);

                //clear database
                context.Database.EnsureDeleted();
            }

        }

        [TestMethod]
        public async Task ShouldListAllEntities()
        {
            using (var context = new AirBallContext("Airball"))
            {
                //seeding db
                GenericDAO<User> dao = new GenericDAO<User>(context);
                List<User> data = new GenericEntity<User>().CreateValidEntries(5);
                foreach (var user in data)
                    dao.Add(user);

                //setup
                var expectedCount = data.Count;

                //results
                var returnedData = await dao.All().ToListAsync();
                Assert.IsNotNull(returnedData);
                Assert.AreEqual(expectedCount, returnedData.Count);

                //clear database
                context.Database.EnsureDeleted();
            }
        }

        private class GenericEntity<T> where T : class
        {
            public GenericEntity() {

            }
            public T CreateValidEntry (T value) {

                var entity = value;

                try
                {
                    foreach (PropertyInfo info in value.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (info.Name != "Id" && info.Name != "CreatedOn" && info.Name != "AlteredOn" && info.Name != "DeletedOn" && info.Name != "Status")
                        {
                            SetProperty(value, info);
                        }
                    }
                }catch (Exception)
                {
                    entity = null;
                }

                return entity;
            }

            public T CreateInvalidEntry(T value)
            {
                var entity = value;

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
    }
}
