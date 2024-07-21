using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Configurations
{
    public class UserConfig: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(user => user.UserId);
            builder.Property(user => user.UserId).ValueGeneratedOnAdd();
            builder.Property(p => p.FirstName).HasMaxLength(25);
            builder.Property(p => p.LastName).HasMaxLength(25);
            builder.Property(p => p.DNI).HasMaxLength(10);
            builder.Property(p => p.Phone).HasMaxLength(13);

            builder.HasData(
               new User { UserId = 1, DNI = "11845121", Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", FirstName = "Cosme", LastName = "Fulanito", ActiveUser = true, RolId = 1, AreaId = 1, Email = "psgrupointer@gmail.com", UserName = "admin", Phone ="1561990876" },

               new User { UserId = 2, DNI = "33678345", Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", FirstName = "Juan", LastName = "Perez", ActiveUser = true, RolId = 2, AreaId = 2, Email = "juanperez@gmail.com", UserName = "juanperez", Phone = "1168374456" },
               new User { UserId = 3, DNI = "23876498", Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", FirstName = "Franco", LastName = "Gomez", ActiveUser = true, RolId = 3, AreaId = 2, Email = "francogomez@gmail.com", UserName = "francogomez", Phone = "1168374456" },

               new User { UserId = 4, DNI = "29358567", Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", FirstName = "Angel", LastName = "Sosa", ActiveUser = true, RolId = 2, AreaId = 3, Email = "angelsola@gmail.com", UserName = "angelsosa", Phone = "1168374456" },
               new User { UserId = 5, DNI = "39345567", Password = "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", FirstName = "Candela", LastName = "Gabriele", ActiveUser = true, RolId = 3, AreaId = 3, Email = "candelagabriele@outlook.com", UserName = "candelagabriele", Phone = "1168374456" }

            );
        }
    }
}
