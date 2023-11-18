using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("city");

            builder.HasIndex(e => e.IdStateFk, "Fk_IdState");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            builder.HasOne(d => d.IdStateFkNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdStateFk)
                .HasConstraintName("Fk_IdState");
        }
    }
}