using Application.Tools;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Persistence
{
    public class ProyectoAlkemyContext : DbContext
    {
        public ProyectoAlkemyContext (DbContextOptions options) : base (options)
        {
        }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MovieOrSerie> MoviesOrSeries { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterMovieOrSerie> CharactersMoviesOrSeries { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Characters");
                entity.HasKey(c => c.CharacterId);
                entity.Property(c => c.CharacterId)
                .ValueGeneratedOnAdd();
                entity.Property(n => n.Name).HasColumnType("nvarchar(50)");
                entity.Property(i => i.Image).HasColumnType("nvarchar(max)");
                entity.Property(a => a.Age).HasColumnType("int");
                entity.Property(h => h.History).HasColumnType("nvarchar(max)");
                entity.Property(w => w.Weight).HasColumnType("decimal (15, 2)").HasPrecision(15, 2);
                entity.HasData(new Character
                {
                    CharacterId = 1,
                    Name = "mauro",
                    Image = "https://i.imgur.com/ii8kB2g.jpg",
                    Age = 37,
                    History = "una historia",
                    Weight = 85.2,
                });
            });
            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Genders");
                entity.HasKey(g => g.GenderId);
                entity.Property(g => g.GenderId)
                .ValueGeneratedOnAdd();
                entity.HasMany(m => m.MoviesOrSeriesAssociated)
                .WithOne(g => g.Gender)
                .OnDelete(DeleteBehavior.Cascade);
                entity.Property(n => n.Name).HasColumnType("nvarchar(50)");
                entity.Property(i => i.Image).HasColumnType("nvarchar(max)");
                entity.HasData(new Gender
                {
                    GenderId = 1,
                    Name = "terror",
                    Image = "https://i.imgur.com/4M7bD2X.jpg",
                });
            });
            modelBuilder.Entity<MovieOrSerie>(entity =>
            {
                entity.ToTable("Movies or Series");
                entity.HasKey(m => m.MovieOrSerieId);
                entity.Property(m => m.MovieOrSerieId)
                .ValueGeneratedOnAdd();
                entity.Property(i => i.Image).HasColumnType("nvarchar(max)");
                entity.Property(t => t.Title).HasColumnType("nvarchar(50)");
                entity.Property(c=> c.CreationDate).HasColumnType("Date");
                entity.Property(q => q.Qualification).HasColumnType("int");
                entity.HasData(new MovieOrSerie
                {
                    MovieOrSerieId = 1,
                    GenderId = 1,
                    Image = "https://i.imgur.com/q4tQeeH.jpg",
                    Title = "algun titulo",
                    Qualification = 5,
                });
            });
            modelBuilder.Entity<CharacterMovieOrSerie>(entity =>
            {
                entity.ToTable("Characters Movies or Series");
                entity.HasKey(p => new { p.CharacterId, p.MovieOrSerieId });
                entity.HasOne(c =>c.Character)
                .WithMany(ps => ps.MoviesOrSeriesAssociated)
                .HasForeignKey(c => c.CharacterId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ps => ps.MovieOrSerie)
                .WithMany(p => p.CharacterAssociated)
                .HasForeignKey(ps => ps.MovieOrSerieId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasData(new CharacterMovieOrSerie
                {
                    CharacterId = 1,
                    MovieOrSerieId = 1,
                });
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserId)
                .ValueGeneratedOnAdd();
                entity.Property(e => e.Email).HasColumnType("nvarchar(50)");
                entity.Property(p => p.Password).HasColumnType("nvarchar(max)");
                entity.Property(n => n.Name).HasColumnType("nvarchar(50)");
                entity.Property(l => l.LastName).HasColumnType("nvarchar(50)");
                entity.HasData(new User
                {
                    UserId = 1,
                    Email = "mauro@mauro.com",
                    Password = Encript.GetSHA256("mauro1234"),
                    Name = "Mauro",
                    LastName = "Cardoso"
                });
            });
        }
    }
}
