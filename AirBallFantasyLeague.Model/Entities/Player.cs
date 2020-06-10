using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class Player : Entity
    {
        public int OfficialTeamId { get; set; }
        public int TeamId { get; set; }
        public int Age { get; set; }
        public bool Retired { get; set; }
        public bool OutSeason { get; set; }
        public int SportId { get; set; }

        public virtual Sport Sport { get; set; }
        public virtual Team FantasyTeam { get; set; }
        public virtual OfficialTeam OfficialTeam { get; set; }
        public virtual List<PlayerLeagueSportPosition> PlayerLeaguePositions { get; set; }
    }
}
