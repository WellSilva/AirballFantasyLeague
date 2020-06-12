using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class BasketballPlayerStats
    {
        [Key]
        public int PlayerId { get; set; }
        [Key]
        public int GameId { get; set; }
        public int Season { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Assists { get; set; }
        public int Steals { get; set; }
        public int Blocks { get; set; }
        public int Turnover { get; set; }
        public int ThreePoints { get; set; }

        public virtual Player Player { get; set; }
        public virtual OfficialGame Game { get; set;}

    }
}
