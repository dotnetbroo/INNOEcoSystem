using INNOEcoSystem.Domain.Entities.Assets;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Assets;

public class LocationsAssetSeedData
{
    public static void LocationAssetData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationAsset>()
            .HasData(
                new LocationAsset { Name = "Building Blueprint", Path = "assets/building1.pdf", Extension = ".pdf", Size = 543210, Type = "Document", LacationId = 1 },
                new LocationAsset { Name = "Site Map", Path = "assets/sitemap.jpg", Extension = ".jpg", Size = 234567, Type = "Image", LacationId = 2 },
                new LocationAsset { Name = "Construction Photos", Path = "assets/construction-photos.zip", Extension = ".zip", Size = 1234567, Type = "Archive", LacationId = 3 },
                new LocationAsset { Name = "Safety Guidelines", Path = "assets/safety-guidelines.docx", Extension = ".docx", Size = 345678, Type = "Document", LacationId = 1 },
                new LocationAsset { Name = "Marketing Brochure", Path = "assets/brochure.pdf", Extension = ".pdf", Size = 456789, Type = "Document", LacationId = 2 },
                new LocationAsset { Name = "Video Tour", Path = "assets/video-tour.mp4", Extension = ".mp4", Size = 987654, Type = "Video", LacationId = 3 },
                new LocationAsset { Name = "Maintenance Records", Path = "assets/maintenance.xlsx", Extension = ".xlsx", Size = 654321, Type = "Spreadsheet", LacationId = 1 },
                new LocationAsset { Name = "Floor Plans", Path = "assets/floor-plans.dwg", Extension = ".dwg", Size = 765432, Type = "CAD Drawing", LacationId = 2 },
                new LocationAsset { Name = "3D Model", Path = "assets/model.obj", Extension = ".obj", Size = 876543, Type = "3D Model", LacationId = 3 },
                new LocationAsset { Name = "Virtual Tour", Path = "assets/virtual-tour.html", Extension = ".html", Size = 123456, Type = "Web Page", LacationId = 1 }
            );
    }
}
