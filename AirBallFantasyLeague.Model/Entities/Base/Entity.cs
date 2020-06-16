using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirBallFantasyLeague.Model
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AlteredOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? AlteredById { get; set; }

        public virtual Entities.User AlteredBy { get; set; }
    }
}
