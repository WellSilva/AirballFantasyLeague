using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class BasketballPlayerStats
    {
        public int PlayerId { get; set; }
        public int Season { get; set; }
        public int GameId { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public int Steal { get; set; }
        public int Block { get; set; }
        public int Turnover { get; set; }
        public int ThreePoints { get; set; }

        public virtual Player Player { get; set; }
    }
}
