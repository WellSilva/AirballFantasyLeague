using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using AirBallFantasyLeague.Model.Entities;

namespace AirBallFantasyLeague.EntityFramework
{
    public class AirBallContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=AirBallFantasy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<BasketballPlayerStats>()
                .HasKey(c => new { c.PlayerId, c.GameId }
                );
        }

        public DbSet<BasketballPlayerStats> BasketballPlayerStats { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueGame> LeagueGames { get; set; }
        public DbSet<OfficialGame> OfficialGames { get; set; }
        public DbSet<OfficialTeam> OfficialTeams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerLeagueSportPosition> PlayerLeaguePositions { get; set; }
        public DbSet<SportPosition> SportPositions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
