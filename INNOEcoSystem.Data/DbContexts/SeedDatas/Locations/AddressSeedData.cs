using INNOEcoSystem.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Locations;

public class AddressSeedData
{
    public static void AddressData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .HasData(
                new Address { Country = "Uzbekistan", Region = "Tashkent", District = "Yashnaobod" },
                new Address { Country = "United States", Region = "California", District = "San Francisco" },
                new Address { Country = "Japan", Region = "Tokyo", District = "Shinjuku" },
                new Address { Country = "Germany", Region = "Berlin", District = "Mitte" },
                new Address { Country = "United Kingdom", Region = "England", District = "London" },
                new Address { Country = "France", Region = "Île-de-France", District = "Paris" },
                new Address { Country = "South Korea", Region = "Seoul", District = "Gangnam" },
                new Address { Country = "China", Region = "Beijing", District = "Chaoyang" },
                new Address { Country = "Singapore", Region = "Central Singapore", District = "Marina Bay" },
                new Address { Country = "Australia", Region = "New South Wales", District = "Sydney" }
            );
    }
}
