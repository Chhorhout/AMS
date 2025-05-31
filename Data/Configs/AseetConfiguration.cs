using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AMS.Api.Models;

namespace AMS.Api.Data.Configs
{
    public class AssetConfig : IEntityTypeConfiguration<Assets>
    {
        public void Configure(EntityTypeBuilder<Assets> builder)
        {
            builder.HasKey(a => a.AssetId);
            builder.Property(a => a.AssetName).IsRequired().HasMaxLength(100);
            builder.Property(a => a.AssetSerialNumber).IsRequired().HasMaxLength(50);
            builder.Property(a => a.HaveWarranty).IsRequired();
            builder.Property(a => a.WarrantyStartDate).IsRequired(false);
            builder.Property(a => a.WarrantyEndDate).IsRequired(false);
            
        }
    }
}