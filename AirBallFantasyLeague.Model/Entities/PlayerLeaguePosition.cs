using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class PlayerLeaguePosition
    {
        public int LeagueId { get; set; }
        public int PlayerId { get; set; }
        public int SportPositionId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime AlteredTime { get; set; }
        public int AlteredById { get; set; }

        public virtual League League { get; set; }
        public virtual Player Player { get; set; }
        public virtual SportPosition SportPosition { get; set; }
        public virtual User AlteredBy { get; set; }
    }
}
