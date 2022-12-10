using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyPregnancyTracker.Data.Models;

namespace MyPregnancyTracker.Data.Configuration
{
    internal class ApplicationRolesConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                new ApplicationRole
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationRole
                {
                    Id = 2,
                    Name = "user",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
