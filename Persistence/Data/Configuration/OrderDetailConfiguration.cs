using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(e => new { e.Id, e.ProductCode })
    .HasName("PRIMARY")
    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            builder.ToTable("order_detail");

            builder.HasIndex(e => e.ProductCode, "Fk2_product_code");

            builder.Property(e => e.Id).HasColumnName("order_code");
            builder.Property(e => e.ProductCode)
                .HasMaxLength(15)
                .HasColumnName("product_code");
            builder.Property(e => e.LineNumber).HasColumnName("line_number");
            builder.Property(e => e.Quantity).HasColumnName("quantity");
            builder.Property(e => e.UnitPrice)
                .HasPrecision(15, 2)
                .HasColumnName("unit_price");

            builder.HasOne(d => d.OrderCodeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk1_order_code");

            builder.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk2_product_code");
        }
    }
}