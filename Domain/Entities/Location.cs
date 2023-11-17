using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Location
{
    public int Id { get; set; }

    public string? TipoDeVia { get; set; }

    public short? NumeroPri { get; set; }

    public string? Letra { get; set; }

    public string? Bis { get; set; }

    public string? Letrasec { get; set; }

    public string? Cardinal { get; set; }

    public short? NumeroSec { get; set; }

    public string? Letrater { get; set; }

    public short? NumeroTer { get; set; }

    public string? CardinalSec { get; set; }

    public string? Complemento { get; set; }

    public int? IdClientFk { get; set; }

    public int? IdCityFk { get; set; }

    public string? PostCode { get; set; }

    public virtual City? IdCityFkNavigation { get; set; }

    public virtual Client? IdClientFkNavigation { get; set; }
}
