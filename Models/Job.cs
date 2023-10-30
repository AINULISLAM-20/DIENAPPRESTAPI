using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Job
{
    public int Jobid { get; set; }

    public int? Jobcategoryid { get; set; }

    public int? SeekerId { get; set; }

    public int? ProviderId { get; set; }

    public string? Jobname { get; set; }

    public string? Descripion { get; set; }

    public string? LatValue { get; set; }

    public string? LongValue { get; set; }

    public string? Address { get; set; }

    public string? Remarks { get; set; }

    public string? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual Jobcategory? Jobcategory { get; set; }

    public virtual ICollection<Jobrequest> Jobrequests { get; set; } = new List<Jobrequest>();
}
