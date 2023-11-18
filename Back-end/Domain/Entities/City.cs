using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{
    public string Name { get; set; }

    public int IdStateFk { get; set; }

    public virtual State IdStateFkNavigation { get; set; }

    public virtual ICollection<LocationClient> LocationClients { get; set; } = new List<LocationClient>();

    public virtual ICollection<LocationOffice> LocationOffices { get; set; } = new List<LocationOffice>();
}
