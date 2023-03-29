using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auto.Models
{
    public static class AutoContextSeed
    {
        public static async Task SeedAsync(AutoContext context)
        {
            try
            {
                context.Database.EnsureCreated();
                if (context.InsuranceType.Any())
                {
                    return;
                }

                var insuranceType = new InsuranceType[]
                {
                    new InsuranceType{
                        Name="КАСКО",
                    },
                    new InsuranceType{
                        Name="ОСАГО",
                    },


                };

                foreach (InsuranceType b in insuranceType)
                {
                    context.InsuranceType.Add(b);
                }

                await context.SaveChangesAsync();


                var insurance = new Insurance[]
                {
                    new Insurance {
                        Id =1,
                        StartDate= new DateTime(2022,2,2),
                        FinishDate= new DateTime(2023,2,2),
                        Policy = "1212",
                        Price = 0,
                        DrivingExperience = "111",
                        FIO ="Лизова Лиза Лизовна",
                        OwnerPassport="121212",
                        OwnerSertificate="212121",
                       AutoId = 1,
                       TypeId=1
                    }
                };
                foreach (Insurance b in insurance)
                {
                    context.Insurance.Add(b);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}