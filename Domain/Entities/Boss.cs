using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Boss
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DentificationArd { get; set; }

    public int? Cellphone { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
