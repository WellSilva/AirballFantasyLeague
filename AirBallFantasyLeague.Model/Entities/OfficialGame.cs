using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class OfficialGame
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public Sport Sport { get; set; }
        public int HomeOfficialTeamId { get; set; }
        public int AwayOfficialTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public virtual OfficialTeam HomeOfficialTeam { get; set; }
        public virtual OfficialTeam AwayOfficialTeam { get; set; }

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
