using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product
{
    public string ProductCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string ProductLine { get; set; } = null!;

    public string? Dimensions { get; set; }

    public string? Supplier { get; set; }

    public string? Description { get; set; }

    public short StockQuantity { get; set; }

    public decimal SellingPrice { get; set; }

    public decimal? SupplierPrice { get; set; }

    public int? IdProveedorFk { get; set; }

    public virtual Proveedor? IdProveedorFkNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductLine ProductLineNavigation { get; set; } = null!;
}
