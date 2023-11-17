using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class JardineriaContext : DbContext
{
    public JardineriaContext()
    {
    }

    public JardineriaContext(DbContextOptions<JardineriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boss> Bosses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationOffice> LocationOffices { get; set; }

    public virtual DbSet<Office> Offices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductLine> ProductLines { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TypeContact> TypeContacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1108;database=Jardin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Boss>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("boss");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cellphone).HasColumnName("cellphone");
            entity.Property(e => e.DentificationArd).HasColumnName("dentification_ard");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.IdStateFk, "Fk_IdState");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdStateFkNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdStateFk)
                .HasConstraintName("Fk_IdState");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientCode).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.IdContactFk, "FK_Contact");

            entity.HasIndex(e => e.IdEmployeeFk, "FK_Employee_FK");

            entity.HasIndex(e => e.IdOfficeFk, "FK_Office_FK");

            entity.Property(e => e.ClientCode)
                .ValueGeneratedNever()
                .HasColumnName("client_code");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .HasColumnName("client_name");
            entity.Property(e => e.CreditLimit)
                .HasPrecision(15, 2)
                .HasColumnName("credit_limit");
            entity.Property(e => e.IdContactFk).HasColumnName("IdContactFK");
            entity.Property(e => e.IdEmployeeFk).HasColumnName("IdEmployeeFK");
            entity.Property(e => e.IdOfficeFk)
                .HasMaxLength(10)
                .HasColumnName("IdOfficeFK");

            entity.HasOne(d => d.IdContactFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdContactFk)
                .HasConstraintName("FK_Contact");

            entity.HasOne(d => d.IdEmployeeFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdEmployeeFk)
                .HasConstraintName("FK_Employee_FK");

            entity.HasOne(d => d.IdOfficeFkNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdOfficeFk)
                .HasConstraintName("FK_Office_FK");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ContactLastName)
                .HasMaxLength(30)
                .HasColumnName("contact_last_name");
            entity.Property(e => e.ContactName)
                .HasMaxLength(30)
                .HasColumnName("contact_name");
            entity.Property(e => e.ContactNumbrer)
                .HasMaxLength(15)
                .HasColumnName("contact_numbrer");
            entity.Property(e => e.Fax)
                .HasMaxLength(15)
                .HasColumnName("fax");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeCode).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.IdBossFk, "Fk_IdBossFk");

            entity.HasIndex(e => e.OfficeCode, "Fk_OfficeCodeFk");

            entity.Property(e => e.EmployeeCode)
                .ValueGeneratedNever()
                .HasColumnName("employee_code");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Extension)
                .HasMaxLength(10)
                .HasColumnName("extension");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName1)
                .HasMaxLength(50)
                .HasColumnName("last_name1");
            entity.Property(e => e.LastName2)
                .HasMaxLength(50)
                .HasColumnName("last_name2");
            entity.Property(e => e.OfficeCode)
                .HasMaxLength(10)
                .HasColumnName("office_code");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .HasColumnName("position");

            entity.HasOne(d => d.IdBossFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdBossFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_IdBossFk");

            entity.HasOne(d => d.OfficeCodeNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.OfficeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_OfficeCodeFk");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("location");

            entity.HasIndex(e => e.IdClientFk, "Fk1_idClientFk");

            entity.HasIndex(e => e.IdCityFk, "Fk2_idCityFk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bis)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bis");
            entity.Property(e => e.Cardinal)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinal");
            entity.Property(e => e.CardinalSec)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinalSec");
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            entity.Property(e => e.IdCityFk).HasColumnName("idCityFk");
            entity.Property(e => e.IdClientFk).HasColumnName("idClientFk");
            entity.Property(e => e.Letra)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letra");
            entity.Property(e => e.Letrasec)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrasec");
            entity.Property(e => e.Letrater)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrater");
            entity.Property(e => e.NumeroPri).HasColumnName("numeroPri");
            entity.Property(e => e.NumeroSec).HasColumnName("numeroSec");
            entity.Property(e => e.NumeroTer).HasColumnName("numeroTer");
            entity.Property(e => e.PostCode).HasMaxLength(10);
            entity.Property(e => e.TipoDeVia)
                .HasMaxLength(50)
                .HasColumnName("tipoDeVia");

            entity.HasOne(d => d.IdCityFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.IdCityFk)
                .HasConstraintName("Fk2_idCityFk");

            entity.HasOne(d => d.IdClientFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.IdClientFk)
                .HasConstraintName("Fk1_idClientFk");
        });

        modelBuilder.Entity<LocationOffice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("location_office");

            entity.HasIndex(e => e.IdCityFk, "Fk_idCityFk");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Bis)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("bis");
            entity.Property(e => e.Cardinal)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinal");
            entity.Property(e => e.CardinalSec)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cardinalSec");
            entity.Property(e => e.Complemento)
                .HasMaxLength(50)
                .HasColumnName("complemento");
            entity.Property(e => e.IdCityFk).HasColumnName("idCityFk");
            entity.Property(e => e.Letra)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letra");
            entity.Property(e => e.Letrasec)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrasec");
            entity.Property(e => e.Letrater)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("letrater");
            entity.Property(e => e.NumeroPri).HasColumnName("numeroPri");
            entity.Property(e => e.NumeroSec).HasColumnName("numeroSec");
            entity.Property(e => e.NumeroTer).HasColumnName("numeroTer");
            entity.Property(e => e.PostCode).HasMaxLength(10);
            entity.Property(e => e.TipoDeVia)
                .HasMaxLength(50)
                .HasColumnName("tipoDeVia");

            entity.HasOne(d => d.IdCityFkNavigation).WithMany(p => p.LocationOffices)
                .HasForeignKey(d => d.IdCityFk)
                .HasConstraintName("Fk_idCityFk");
        });

        modelBuilder.Entity<Office>(entity =>
        {
            entity.HasKey(e => e.OfficeCode).HasName("PRIMARY");

            entity.ToTable("office");

            entity.HasIndex(e => e.LocationOfficeId, "fk_office_location_office1_idx");

            entity.Property(e => e.OfficeCode)
                .HasMaxLength(10)
                .HasColumnName("office_code");
            entity.Property(e => e.LocationOfficeId).HasColumnName("location_office_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postal_code");

            entity.HasOne(d => d.LocationOffice).WithMany(p => p.Offices)
                .HasForeignKey(d => d.LocationOfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_office_location_office1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderCode).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.ClientCode, "Fk_client_code");

            entity.Property(e => e.OrderCode)
                .ValueGeneratedNever()
                .HasColumnName("order_code");
            entity.Property(e => e.ClientCode).HasColumnName("client_code");
            entity.Property(e => e.Comments)
                .HasColumnType("text")
                .HasColumnName("comments");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.ExpectedDate).HasColumnName("expected_date");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasColumnName("status");

            entity.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_client_code");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderCode, e.ProductCode })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("order_detail");

            entity.HasIndex(e => e.ProductCode, "Fk2_product_code");

            entity.Property(e => e.OrderCode).HasColumnName("order_code");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(15)
                .HasColumnName("product_code");
            entity.Property(e => e.LineNumber).HasColumnName("line_number");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(15, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.OrderCodeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk1_order_code");

            entity.HasOne(d => d.ProductCodeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk2_product_code");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.HasIndex(e => e.ClientCode, "Fk_cliente_code");

            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("transaction_id");
            entity.Property(e => e.ClientCode).HasColumnName("client_code");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(40)
                .HasColumnName("payment_method");
            entity.Property(e => e.Total)
                .HasPrecision(15, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.ClientCodeNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ClientCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_cliente_code");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductCode).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdProveedorFk, "Fk_IdProveedorFk");

            entity.HasIndex(e => e.ProductLine, "Fk_product_line");

            entity.Property(e => e.ProductCode)
                .HasMaxLength(15)
                .HasColumnName("product_code");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Dimensions)
                .HasMaxLength(25)
                .HasColumnName("dimensions");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.ProductLine)
                .HasMaxLength(50)
                .HasColumnName("product_line");
            entity.Property(e => e.SellingPrice)
                .HasPrecision(15, 2)
                .HasColumnName("selling_price");
            entity.Property(e => e.StockQuantity).HasColumnName("stock_quantity");
            entity.Property(e => e.Supplier)
                .HasMaxLength(50)
                .HasColumnName("supplier");
            entity.Property(e => e.SupplierPrice)
                .HasPrecision(15, 2)
                .HasColumnName("supplier_price");

            entity.HasOne(d => d.IdProveedorFkNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProveedorFk)
                .HasConstraintName("Fk_IdProveedorFk");

            entity.HasOne(d => d.ProductLineNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductLine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_product_line");
        });

        modelBuilder.Entity<ProductLine>(entity =>
        {
            entity.HasKey(e => e.ProductLine1).HasName("PRIMARY");

            entity.ToTable("product_line");

            entity.Property(e => e.ProductLine1)
                .HasMaxLength(50)
                .HasColumnName("product_line");
            entity.Property(e => e.DescriptionHtml)
                .HasColumnType("text")
                .HasColumnName("description_html");
            entity.Property(e => e.DescriptionText)
                .HasColumnType("text")
                .HasColumnName("description_text");
            entity.Property(e => e.Image)
                .HasMaxLength(256)
                .HasColumnName("image");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cellphone).HasColumnName("cellphone");
            entity.Property(e => e.DentificationArd).HasColumnName("dentification_ard");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("state");

            entity.HasIndex(e => e.IdCountryFk, "Fk_IdCountry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCountryFkNavigation).WithMany(p => p.States)
                .HasForeignKey(d => d.IdCountryFk)
                .HasConstraintName("Fk_IdCountry");
        });

        modelBuilder.Entity<TypeContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("type_contact");

            entity.HasIndex(e => e.IdContactFk, "Fk_IdContactFk");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TypeContact1)
                .HasMaxLength(50)
                .HasColumnName("type_contact");

            entity.HasOne(d => d.IdContactFkNavigation).WithMany(p => p.TypeContacts)
                .HasForeignKey(d => d.IdContactFk)
                .HasConstraintName("Fk_IdContactFk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
