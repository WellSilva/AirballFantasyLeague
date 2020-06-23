﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirBallFantasyLeague.Model.Entities
{
    public class PlayerLeagueSportPosition
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public int LeagueId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public int SportPositionId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime AlteredTime { get; set; }
        public int AlteredById { get; set; }

        public virtual League League { get; set; }
        public virtual Player Player { get; set; }
        public virtual SportPosition SportPosition { get; set; }
    }
}
