﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MovieApp.Data;
using System;

namespace MovieApp.Data.Migrations
{
    [DbContext(typeof(MoviesContext))]
    [Migration("20180308092824_TomatoRating")]
    partial class TomatoRating
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieApp.Domain.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MovieApp.Domain.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieApp.Domain.MovieActor", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("MovieId");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieActor");
                });

            modelBuilder.Entity("MovieApp.Domain.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActorId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("MovieApp.Domain.TomatoRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AudienceScore");

                    b.Property<int>("MovieId");

                    b.Property<int>("TomatoMeter");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("TomatoRating");
                });

            modelBuilder.Entity("MovieApp.Domain.MovieActor", b =>
                {
                    b.HasOne("MovieApp.Domain.Actor", "Actor")
                        .WithMany("Movies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MovieApp.Domain.Movie", "Movie")
                        .WithMany("Actors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieApp.Domain.Quote", b =>
                {
                    b.HasOne("MovieApp.Domain.Actor", "TheActor")
                        .WithMany("Quotes")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MovieApp.Domain.TomatoRating", b =>
                {
                    b.HasOne("MovieApp.Domain.Movie", "Movie")
                        .WithOne("Tomato")
                        .HasForeignKey("MovieApp.Domain.TomatoRating", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
