using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactConfiguartion : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contact");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            builder.Property(e => e.ContactLastName)
                .HasMaxLength(30)
                .HasColumnName("contact_last_name");
            builder.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasColumnName("contact_name");
            builder.Property(e => e.ContactNumbrer)
                .HasMaxLength(15)
                .HasColumnName("contact_numbrer");
            builder.Property(e => e.Fax)
                .HasMaxLength(15)
                .HasColumnName("fax");
        }
    }
}