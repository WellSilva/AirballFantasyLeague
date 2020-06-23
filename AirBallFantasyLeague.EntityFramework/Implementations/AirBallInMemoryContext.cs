using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Linq;
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
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(this.InMemoryDatabaseName);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            modelBuilder.Entity<BasketballPlayerStats>()
                .HasKey(c => new { c.PlayerId, c.GameId }
                );

            modelBuilder.Entity<OfficialTeam>()
                .HasMany(t => t.AwayOfficialGames)
                .WithOne().HasForeignKey(g => g.AwayOfficialTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OfficialTeam>()
                .HasMany(t => t.HomeOfficialGames)
                .WithOne().HasForeignKey(g => g.HomeOfficialTeamId)
                .OnDelete(DeleteBehavior.Restrict);
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
