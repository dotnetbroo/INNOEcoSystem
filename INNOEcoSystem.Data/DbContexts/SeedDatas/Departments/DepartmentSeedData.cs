using INNOEcoSystem.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;

namespace INNOEcoSystem.Data.DbContexts.SeedDatas.Departments;

public class DepartmentSeedData
{
    public static void DepartmentData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasData(
                new Department { Name = "IT Innovation Lab", Email = "it@innoecosystem.com", Logo = "it-logo.png", Website = "www.innoecosystem.com/it", License = "IT-12345", Description = "Developing cutting-edge IT solutions", PhoneNumber = "123-456-7890", CallCenterNumer = "987-654-3210", LocationId = 1, CategoryId = 1 },
                new Department { Name = "Healthcare Innovation Center", Email = "healthcare@innoecosystem.com", Logo = "healthcare-logo.jpg", Website = "www.innoecosystem.com/healthcare", License = "HC-54321", Description = "Advancing healthcare through innovation", PhoneNumber = "456-789-0123", CallCenterNumer = "123-456-7890", LocationId = 2, CategoryId = 2 },
                new Department { Name = "Environmental Solutions Department", Email = "environment@innoecosystem.com", Logo = "environment-logo.png", Website = "www.innoecosystem.com/environment", License = "ENV-98765", Description = "Tackling environmental challenges through innovation", PhoneNumber = "789-0123-4567", CallCenterNumer = "456-789-0123", LocationId = 3, CategoryId = 4 },
                new Department { Name = "Agricultural Innovation Hub", Email = "agriculture@innoecosystem.com", Logo = "agriculture-logo.jpg", Website = "www.innoecosystem.com/agriculture", License = "AG-65432", Description = "Transforming agriculture with innovative technologies", PhoneNumber = "0123-456-7890", CallCenterNumer = "789-0123-4567", LocationId = 1, CategoryId = 5 },
                new Department { Name = "Renewable Energy Research Center", Email = "energy@innoecosystem.com", Logo = "energy-logo.png", Website = "www.innoecosystem.com/energy", License = "RE-32145", Description = "Developing sustainable energy solutions", PhoneNumber = "123-456-7890", CallCenterNumer = "0123-456-7890", LocationId = 2, CategoryId = 6 },
                new Department { Name = "Education Innovation Institute", Email = "education@innoecosystem.com", Logo = "education-logo.jpg", Website = "www.innoecosystem.com/education", License = "ED-98765", Description = "Transforming education through innovative approaches", PhoneNumber = "456-789-0123", CallCenterNumer = "123-456-7890", LocationId = 3, CategoryId = 3 },
                new Department { Name = "Manufacturing Excellence Center", Email = "manufacturing@innoecosystem.com", Logo = "manufacturing-logo.png", Website = "www.innoecosystem.com/manufacturing", License = "MFG-45678", Description = "Driving innovation in manufacturing processes", PhoneNumber = "789-0123-4567", CallCenterNumer = "456-789-0123", LocationId = 1, CategoryId = 7 },
                new Department { Name = "Financial Innovation Lab", Email = "finance@innoecosystem.com", Logo = "finance-logo.jpg", Website = "www.innoecosystem.com/finance", License = "FIN-13579", Description = "Developing innovative financial products and services", PhoneNumber = "0123-456-7890", CallCenterNumer = "789-0123-4567", LocationId = 2, CategoryId = 8},
                new Department { Name = "Retail Innovation Lab", Email = "retail@innoecosystem.com", Logo = "retail-logo.png", Website = "www.innoecosystem.com/retail", License = "RTL-24680", Description = "Reshaping the retail landscape through innovation", PhoneNumber = "123-456-7890", CallCenterNumer = "0123-456-7890", LocationId = 3, CategoryId = 9 },
                new Department { Name = "Transportation Innovation Center", Email = "transportation@innoecosystem.com", Logo = "transportation-logo.jpg", Website = "www.innoecosystem.com/transportation", License = "TRANS-15975", Description = "Transforming transportation systems through innovation", PhoneNumber = "456-789-0123", CallCenterNumer = "123-456-7890", LocationId = 1, CategoryId = 10 }
            );
    }
}

