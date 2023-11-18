using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Proveedor : BaseEntity
{

    public string Name { get; set; } = null!;

    public int DentificationArd { get; set; }

    public int Cellphone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
