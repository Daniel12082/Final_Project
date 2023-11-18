using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("office");

            builder.HasIndex(e => e.LocationOfficeFk, "fk_office_location_customer_copy11_idx");

            builder.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("office_code");
            builder.Property(e => e.LocationOfficeFk).HasColumnName("location_office_FK");
            builder.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");

            builder.HasOne(d => d.LocationOfficeFkNavigation).WithMany(p => p.Offices)
                .HasForeignKey(d => d.LocationOfficeFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_office_location_customer_copy11");
        }
    }
}