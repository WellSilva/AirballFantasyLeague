using System;
using AirBallFantasyLeague.Model.Entities;

namespace AirBallFantasyLeague.Model.Entities
{
    public class Team : Entity
    {
        public int LeagueId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Mascot { get; set; }
        public string LogoPath { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual League League { get; set; }
    }
}
