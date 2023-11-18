using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Data.Configuration
{
    public class LocationOfficeConfiguration : IEntityTypeConfiguration<LocationOffice>
    {
        public void Configure(EntityTypeBuilder<LocationOffice> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("location_office");

            builder.HasIndex(e => e.IdCityFk, "Fk1_idCityFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Bis)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bis");
            builder.Property(e => e.Cardinal)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinal");
            builder.Property(e => e.CardinalSec)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinalSec");
            builder.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            builder.Property(e => e.IdCityFk).HasColumnName("idCityFk");
            builder.Property(e => e.Letra)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letra");
            builder.Property(e => e.Letrasec)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrasec");
            builder.Property(e => e.Letrater)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrater");
            builder.Property(e => e.NumeroPri).HasColumnName("numeroPri");
            builder.Property(e => e.NumeroSec).HasColumnName("numeroSec");
            builder.Property(e => e.NumeroTer).HasColumnName("numeroTer");
            builder.Property(e => e.PostCode).HasMaxLength(10);
            builder.Property(e => e.TipoDeVia)
                .HasMaxLength(50)
                .HasColumnName("tipoDeVia");

            builder.HasOne(d => d.IdCityFkNavigation).WithMany(p => p.LocationOffices)
                .HasForeignKey(d => d.IdCityFk)
                .HasConstraintName("Fk1_idCityFk");
        }
    }
}