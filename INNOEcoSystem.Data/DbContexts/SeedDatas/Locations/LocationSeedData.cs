using INNOEcoSystem.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Locations;

public class LocationSeedData
{
    public static void LocationData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>()
            .HasData(
                new Location { LongiTude = 69.254854m, Latitude = 41.315467m, Address = "Innovation Center, Tashkent, Uzbekistan" }, // Corrected property names and added "m" suffix for decimal literals
                new Location { LongiTude = -122.419416m, Latitude = 37.774929m, Address = "Silicon Valley Office, San Francisco, USA" },
                new Location { LongiTude = 139.691706m, Latitude = 35.689506m, Address = "Tokyo Hub, Shinjuku, Japan" },
                new Location { LongiTude = 13.405076m, Latitude = 52.520007m, Address = "Berlin Office, Mitte, Germany" },
                new Location { LongiTude = -0.127555m, Latitude = 51.507351m, Address = "London Innovation Space, London, UK" },
                new Location { LongiTude = 2.352222m, Latitude = 48.856614m, Address = "Paris Research Center, Paris, France" },
                new Location { LongiTude = 127.062225m, Latitude = 37.515468m, Address = "Seoul Creative Lab, Gangnam, South Korea" },
                new Location { LongiTude = 116.407395m, Latitude = 39.904211m, Address = "Beijing Technology Park, Chaoyang, China" },
                new Location { LongiTude = 103.851959m, Latitude = 1.28967m, Address = "Singapore Innovation Hub, Marina Bay, Singapore" },
                new Location { LongiTude = 151.2093m, Latitude = -33.8688m, Address = "Sydney Research Center, Sydney, Australia" }
            );
    }
}
