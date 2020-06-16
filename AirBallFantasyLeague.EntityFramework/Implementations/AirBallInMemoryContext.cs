using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using AirBallFantasyLeague.Model.Entities;

namespace AirBallFantasyLeague.EntityFramework
{
    public class AirBallInMemoryContext : DbContext, IDbContext
    {
        private string InMemoryDatabaseName = "";

        public AirBallInMemoryContext()
        {

        }

        //Constructor for tests, using in memory db
        public AirBallInMemoryContext (String InMemoryDBName)
        {
            this.InMemoryDatabaseName = InMemoryDBName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(this.InMemoryDatabaseName);
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
