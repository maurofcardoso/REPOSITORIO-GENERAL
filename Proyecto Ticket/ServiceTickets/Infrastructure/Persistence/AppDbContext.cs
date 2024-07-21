using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketComment> TicketComment { get; set; }
        public DbSet<TicketLog> TicketLog { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<TicketPriority> TicketPriority { get; set; }
        public DbSet<TicketBody> TicketBody { get; set; }
        public DbSet<TicketCount> TicketCount { get; set; }
        public DbSet<TicketCategory> TicketCategory { get; set; }
        public DbSet<Area> Area { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Ticket");
                entity.HasKey(t => t.idTicket);
                entity.Property(t => t.idTicket).ValueGeneratedOnAdd();
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.idStatus).HasColumnName("idStatus");
                entity.Property(t => t.idPriority).HasColumnName("idPriority");
                entity.Property(t => t.idTicketCount).HasColumnName("idPTicketCount");
                entity.Property(t => t.idTicketCategory).HasColumnName("idTicketCategory");
                entity.Property(t => t.idTicketBody).HasColumnName("idTicketBody");

                entity
                    .HasOne<TicketStatus>(t => t.ticketStatus)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idStatus);

                entity
                    .HasOne<TicketPriority>(t => t.ticketPriority)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idPriority);

                entity
                    .HasOne<TicketCount>(t => t.ticketCount)
                    .WithOne(s => s.ticket)
                    .HasForeignKey<Ticket>(c => c.idTicketCount);

                entity
                    .HasOne<TicketCategory>(t => t.ticketCategory)
                    .WithMany(s => s.tickets)
                    .HasForeignKey(c => c.idTicketCategory);

                entity
                    .HasOne<TicketBody>(t => t.ticketBody)
                    .WithOne(s => s.ticket)
                    .HasForeignKey<Ticket>(t => t.idTicketBody);
            });


            modelBuilder.Entity<TicketComment>(entity =>
            {
                entity.ToTable("TicketComment");
                entity.HasKey(t => t.idComment);
                entity.Property(t => t.idComment).ValueGeneratedOnAdd();
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.comment).HasColumnName("comment");
                entity.Property(t => t.file).HasColumnName("file");
                entity.Property(t => t.dateComment).HasColumnName("dateComment");

                entity
                    .HasOne<Ticket>(t => t.ticket)
                    .WithMany(s => s.ticketComments)
                    .HasForeignKey(c => c.idTicket);
            });


            modelBuilder.Entity<TicketLog>(entity =>
            {
                entity.ToTable("TicketLog");
                entity.HasKey(t => t.idTicketLog);
                entity.Property(t => t.idTicketLog).ValueGeneratedOnAdd();
                entity.Property(t => t.idTicket).HasColumnName("idTicket");
                entity.Property(t => t.idUser).HasColumnName("idUser");
                entity.Property(t => t.dateAction).HasColumnName("dateAction");
                entity.Property(t => t.action).HasColumnName("action");

                entity
                    .HasOne<Ticket>(t => t.ticket)
                    .WithMany(s => s.ticketLogs)
                    .HasForeignKey(c => c.idTicket);
            });


            modelBuilder.Entity<TicketStatus>(entity =>
            {
                entity.ToTable("TicketStatus");
                entity.HasKey(t => t.idTicketStatus);
                entity.Property(t => t.idTicketStatus).ValueGeneratedOnAdd();
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new TicketStatus
                    {
                        idTicketStatus = 1,
                        description = "Pendiente"
                    },
                    new TicketStatus
                    {
                        idTicketStatus = 2,
                        description = "En curso"
                    },
                    new TicketStatus
                    {
                        idTicketStatus = 3,
                        description = "Finalizado"
                    });
            });


            modelBuilder.Entity<TicketPriority>(entity =>
            {
                entity.ToTable("TicketPriority");
                entity.HasKey(t => t.idPriority);
                entity.Property(t => t.idPriority).ValueGeneratedOnAdd();
                entity.Property(t => t.description).HasColumnName("description");

                entity.HasData(
                    new TicketPriority
                    {
                        idPriority = 1,
                        description = "Baja"
                    },
                    new TicketPriority
                    {
                        idPriority = 2,
                        description = "Media"
                    },
                    new TicketPriority
                    {
                        idPriority = 3,
                        description = "Alta"
                    });
        });

            

            modelBuilder.Entity<TicketBody>(entity =>
            {
                entity.ToTable("TicketBody");
                entity.HasKey(t => t.idTicketBody);
                entity.Property(t => t.idTicketBody).ValueGeneratedOnAdd();
                entity.Property(t => t.title).HasColumnName("title");
                entity.Property(t => t.description).HasColumnName("description");
                entity.Property(t => t.file).HasColumnName("file");
            });


            modelBuilder.Entity<TicketCount>(entity =>
            {
                entity.ToTable("TicketCount");
                entity.HasKey(t => t.idTicketCount);
                entity.Property(t => t.idTicketCount).ValueGeneratedOnAdd();
                entity.Property(t => t.countOpen).HasColumnName("countOpen");
                entity.Property(t => t.countApproved).HasColumnName("countApproved");
                entity.Property(t => t.countDisapproved).HasColumnName("countDisapproved");
            });


            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");
                entity.HasKey(a => a.idArea);
                entity.Property(a => a.idArea).ValueGeneratedOnAdd();
                entity.Property(a => a.activeArea).HasColumnName("activeArea");
                entity.Property(a => a.nameArea).HasColumnName("nameArea");
                entity.Property(a => a.description).HasColumnName("description");
                entity.Property(a => a.dateCreate).HasColumnName("dateCreate");
                entity.Property(a => a.createUser).HasColumnName("createUser");
                entity.Property(a => a.dateUpdate).HasColumnName("dateUpdate");
                entity.Property(a => a.updateUser).HasColumnName("updateUser");

                modelBuilder.Entity<Area>()
                    .HasMany<TicketCategory>(g => g.ticketCategories)
                    .WithOne(s => s.area)
                    .HasForeignKey(s => s.idAreadestino);

                entity.HasData(
                    new Area
                    {
                        idArea = 1,
                        activeArea = true,
                        nameArea = "Admin",
                        description = "Area encargada de la administracion total del sistema",
                        dateCreate = DateTime.Now,
                        createUser = 1,
                        dateUpdate = DateTime.Now,
                        updateUser = 1,
                    },
                    new Area
                    {
                        idArea = 2,
                        activeArea = true,
                        nameArea = "CompraVenta",
                        description = "Area encargada de registrar y ejecutar las compras/ventas de la organización",
                        dateCreate = DateTime.Now,
                        createUser = 1,
                        dateUpdate = DateTime.Now,
                        updateUser = 1,
                    },
                    new Area
                    {
                        idArea = 3,
                        activeArea = true,
                        nameArea = "Soporte",
                        description = "Area encargada del soporte tecnico de la organización",
                        dateCreate = DateTime.Now,
                        createUser = 1,
                        dateUpdate = DateTime.Now,
                        updateUser = 1,
                    });
                });


            modelBuilder.Entity<TicketCategory>(entity =>
            {
                entity.ToTable("TicketCategory");
                entity.HasKey(t => t.idTicketCategory);
                entity.Property(t => t.idTicketCategory).ValueGeneratedOnAdd();
                entity.Property(t => t.name).HasColumnName("name");
                entity.Property(t => t.description).HasColumnName("description");
                entity.Property(t => t.reqApproval).HasColumnName("reqApproval");
                entity.Property(t => t.minApprovers).HasColumnName("minApprovers");
                entity.Property(t => t.idAreadestino).HasColumnName("idAreadestino");
                entity.Property(t => t.active).HasColumnName("active");

                entity.HasData(
                    new TicketCategory
                    {
                        idTicketCategory = 1,
                        name = "Ventas",
                        description = "Categoria responsable de gestionar los tickets de ventas",
                        reqApproval = true,
                        minApprovers= 1,
                        idAreadestino= 2,
                        active= true
                    },
                    new TicketCategory
                    {
                        idTicketCategory = 2,
                        name = "Compras",
                        description = "Categoria responsable de gestionar los tickets de compras",
                        reqApproval = true,
                        minApprovers = 1,
                        idAreadestino = 2,
                        active = true
                    },
                    new TicketCategory
                    {
                        idTicketCategory = 3,
                        name = "Reparacion Hardware",
                        description = "Categoria responsable de gestionar las reparaciones de Hardware",
                        reqApproval = true,
                        minApprovers = 1,
                        idAreadestino = 3,
                        active = true
                    }
                    );
            });

        }
    }
}
