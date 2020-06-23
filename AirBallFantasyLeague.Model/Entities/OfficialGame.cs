using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class OfficialGame
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public Sport SportId { get; set; }
        public int Season { get; set; }
        [Required]
        public int HomeOfficialTeamId { get; set; }
        [Required]
        public int AwayOfficialTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        [NotMapped]
        public OfficialTeam HomeOfficialTeam { get; set; }
        [NotMapped]
        public OfficialTeam AwayOfficialTeam { get; set; }

        public OfficialTeam GetWinner() {
            if (HomeScore > AwayScore)
                return HomeOfficialTeam;
            else if (AwayScore > HomeScore)
                return AwayOfficialTeam;
            else
                return null;
        }

    }
}
