using AirBallFantasyLeague.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class League : Entity
    {
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string LogoPath { get; set; }
        public string Description { get; set; }
        public Sport SportId { get; set; }
        public int NumberTeams { get; set; }
        public Mode ModeId { get; set; }
        public double CapSpace { get; set;}
    }
}
