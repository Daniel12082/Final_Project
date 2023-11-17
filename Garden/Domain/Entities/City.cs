using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdStateFk { get; set; }

    public virtual State? IdStateFkNavigation { get; set; }

    public virtual ICollection<LocationOffice> LocationOffices { get; set; } = new List<LocationOffice>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
