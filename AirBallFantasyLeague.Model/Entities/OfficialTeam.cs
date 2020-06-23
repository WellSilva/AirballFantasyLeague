using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class OfficialTeam : Entity
    {
        public string LogoPath { get; set; }

        public Sport SportId { get; set; }

        public virtual List<OfficialGame> HomeOfficialGames { get; set; }
        public virtual List<OfficialGame> AwayOfficialGames { get; set; }
    }
}
