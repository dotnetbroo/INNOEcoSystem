using INNOEcoSystem.Domain.Entities.Users;
using INNOEcoSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Users;

public class UsersSeedData
{
    public static void UserSeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(
                new User { FirstName = "Sardor", LastName = "Alimov", Email = "sardor.alimov@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998901234567", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.Admin, ProfilePicture = "sardor_alimov.jpg", AddressId = 1 },
                new User { FirstName = "Dilnoza", LastName = "Rahimova", Email = "dilnoza.rahimova@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998912345678", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "dilnoza_rahimova.jpg", AddressId = 2 },
                new User { FirstName = "Jasur", LastName = "Akhmedov", Email = "jasur.akhmedov@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998933456789", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "jasur_akhmedov.jpg", AddressId = 3 },
                new User { FirstName = "Nilufar", LastName = "Nazarova", Email = "nilufar.nazarova@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998944567890", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.Admin, ProfilePicture = "nilufar_nazarova.jpg", AddressId = 4 },
                new User { FirstName = "Umid", LastName = "Khasanov", Email = "umid.khasanov@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998955678901", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.Admin, ProfilePicture = "umid_khasanov.jpg", AddressId = 5 },
                new User { FirstName = "Zarina", LastName = "Yunusova", Email = "zarina.yunusova@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998977890123", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "zarina_yunusova.jpg", AddressId = 6 },
                new User { FirstName = "Bobur", LastName = "Mirzaev", Email = "bobur.mirzaev@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998998901234", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "bobur_mirzaev.jpg", AddressId = 7 },
                new User { FirstName = "Sevara", LastName = "Alieva", Email = "sevara.alieva@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998939012345", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "sevara_alieva.jpg", AddressId = 8 },
                new User { FirstName = "Doston", LastName = "Ermatov", Email = "doston.ermatov@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998925467832", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "doston_ermatov.jpg", AddressId = 9 },
                new User { FirstName = "Yulduz", LastName = "Karimova", Email = "yulduz.karimova@example.com", Password = BCrypt.Net.BCrypt.HashPassword("password", BCrypt.Net.BCrypt.GenerateSalt()), PhoneNumber = "+998954321678", Salt = BCrypt.Net.BCrypt.GenerateSalt(), Role = UserRole.User, ProfilePicture = "yulduz_karimova.jpg", AddressId = 10 }
            );
    }
}
