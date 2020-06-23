using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class Player : Entity
    {
        [Required]
        public int OfficialTeamId { get; set; }
        public int TeamId { get; set; }
        public int Age { get; set; }
        public bool Retired { get; set; }
        public bool OutSeason { get; set; }
        public Sport SportId { get; set; }
        public int? DraftYear { get; set; }

        public virtual OfficialTeam OfficialTeam { get; set; }
        public virtual List<PlayerLeagueSportPosition> PlayerLeaguePositions { get; set; }
        public virtual List<BasketballPlayerStats> BasketballPlayerStats { get; set; }
    }
}
