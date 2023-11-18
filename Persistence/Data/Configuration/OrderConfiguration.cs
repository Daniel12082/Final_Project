using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("orders");

            builder.HasIndex(e => e.ClientCode, "Fk_client_code");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("order_code");
            builder.Property(e => e.ClientCode).HasColumnName("client_code");
            builder.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");
            builder.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            builder.Property(e => e.ExpectedDate).HasColumnName("expected_date");
            builder.Property(e => e.OrderDate).HasColumnName("order_date");
            builder.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");

            builder.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_client_code");
        }
    }
}