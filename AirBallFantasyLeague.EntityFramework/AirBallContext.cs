using Microsoft.EntityFrameworkCore;
using System;
using AirBallFantasyLeague.Model.Entities;

namespace AirBallFantasyLeague.EntityFramework
{
    public class AirBallContext : DbContext
    {
        public AirBallContext(DbContextOptions<AirBallContext> options)
            : base(options)
        { }

        public DbSet<BasketballPlayerStats> BasketballPlayerStats { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueGame> LeagueGames { get; set; }
        public DbSet<OfficialGame> OfficialGames { get; set; }
        public DbSet<OfficialTeam> OfficialTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerLeaguePosition> PlayerLeaguePositions { get; set; }
        public DbSet<SportPosition> SportPositions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
