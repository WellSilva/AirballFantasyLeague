using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }

        public virtual List<Team> Teams { get; set; }
    }
}
