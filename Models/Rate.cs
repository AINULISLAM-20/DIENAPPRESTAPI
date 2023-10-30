using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Rate
{
    public int Rateid { get; set; }

    public string? Ratename { get; set; }

    public int? Price { get; set; }

    public DateTime? Createdate { get; set; }

    public virtual ICollection<Jobrequest> Jobrequests { get; set; } = new List<Jobrequest>();
}
