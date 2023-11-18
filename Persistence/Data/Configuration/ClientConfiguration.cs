using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("client");

            builder.HasIndex(e => e.IdContactFk, "FK_Contact");

            builder.HasIndex(e => e.IdEmployeeFk, "FK_Employee_FK");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("client_code");
            builder.Property(e => e.ClientName)
                .HasMaxLength(50)
                .HasColumnName("client_name");
            builder.Property(e => e.CreditLimit)
                .HasPrecision(15, 2)
                .HasColumnName("credit_limit");
            builder.Property(e => e.IdContactFk).HasColumnName("IdContactFK");
            builder.Property(e => e.IdEmployeeFk).HasColumnName("IdEmployeeFK");

            builder.HasOne(d => d.IdContactFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdContactFk)
                .HasConstraintName("FK_Contact");

            builder.HasOne(d => d.IdEmployeeFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdEmployeeFk)
                .HasConstraintName("FK_Employee_FK");

        }
    }
}