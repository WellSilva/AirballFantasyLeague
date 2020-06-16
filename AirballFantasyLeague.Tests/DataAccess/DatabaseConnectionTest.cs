using AirBallFantasyLeague.EntityFramework;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AirBallFantasyLeague.Tests
{
    [TestClass]
    public class DatabaseConnectionTest    
    {
        [TestMethod]
        public void ShouldConnect()
        {
            var expected = true;
            var result = false;

            using (AirBallContext context = new AirBallContext())
            {
                result = context.Database.GetService<IRelationalDatabaseCreator>().Exists();
            }

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldCreateInMemoryDatabase()
        {
            var expected = true;
            var result = false;

            using (AirBallInMemoryContext context = new AirBallInMemoryContext("AirBall"))
            {
                result = context.Database.EnsureCreated();
            }

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ShouldNotCreateInMemoryDatabase()
        {
            var expected = false;
            var result = false;

            try
            {
                using (AirBallInMemoryContext context = new AirBallInMemoryContext())
                {
                    result = context.Database.EnsureCreated();
                }
            }catch
            {
            }

            Assert.AreEqual(expected, result);
        }
    }
}
