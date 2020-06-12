﻿// <auto-generated />
using System;
using AirBallFantasyLeague.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AirBallFantasyLeague.EntityFramework.Migrations
{
    [DbContext(typeof(AirBallContext))]
    [Migration("20200612155701_AlteredDeletedTimeNullable")]
    partial class AlteredDeletedTimeNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.BasketballPlayerStats", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameId");

                    b.Property<int>("Assists");

                    b.Property<int>("Blocks");

                    b.Property<long?>("GameId1");

                    b.Property<int>("Points");

                    b.Property<int>("Rebounds");

                    b.Property<int>("Season");

                    b.Property<int>("Steals");

                    b.Property<int>("ThreePoints");

                    b.Property<int>("Turnover");

                    b.HasKey("PlayerId", "GameId");

                    b.HasAlternateKey("GameId", "PlayerId");

                    b.HasIndex("GameId1");

                    b.ToTable("BasketballPlayerStats");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AlteredOn");

                    b.Property<double>("CapSpace");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Description");

                    b.Property<string>("LogoPath");

                    b.Property<int>("ModeId");

                    b.Property<string>("Name");

                    b.Property<int>("NumberTeams");

                    b.Property<int>("SportId");

                    b.Property<string>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.LeagueGame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayScore");

                    b.Property<int>("AwayTeamId");

                    b.Property<int>("HomeScore");

                    b.Property<int>("HomeTeamId");

                    b.Property<long>("OfficialGameId");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("OfficialGameId");

                    b.ToTable("LeagueGames");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.OfficialGame", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwayOfficialTeamId");

                    b.Property<int>("AwayScore");

                    b.Property<DateTime>("Date");

                    b.Property<int>("HomeOfficialTeamId");

                    b.Property<int>("HomeScore");

                    b.Property<int>("Season");

                    b.Property<int>("Sport");

                    b.Property<int>("SportId");

                    b.HasKey("Id");

                    b.HasIndex("AwayOfficialTeamId");

                    b.HasIndex("HomeOfficialTeamId");

                    b.ToTable("OfficialGames");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.OfficialTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AlteredOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("LogoPath");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("OfficialTeams");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<DateTime?>("AlteredOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<int>("OfficialTeamId");

                    b.Property<bool>("OutSeason");

                    b.Property<bool>("Retired");

                    b.Property<int>("Sport");

                    b.Property<int>("SportId");

                    b.Property<int>("Status");

                    b.Property<int>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("OfficialTeamId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.PlayerLeagueSportPosition", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlteredById");

                    b.Property<DateTime>("AlteredTime");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("LeagueId");

                    b.Property<int>("PlayerId");

                    b.Property<int>("SportPositionId");

                    b.HasKey("Id");

                    b.HasIndex("AlteredById");

                    b.HasIndex("LeagueId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SportPositionId");

                    b.ToTable("PlayerLeaguePositions");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.SportPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AlteredOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Position");

                    b.Property<int>("Sport");

                    b.Property<int>("SportId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("SportPositions");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AlteredOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("FirstName");

                    b.Property<int>("LeagueId");

                    b.Property<string>("LogoPath");

                    b.Property<string>("Mascot");

                    b.Property<string>("SecondName");

                    b.Property<int>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("UserId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("AlteredOn");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DeletedOn");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Status");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.BasketballPlayerStats", b =>
                {
                    b.HasOne("AirBallFantasyLeague.Model.Entities.OfficialGame", "Game")
                        .WithMany()
                        .HasForeignKey("GameId1");

                    b.HasOne("AirBallFantasyLeague.Model.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.LeagueGame", b =>
                {
                    b.HasOne("AirBallFantasyLeague.Model.Entities.Team", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.Team", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.OfficialGame", "OfficialGame")
                        .WithMany()
                        .HasForeignKey("OfficialGameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.OfficialGame", b =>
                {
                    b.HasOne("AirBallFantasyLeague.Model.Entities.OfficialTeam", "AwayOfficialTeam")
                        .WithMany()
                        .HasForeignKey("AwayOfficialTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.OfficialTeam", "HomeOfficialTeam")
                        .WithMany()
                        .HasForeignKey("HomeOfficialTeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.Player", b =>
                {
                    b.HasOne("AirBallFantasyLeague.Model.Entities.OfficialTeam", "OfficialTeam")
                        .WithMany()
                        .HasForeignKey("OfficialTeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.Team", "FantasyTeam")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.PlayerLeagueSportPosition", b =>
                {
                    b.HasOne("AirBallFantasyLeague.Model.Entities.User", "AlteredBy")
                        .WithMany()
                        .HasForeignKey("AlteredById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.League", "League")
                        .WithMany("PlayerLeaguePositions")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.Player", "Player")
                        .WithMany("PlayerLeaguePositions")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.SportPosition", "SportPosition")
                        .WithMany("PlayerLeaguePositions")
                        .HasForeignKey("SportPositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AirBallFantasyLeague.Model.Entities.Team", b =>
                {
                    b.HasOne("AirBallFantasyLeague.Model.Entities.League", "League")
                        .WithMany()
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AirBallFantasyLeague.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
