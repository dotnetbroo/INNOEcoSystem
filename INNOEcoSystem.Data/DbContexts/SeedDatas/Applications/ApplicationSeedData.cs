using INNOEcoSystem.Domain.Entities.Applications;
using INNOEcoSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Applications;

public static class ApplicationSeedData
{
    public static void ApplicationData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>()
            .HasData(
                new Application { Number = 1, DepartmentId = 1, UserId = 1, Description = "Innovation in healthcare", Presentation = "presentation1.pdf", Balans = 50000, Status = ApplicationStatus.Pending },
                new Application { Number = 2, DepartmentId = 2, UserId = 2, Description = "Sustainable agriculture solutions", Presentation = "presentation2.pptx", Balans = 25000, Status = ApplicationStatus.Process },
                new Application { Number = 3, DepartmentId = 3, UserId = 3, Description = "Renewable energy technologies", Presentation = "presentation3.docx", Balans = 75000, Status = ApplicationStatus.Rejected },
                new Application { Number = 4, DepartmentId = 1, UserId = 4, Description = "Education for underserved communities", Presentation = "presentation4.pdf", Balans = 40000, Status = ApplicationStatus.Process },
                new Application { Number = 5, DepartmentId = 2, UserId = 1, Description = "Water conservation initiatives", Presentation = "presentation5.pptx", Balans = 30000, Status = ApplicationStatus.Pending },
                new Application { Number = 6, DepartmentId = 3, UserId = 4, Description = "Waste management and recycling", Presentation = "presentation6.docx", Balans = 65000, Status = ApplicationStatus.Process },
                new Application { Number = 7, DepartmentId = 1, UserId = 2, Description = "Eco-friendly transportation", Presentation = "presentation7.pdf", Balans = 15000, Status = ApplicationStatus.Pending },
                new Application { Number = 8, DepartmentId = 2, UserId = 3, Description = "Green building and construction", Presentation = "presentation8.pptx", Balans = 80000, Status = ApplicationStatus.Process },
                new Application { Number = 9, DepartmentId = 3, UserId = 1, Description = "Biodiversity conservation", Presentation = "presentation9.docx", Balans = 35000, Status = ApplicationStatus.Accepted },
                new Application { Number = 10, DepartmentId = 1, UserId = 4, Description = "Climate change mitigation strategies", Presentation = "presentation10.pdf", Balans = 90000, Status = ApplicationStatus.Pending }
            );
    }
}
