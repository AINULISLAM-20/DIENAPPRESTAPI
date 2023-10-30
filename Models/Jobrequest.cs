using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Jobrequest
{
    public int Jobrequestid { get; set; }

    public int? Jobid { get; set; }

    public int? Seekerid { get; set; }

    public int? Rateid { get; set; }

    public string? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual Job? Job { get; set; }

    public virtual Rate? Rate { get; set; }

    public virtual Seeker? Seeker { get; set; }
}
