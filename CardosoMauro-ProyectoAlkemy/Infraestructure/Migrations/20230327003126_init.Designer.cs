﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(ProyectoAlkemyContext))]
    [Migration("20230327003126_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Weight")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal (15, 2)");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters", (string)null);

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            Age = 37,
                            History = "una historia",
                            Image = "https://i.imgur.com/ii8kB2g.jpg",
                            Name = "mauro",
                            Weight = 85.2m
                        });
                });

            modelBuilder.Entity("Domain.Entities.CharacterMovieOrSerie", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieOrSerieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieOrSerieId");

                    b.HasIndex("MovieOrSerieId");

                    b.ToTable("Characters Movies or Series", (string)null);

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieOrSerieId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenderId"));

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenderId");

                    b.ToTable("Genders", (string)null);

                    b.HasData(
                        new
                        {
                            GenderId = 1,
                            Image = "https://i.imgur.com/4M7bD2X.jpg",
                            Name = "terror"
                        });
                });

            modelBuilder.Entity("Domain.Entities.MovieOrSerie", b =>
                {
                    b.Property<int>("MovieOrSerieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieOrSerieId"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("Date");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MovieOrSerieId");

                    b.HasIndex("GenderId");

                    b.ToTable("Movies or Series", (string)null);

                    b.HasData(
                        new
                        {
                            MovieOrSerieId = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GenderId = 1,
                            Image = "https://i.imgur.com/q4tQeeH.jpg",
                            Qualification = 5,
                            Title = "algun titulo"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "mauro@mauro.com",
                            LastName = "Cardoso",
                            Name = "Mauro",
                            Password = "0cf9698501df07b21305bfded3a6b3660123095f1375b3ab32f739c0c37f0096"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CharacterMovieOrSerie", b =>
                {
                    b.HasOne("Domain.Entities.Character", "Character")
                        .WithMany("MoviesOrSeriesAssociated")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.MovieOrSerie", "MovieOrSerie")
                        .WithMany("CharacterAssociated")
                        .HasForeignKey("MovieOrSerieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("MovieOrSerie");
                });

            modelBuilder.Entity("Domain.Entities.MovieOrSerie", b =>
                {
                    b.HasOne("Domain.Entities.Gender", "Gender")
                        .WithMany("MoviesOrSeriesAssociated")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Domain.Entities.Character", b =>
                {
                    b.Navigation("MoviesOrSeriesAssociated");
                });

            modelBuilder.Entity("Domain.Entities.Gender", b =>
                {
                    b.Navigation("MoviesOrSeriesAssociated");
                });

            modelBuilder.Entity("Domain.Entities.MovieOrSerie", b =>
                {
                    b.Navigation("CharacterAssociated");
                });
#pragma warning restore 612, 618
        }
    }
}