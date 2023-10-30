using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Providerdetail
{
    public int Providerdetailsid { get; set; }

    public int? Providerid { get; set; }

    public string? LatValue { get; set; }

    public string? LongValue { get; set; }

    public string? Ein { get; set; }

    public string? Insuranceinfo { get; set; }

    public string? Taxcertificate { get; set; }

    public string? W9 { get; set; }

    public string? Facebbok { get; set; }

    public string? Linkdin { get; set; }

    public string? Twitter { get; set; }

    public string? Instagram { get; set; }

    public int? Rateid { get; set; }

    public string? Referrals { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual Provider? Provider { get; set; }
}
