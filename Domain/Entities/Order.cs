using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order
{
    public int OrderCode { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly ExpectedDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string Status { get; set; } = null!;

    public string Comments { get; set; } = null!;

    public int ClientCode { get; set; }

    public virtual Client ClientCodeNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
