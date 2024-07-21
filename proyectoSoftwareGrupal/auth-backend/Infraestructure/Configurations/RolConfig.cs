using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class RolConfig: IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("Rol");
            builder.HasKey(p => p.RolId);
            builder.Property(p => p.RolId).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(25);
            builder.Property(p => p.Description).HasMaxLength(100);

            builder.HasData(
                new Rol { RolId = 1, Title = "Administrador", Description = "Perfil administrador del portal" },
                new Rol { RolId = 2, Title = "Usuario", Description = "Perfil de Usuario, permite generar y editar tickets" },
                new Rol { RolId = 3, Title = "Agente", Description = "Perfil de Agente, permite tomar, derivar y/o resolver un ticket" }
            );
        }
    }
}
