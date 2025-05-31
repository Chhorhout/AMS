using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AMS.Api.Models;

namespace AMS.Api.Data.Configs
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.LocationId);
            builder.Property(l => l.LocationName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}