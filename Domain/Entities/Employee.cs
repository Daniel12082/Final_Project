using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Employee
{
    public int EmployeeCode { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName1 { get; set; } = null!;

    public string? LastName2 { get; set; }

    public string Extension { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string OfficeCode { get; set; } = null!;

    public int IdBossFk { get; set; }

    public string? Position { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Boss IdBossFkNavigation { get; set; } = null!;

    public virtual Office OfficeCodeNavigation { get; set; } = null!;
}
