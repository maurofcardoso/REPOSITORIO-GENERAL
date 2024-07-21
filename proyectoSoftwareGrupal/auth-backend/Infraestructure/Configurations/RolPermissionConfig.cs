using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class RolPermissionConfig: IEntityTypeConfiguration<RolPermission>
    {
        public void Configure(EntityTypeBuilder<RolPermission> builder)
        {
            builder.ToTable("RolPermission");
            builder.HasKey(p => new { p.RolId, p.PermissionId });

            builder.HasData(
                new RolPermission { RolId = 1, PermissionId = 1 },
                new RolPermission { RolId = 1, PermissionId = 2 },
                new RolPermission { RolId = 1, PermissionId = 3 },
                new RolPermission { RolId = 1, PermissionId = 4 },
                new RolPermission { RolId = 1, PermissionId = 5 },

                new RolPermission { RolId = 2, PermissionId = 2 },

                new RolPermission { RolId = 3, PermissionId = 3 },
                new RolPermission { RolId = 3, PermissionId = 2 }
            );
        }
    }
}
