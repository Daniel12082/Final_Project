using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contact
{
    public int Id { get; set; }

    public string ContactName { get; set; } = null!;

    public string ContactLastName { get; set; } = null!;

    public string ContactNumbrer { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<TypeContact> TypeContacts { get; set; } = new List<TypeContact>();
}
