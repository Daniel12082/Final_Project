using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderDetail : BaseEntity
{

    public string ProductCode { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public short LineNumber { get; set; }

    public virtual Order OrderCodeNavigation { get; set; } = null!;

    public virtual Product ProductCodeNavigation { get; set; } = null!;
}
