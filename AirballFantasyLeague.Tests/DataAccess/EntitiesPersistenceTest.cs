using AirBallFantasyLeague.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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
        #endregion

    }
}
