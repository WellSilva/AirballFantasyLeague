using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class Player : Entity
    {
        public string OfficialTeam { get; set; }
        public int TeamId { get; set; }
        public int Age { get; set; }
        public bool Retired { get; set; }
        public bool OutSeason { get; set; }
        public Sport SportId { get; set; }
    }
}
