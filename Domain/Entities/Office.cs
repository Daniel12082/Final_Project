using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Office
{
    public string OfficeCode { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int LocationOfficeId { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual LocationOffice LocationOffice { get; set; } = null!;
}
