using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Provideremployee
{
    public int Provideremployeeid { get; set; }

    public int? Providerid { get; set; }

    public string? Employeename { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Photopath { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual Provider? Provider { get; set; }
}
