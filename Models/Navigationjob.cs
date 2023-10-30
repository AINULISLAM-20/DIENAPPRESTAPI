using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Navigationjob
{
    public int? NavigationjobId { get; set; }

    public string? NavigationName { get; set; }

    public int? JobId { get; set; }

    public string? LatValue { get; set; }

    public string? LongValue { get; set; }

    public string? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual Job? Job { get; set; }
}
