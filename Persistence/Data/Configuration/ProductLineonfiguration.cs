using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProductLineonfiguration : IEntityTypeConfiguration<ProductLine>
    {
        public void Configure(EntityTypeBuilder<ProductLine> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("product_line");

            builder.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("product_line");
            builder.Property(e => e.DescriptionHtml)
                .HasColumnType("text")
                .HasColumnName("description_html");
            builder.Property(e => e.DescriptionText)
                .HasColumnType("text")
                .HasColumnName("description_text");
            builder.Property(e => e.Image)
                .HasMaxLength(256)
                .HasColumnName("image");
        }
    }

}