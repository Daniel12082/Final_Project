using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class State : BaseEntity
{
    public string Name { get; set; }

    public int IdCountryFk { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryFkNavigation { get; set; }
}
