using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ProductLine : BaseEntityString
{

    public string DescriptionText { get; set; }

    public string DescriptionHtml { get; set; }

    public string Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
