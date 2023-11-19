using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();
            builder.ToTable("User");
            builder.Property(e => e.email)
                .HasMaxLength(50)
                .HasColumnName("Email");
            builder.Property(e => e.PasswordHash)
                .HasMaxLength(50)
                .HasColumnName("Password");
        }
    }
}