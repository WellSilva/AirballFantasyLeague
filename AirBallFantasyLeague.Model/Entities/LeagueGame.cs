using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class LeagueGame
    {
        public long Id { get; set; }
        public long OfficialGameId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public virtual OfficialGame OfficialGame { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }

        public Team GetWinner()
        {
            if (HomeScore > AwayScore)
                return HomeTeam;
            else if (AwayScore > HomeScore)
                return AwayTeam;
            else
                return null;
        }

    }
}
