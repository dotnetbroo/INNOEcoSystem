using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INNOEcoSystem.Data.Configuration;

public class SuperAdminConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = 6,
            FirstName = "Jasurbek",
            LastName = "Abdunazarov",
            PhoneNumber = "+998997920854",
            Email = "jasurbekabdunazarov043@gmail.com",
            Password = "$2a$11$BvEp/u9k3Rhb6NMxrcAKuOweHat7I1TG2kYSOqGh5VUA9/ul.r0qO",
            Salt = "cb0a8721-3744-4ae5-a0e7-7114a65ebce3",
            Role = UserRole.SuperAdmin,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            AddressId = 1,
            IsDeleted = false,
        });
    }
}
