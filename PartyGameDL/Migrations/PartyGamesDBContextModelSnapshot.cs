﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartyGameDL;

namespace PartyGameDL.Migrations
{
    [DbContext(typeof(PartyGamesDBContext))]
    partial class PartyGamesDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PartyGameModels.Blackjack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("WinLossRatio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Blackjacks");
                });

            modelBuilder.Entity("PartyGameModels.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("PartyGameModels.ScoreHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("UserId");

                    b.ToTable("ScoreHistories");
                });

            modelBuilder.Entity("PartyGameModels.Snake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AvgScore")
                        .HasColumnType("float");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<double>("HighScore")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Snakes");
                });

            modelBuilder.Entity("PartyGameModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PartyGameModels.Blackjack", b =>
                {
                    b.HasOne("PartyGameModels.Games", null)
                        .WithMany("Blackjacks")
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyGameModels.User", null)
                        .WithOne("BjStats")
                        .HasForeignKey("PartyGameModels.Blackjack", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyGameModels.ScoreHistory", b =>
                {
                    b.HasOne("PartyGameModels.Games", null)
                        .WithMany("GameScoreHistories")
                        .HasForeignKey("GamesId");

                    b.HasOne("PartyGameModels.User", null)
                        .WithMany("UserScoreHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyGameModels.Snake", b =>
                {
                    b.HasOne("PartyGameModels.Games", null)
                        .WithMany("Snakes")
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyGameModels.User", null)
                        .WithOne("SnakeStats")
                        .HasForeignKey("PartyGameModels.Snake", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyGameModels.Games", b =>
                {
                    b.Navigation("Blackjacks");

                    b.Navigation("GameScoreHistories");

                    b.Navigation("Snakes");
                });

            modelBuilder.Entity("PartyGameModels.User", b =>
                {
                    b.Navigation("BjStats");

                    b.Navigation("SnakeStats");

                    b.Navigation("UserScoreHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
