using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Payment : BaseEntityString
{

    public string PaymentMethod { get; set; } = null!;

    public string TransactionId { get; set; } = null!;

    public DateOnly PaymentDate { get; set; }

    public decimal Total { get; set; }

    public int ClientCode { get; set; }

    public virtual Client ClientCodeNavigation { get; set; } = null!;
}
