using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class Contact : BaseEntity
{

    public string ContactName { get; set; } = null!;

    public string ContactLastName { get; set; } = null!;

    public string ContactNumbrer { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
