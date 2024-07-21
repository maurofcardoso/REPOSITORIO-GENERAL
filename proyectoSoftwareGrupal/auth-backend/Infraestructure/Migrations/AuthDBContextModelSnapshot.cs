﻿// <auto-generated />
using System;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(AuthDBContext))]
    partial class AuthDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PermissionId");

                    b.ToTable("Permission", (string)null);

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            Description = "Permiso que otorga la posibilidad de agregar, modificar y/o eliminar usuarios",
                            Title = "ABM Usuarios"
                        },
                        new
                        {
                            PermissionId = 2,
                            Description = "Permiso que otorga la posibilidad de crear y/o editar tickets",
                            Title = "AM Tickets"
                        },
                        new
                        {
                            PermissionId = 3,
                            Description = "Permiso que otorga la posibilidad de tomar, resolver y/o derivar tickets",
                            Title = "Resolucion Tickets"
                        },
                        new
                        {
                            PermissionId = 4,
                            Description = "Permiso que otorga la posibilidad de realizar un ABM de las areas del sistema",
                            Title = "ABM Areas"
                        },
                        new
                        {
                            PermissionId = 5,
                            Description = "Permiso que otorga la posibilidad de realizar un ABM de TicketCategory",
                            Title = "ABM TicketCategory"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("RolId");

                    b.ToTable("Rol", (string)null);

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            Description = "Perfil administrador del portal",
                            Title = "Administrador"
                        },
                        new
                        {
                            RolId = 2,
                            Description = "Perfil de Usuario, permite generar y editar tickets",
                            Title = "Usuario"
                        },
                        new
                        {
                            RolId = 3,
                            Description = "Perfil de Agente, permite tomar, derivar y/o resolver un ticket",
                            Title = "Agente"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RolPermission", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.HasKey("RolId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolPermission", (string)null);

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            PermissionId = 1
                        },
                        new
                        {
                            RolId = 1,
                            PermissionId = 2
                        },
                        new
                        {
                            RolId = 1,
                            PermissionId = 3
                        },
                        new
                        {
                            RolId = 1,
                            PermissionId = 4
                        },
                        new
                        {
                            RolId = 1,
                            PermissionId = 5
                        },
                        new
                        {
                            RolId = 2,
                            PermissionId = 2
                        },
                        new
                        {
                            RolId = 3,
                            PermissionId = 3
                        },
                        new
                        {
                            RolId = 3,
                            PermissionId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<bool>("ActiveUser")
                        .HasColumnType("bit");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<int>("CreateUser")
                        .HasColumnType("int");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("UpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RolId");

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ActiveUser = true,
                            AreaId = 1,
                            CreateUser = 0,
                            DNI = "11845121",
                            DateCreate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "psgrupointer@gmail.com",
                            FirstName = "Cosme",
                            LastName = "Fulanito",
                            Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=",
                            Phone = "1561990876",
                            RolId = 1,
                            UpdateUser = 0,
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            ActiveUser = true,
                            AreaId = 2,
                            CreateUser = 0,
                            DNI = "33678345",
                            DateCreate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "juanperez@gmail.com",
                            FirstName = "Juan",
                            LastName = "Perez",
                            Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=",
                            Phone = "1168374456",
                            RolId = 2,
                            UpdateUser = 0,
                            UserName = "juanperez"
                        },
                        new
                        {
                            UserId = 3,
                            ActiveUser = true,
                            AreaId = 2,
                            CreateUser = 0,
                            DNI = "23876498",
                            DateCreate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "francogomez@gmail.com",
                            FirstName = "Franco",
                            LastName = "Gomez",
                            Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=",
                            Phone = "1168374456",
                            RolId = 3,
                            UpdateUser = 0,
                            UserName = "francogomez"
                        },
                        new
                        {
                            UserId = 4,
                            ActiveUser = true,
                            AreaId = 3,
                            CreateUser = 0,
                            DNI = "29358567",
                            DateCreate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "angelsola@gmail.com",
                            FirstName = "Angel",
                            LastName = "Sosa",
                            Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=",
                            Phone = "1168374456",
                            RolId = 2,
                            UpdateUser = 0,
                            UserName = "angelsosa"
                        },
                        new
                        {
                            UserId = 5,
                            ActiveUser = true,
                            AreaId = 3,
                            CreateUser = 0,
                            DNI = "39345567",
                            DateCreate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "candelagabriele@outlook.com",
                            FirstName = "Candela",
                            LastName = "Gabriele",
                            Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=",
                            Phone = "1168374456",
                            RolId = 3,
                            UpdateUser = 0,
                            UserName = "candelagabriele"
                        });
                });

            modelBuilder.Entity("Domain.Entities.RolPermission", b =>
                {
                    b.HasOne("Domain.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolPermissions")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("Users")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolPermissions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
