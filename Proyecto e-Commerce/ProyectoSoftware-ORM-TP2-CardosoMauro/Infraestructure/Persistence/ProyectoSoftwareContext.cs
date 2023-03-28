using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ProyectoSoftwareContext : DbContext
    {
        public ProyectoSoftwareContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<CarritoProducto> CarritoProductos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(k => k.ClienteId);
                entity.Property(a => a.ClienteId)
                .ValueGeneratedOnAdd();
                entity.HasMany<Carrito>(c => c.ListCarritos)
                .WithOne(x => x.Cliente)
                .HasForeignKey(f => f.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.Property(d => d.DNI).HasColumnType("nvarchar(10)");
                entity.Property(n => n.Nombre).HasColumnType("nvarchar(25)");
                entity.Property(a => a.Apellido).HasColumnType("nvarchar(25)");
                entity.Property(d => d.Direccion).HasColumnType("nvarchar(max)");
                entity.Property(t => t.Telefono).HasColumnType("nvarchar(13)");
                entity.HasData(new Cliente
                {
                    ClienteId = 1,
                    DNI = "31282983",
                    Nombre = "Mauro",
                    Apellido = "Cardoso",
                    Direccion = "Calle 421",
                    Telefono = "1158594841",
                });
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carritos");
                entity.HasKey(k => k.CarritoId);
                entity.HasData(new Carrito
                {
                    CarritoId = Guid.NewGuid(),
                    Estado = true,
                    ClienteId = 1,
                });
            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.ToTable("Carrito / Producto");
                entity.HasKey(k => new { k.CarritoId, k.ProductoId })
                .HasName("ID");
                entity.HasOne(c => c.Carrito)
                .WithMany(cp => cp.ListCarritoProductos)
                .HasForeignKey(f => f.CarritoId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Producto)
                .WithMany(cp => cp.ListCarritoProductos)
                .HasForeignKey(f => f.ProductoId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(p => p.ProductoId);
                entity.Property(a => a.ProductoId).ValueGeneratedOnAdd();
                entity.Property(n => n.Nombre).HasColumnType("nvarchar(max)");
                entity.Property(d => d.Descripcion).HasColumnType("nvarchar(max)");
                entity.Property(m => m.Marca).HasColumnType("nvarchar(25)");
                entity.Property(c => c.Codigo).HasColumnType("nvarchar(25)");
                entity.Property(p => p.Precio).HasColumnType("decimal (15, 2)").HasPrecision(15, 2);
                entity.Property(i => i.Image).HasColumnType("nvarchar(max)");
                entity.HasData(new Producto
                {
                    ProductoId = 1,
                    Nombre = "Bronceador",
                    Descripcion = "Cuidado Corporal",
                    Marca = "Nivea",
                    Codigo = "Cod 1",
                    Precio = 1693,
                    Image = "https://i.imgur.com/ii8kB2g.jpg",
                }, new Producto
                {
                    ProductoId = 2,
                    Nombre = "Champagne",
                    Descripcion = "Espumante",
                    Marca = "Nieto Senetiner",
                    Codigo = "cod 2",
                    Precio = 1940,
                    Image = "https://i.imgur.com/4M7bD2X.jpg",
                }, new Producto
                {
                    ProductoId = 3,
                    Nombre = "Mermelada",
                    Descripcion = "Ciruela",
                    Marca = "Emeth",
                    Codigo = "cod 3",
                    Precio = 231,
                    Image = "https://i.imgur.com/q4tQeeH.jpg",
                }, new Producto
                {
                    ProductoId = 4,
                    Nombre = "Agua",
                    Descripcion = "Mineral",
                    Marca = "King",
                    Codigo = "Cod 4",
                    Precio = 160,
                    Image = "https://i.imgur.com/Jdz22SZ.jpg",
                }, new Producto
                {
                    ProductoId = 5,
                    Nombre = "Azucar",
                    Descripcion = "Organica",
                    Marca = "Chango",
                    Codigo = "Cod 5",
                    Precio = 429,
                    Image = "https://i.imgur.com/nE1TQaW.jpg",
                }, new Producto
                {
                    ProductoId = 6,
                    Nombre = "Pañuelos",
                    Descripcion = "Descartables",
                    Marca = "Elite",
                    Codigo = "Cod 6",
                    Precio = 178,
                    Image = "https://i.imgur.com/NwWXjUW.jpg",
                }, new Producto
                {
                    ProductoId = 7,
                    Nombre = "Medallon",
                    Descripcion = "Pollo",
                    Marca = "Well",
                    Codigo = "Cod 7",
                    Precio = 119,
                    Image = "https://i.imgur.com/wbIl0jU.jpg",
                }, new Producto
                {
                    ProductoId = 8,
                    Nombre = "Secador",
                    Descripcion = "Goma",
                    Marca = "Dia",
                    Codigo = "Cod 8",
                    Precio = 425,
                    Image = "https://i.imgur.com/zgOx8TG.jpg",
                }, new Producto
                {
                    ProductoId = 9,
                    Nombre = "Galletitas",
                    Descripcion = "Rellenas",
                    Marca = "Frutigram",
                    Codigo = "Cod 9",
                    Precio = 165,
                    Image = "https://i.imgur.com/KJAyrFa.jpg",
                }, new Producto
                {
                    ProductoId = 10,
                    Nombre = "Cafe",
                    Descripcion = "Tostado",
                    Marca = "Martinez",
                    Codigo = "Cod 10",
                    Precio = 1391,
                    Image = "https://i.imgur.com/RYgyvxE.jpg",
                });
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Ordenes");
                entity.HasKey(p => p.OrdenId);
                entity.Property(p => p.Total).HasColumnType("decimal (15, 2)").HasPrecision(15, 2);
                entity.HasOne(c => c.Carrito)
                .WithOne(x => x.Orden)
                .HasForeignKey<Orden>(f => f.CarritoId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
