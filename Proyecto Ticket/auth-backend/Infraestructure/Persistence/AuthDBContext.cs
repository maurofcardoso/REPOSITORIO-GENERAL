using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infraestructure.Persistence
{
    public class AuthDBContext:DbContext
    {   public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolPermission> RolPermission { get; set; }

        public AuthDBContext(DbContextOptions<AuthDBContext> options) : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
