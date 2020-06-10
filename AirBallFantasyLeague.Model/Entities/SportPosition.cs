using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class SportPosition : Entity
    {
        public int SportId { get; set; }
        public string Position { get; set; }

        public virtual Sport Sport { get; set; }

        public virtual List<PlayerLeagueSportPosition> PlayerLeaguePositions { get; set; }

    }
}
