using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Managmentcompany
{
    public int ManagmentId { get; set; }

    public string? ManagmentName { get; set; }

    public string? Description { get; set; }

    public string? Logopath { get; set; }

    public string? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();

    public virtual ICollection<Seeker> Seekers { get; set; } = new List<Seeker>();
}
