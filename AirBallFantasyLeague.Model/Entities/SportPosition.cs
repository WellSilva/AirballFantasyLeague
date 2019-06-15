using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class SportPosition
    {
        public int Id { get; set; }
        public Sport SportId { get; set; }
        public string Position { get; set; }

    }
}
