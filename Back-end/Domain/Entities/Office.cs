using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Office : BaseEntityString
{

    public string Phone { get; set; } = null!;

    public int LocationOfficeFk { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual LocationOffice LocationOfficeFkNavigation { get; set; } = null!;
}
