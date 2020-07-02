using AirBallFantasyLeague.Data;
using AirBallFantasyLeague.EntityFramework;
using AirBallFantasyLeague.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirBallFantasyLeague.Tests.DataAccess
{
    [TestClass]
    public class EntitiesPersistenceTest
    {
        #region User
        [TestMethod]
        public void ShouldAddUser()
        {
            GenericUnitTestHelper.ShouldAddEntity<User>();
        }

        [TestMethod]
        public void ShouldFailAddingUser()
        {
            GenericUnitTestHelper.ShouldFailAddingEntity<User>();
        }

        [TestMethod]
        public void ShouldSaveUser()
        {
            GenericUnitTestHelper.SaveEntitySuccess<User>();
        }

        [TestMethod]
        public void ShouldFailSavingUser()
        {
            GenericUnitTestHelper.ShouldFailAddingEntity<User>();
        }
        [TestMethod]
        public void ShoudGetUser()
        {
            GenericUnitTestHelper.GetEntitySuccess<User>();
        }

        [TestMethod]
        public void ShouldRemoveUser()
        {
            GenericUnitTestHelper.RemoveEntitySuccess<User>();
        }

        [TestMethod]
        public void ShoudListAllUsers()
        {
            GenericUnitTestHelper.ListAllEntitiesSuccess<User>();
        }
        #endregion

        #region League
        [TestMethod]
        public void ShouldAddLeague()
        {
            GenericUnitTestHelper.ShouldAddEntity<League>();
        }

        [TestMethod]
        public void ShouldFailAddingLeague()
        {
            GenericUnitTestHelper.ShouldFailAddingEntity<League>();
        }

        [TestMethod]
        public void ShouldSaveLeague()
        {
            GenericUnitTestHelper.SaveEntitySuccess<League>();
        }

        [TestMethod]
        public void ShouldFailSavingLeague()
        {
            GenericUnitTestHelper.SaveEntityError<League>();
        }
        [TestMethod]
        public void ShoudGetLeague()
        {
            GenericUnitTestHelper.GetEntitySuccess<League>();
        }

        [TestMethod]
        public void ShouldRemoveLeague()
        {
            GenericUnitTestHelper.RemoveEntitySuccess<League>();
        }

        [TestMethod]
        public void ShoudListAllLeagues()
        {
            GenericUnitTestHelper.ListAllEntitiesSuccess<League>();
        }

        #endregion

        #region Official Team
        [TestMethod]
        public void ShouldAddOfficialTeam()
        {
            GenericUnitTestHelper.ShouldAddEntity<OfficialTeam>();
        }

        [TestMethod]
        public void ShouldFailAddingOfficialTeam()
        {
            GenericUnitTestHelper.ShouldFailAddingEntity<OfficialTeam>();
        }

        [TestMethod]
        public void ShouldSaveOfficialTeam()
        {
            GenericUnitTestHelper.SaveEntitySuccess<OfficialTeam>();
        }

        [TestMethod]
        public void ShouldFailSavingOfficialTeam()
        {
            GenericUnitTestHelper.SaveEntityError<OfficialTeam>();
        }

        [TestMethod]
        public void ShouldNotRemoveOfficialTeam()
        {
            //just learned it won't work with InMemory database, once the foreign key validation is done only 
            //in real relational dabatases lol

            //using (var context = new AirBallInMemoryContext("AirBall"))
            //{
            //    var game = CreateMockOfficialGame(context);

             //   GenericDAO<OfficialTeam> dao = new GenericDAO<OfficialTeam>(context);

             //   Assert.IsFalse(dao.Remove(game.AwayOfficialTeam));
             //   Assert.IsNotNull(game.AwayOfficialTeam);
            //}
        }
        #endregion

        #region Sport Position
        [TestMethod]
        public void ShouldAddSportPosition()
        {
            GenericUnitTestHelper.ShouldAddEntity<SportPosition>();
        }

        [TestMethod]
        public void ShouldFailAddingSportPosition()
        {
            GenericUnitTestHelper.ShouldFailAddingEntity<SportPosition>();
        }

        [TestMethod]
        public void ShouldSaveSportPosition()
        {
            GenericUnitTestHelper.SaveEntitySuccess<SportPosition>();
        }

        [TestMethod]
        public void ShouldFailSavingSportPosition()
        {
            GenericUnitTestHelper.SaveEntityError<SportPosition>();
        }
        [TestMethod]
        public void ShoudGetPosition()
        {
            GenericUnitTestHelper.GetEntitySuccess<SportPosition>();
        }

        [TestMethod]
        public void ShouldRemovePosition()
        {
            GenericUnitTestHelper.RemoveEntitySuccess<SportPosition>();
        }

        [TestMethod]
        public void ShoudListAllPositions()
        {
            GenericUnitTestHelper.ListAllEntitiesSuccess<SportPosition>();
        }
        #endregion

        #region Team
        [TestMethod]
        public void ShouldAddTeam()
        {
            using (var context = new AirBallInMemoryContext("AirBall"))
            {
                int expectedId = 1;
                int expectedUserId = 1;
                int expectedLeagueId = 1;
                string expectedDate = DateTime.Now.ToShortDateString();

                GenericDAO<Team> dao = new GenericDAO<Team>(context);
                var entity = dao.Add(CreateMockTeam(context));

                Assert.AreEqual(expectedId, entity.Id);
                Assert.AreEqual(expectedUserId, entity.UserId);
                Assert.AreEqual(expectedLeagueId, entity.LeagueId);
                Assert.AreEqual(expectedDate, entity.CreatedOn.ToShortDateString());

                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ShouldSaveTeam()
        {
            using (var context = new AirBallInMemoryContext("AirBall"))
            {
                string expectedFirstName = "Phoenix";
                string expectedSecondName = "Suns";
                string expectedDate = DateTime.Now.ToShortDateString();

                GenericDAO<Team> dao = new GenericDAO<Team>(context);
                var entity = dao.Add(CreateMockTeam(context));

                entity.FirstName = "Phoenix";
                entity.SecondName = "Suns";

                entity = dao.Save(entity);

                Assert.AreEqual(expectedFirstName, entity.FirstName);
                Assert.AreEqual(expectedSecondName, entity.SecondName);
                Assert.AreEqual(expectedDate, entity.AlteredOn.Value.ToShortDateString());

                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ShoudGetTeam()
        {
            GenericUnitTestHelper.GetEntitySuccess<Team>();
        }

        [TestMethod]
        public void ShouldRemoveTeam()
        {
            GenericUnitTestHelper.RemoveEntitySuccess<Team>();
        }

        [TestMethod]
        public void ShoudListAllTeams()
        {
            GenericUnitTestHelper.ListAllEntitiesSuccess<Team>();
        }

        private Team CreateMockTeam(IDbContext context)
        {
            GenericDAO<League> leagueDao = new GenericDAO<League>(context);
            var league = leagueDao.Add(new GenericUnitTestHelper.GenericEntity<League>().CreateValidEntry());

            GenericDAO<User> userDao = new GenericDAO<User>(context);
            var user = userDao.Add(new GenericUnitTestHelper.GenericEntity<User>().CreateValidEntry());

            Team entity = new GenericUnitTestHelper.GenericEntity<Team>().CreateValidEntry();

            entity.FirstName = "Dallas";
            entity.SecondName = "Mavericks";
            entity.User = user;
            entity.League = league;
            entity.AlteredById = user.Id;

            return entity;
        }
        #endregion

        #region OfficialGame
        [TestMethod]
        public void ShouldAddOfficialGame()
        {
            using (var context = new AirBallInMemoryContext("AirBall"))
            {
                CreateMockOfficialGame(context);

                OfficialGameDAO dao = new OfficialGameDAO(context);
                var returnedEntity = dao.Get((long)1);

                Assert.IsNotNull(returnedEntity);
                Assert.AreEqual(1, returnedEntity.Id);

                context.Database.EnsureDeleted();
            }
        }
        private OfficialGame CreateMockOfficialGame(IDbContext context)
        {
            OfficialTeam team1 = new GenericUnitTestHelper.GenericEntity<OfficialTeam>().CreateValidEntry();
            OfficialTeam team2 = new GenericUnitTestHelper.GenericEntity<OfficialTeam>().CreateValidEntry();
            team2.Name = "Cleveland";

            GenericDAO<OfficialTeam> dTeam = new GenericDAO<OfficialTeam>(context);
            team1 = dTeam.Add(team1);
            team2 = dTeam.Add(team2);

            OfficialGame officialGame = new OfficialGame();
            officialGame.Date = DateTime.Now;
            officialGame.SportId = Model.Enums.Sport.Basketball;
            officialGame.Season = 1;
            officialGame.HomeOfficialTeam = team1;
            officialGame.HomeOfficialTeamId = team1.Id;
            officialGame.AwayOfficialTeam = team2;
            officialGame.AwayOfficialTeamId = team2.Id;
            officialGame.AwayScore = 0;
            officialGame.HomeScore = 0;

            OfficialGameDAO dao = new OfficialGameDAO(context);
            return dao.Add(officialGame);
        } 

        #endregion
    }
}
