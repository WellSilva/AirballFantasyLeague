using System;
using System.Collections.Generic;
using System.Text;

namespace AirBallFantasyLeague.Model
{
    public class Entity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime AlteredOn { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}
