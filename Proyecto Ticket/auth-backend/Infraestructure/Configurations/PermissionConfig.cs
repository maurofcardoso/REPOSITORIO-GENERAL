using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class PermissionConfig: IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(p => p.PermissionId);
            builder.Property(p => p.PermissionId).ValueGeneratedOnAdd();
            builder.Property(p => p.Title).HasMaxLength(25);
            builder.Property(p => p.Description).HasMaxLength(100);

            builder.HasData(
                new Permission { PermissionId = 1, Title = "ABM Usuarios", Description="Permiso que otorga la posibilidad de agregar, modificar y/o eliminar usuarios"},               
                new Permission { PermissionId = 2, Title = "AM Tickets", Description = "Permiso que otorga la posibilidad de crear y/o editar tickets" },
                new Permission { PermissionId = 3, Title = "Resolucion Tickets", Description = "Permiso que otorga la posibilidad de tomar, resolver y/o derivar tickets" },
                new Permission { PermissionId = 4, Title = "ABM Areas", Description = "Permiso que otorga la posibilidad de realizar un ABM de las areas del sistema" },
                new Permission { PermissionId = 5, Title = "ABM TicketCategory", Description = "Permiso que otorga la posibilidad de realizar un ABM de TicketCategory" }
            );
        }
    }
}
