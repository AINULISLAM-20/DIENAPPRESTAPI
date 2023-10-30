using System;
using System.Collections.Generic;

namespace DIENAPPRESTAPI.Models;

public partial class Seeker
{
    public int Skeerid { get; set; }

    public int? OptId { get; set; }

    public int? ManagmentId { get; set; }

    public string? Skeername { get; set; }

    public string? LatValue { get; set; }

    public string? LongValue { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public ulong? IsOtpverified { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual ICollection<Jobrequest> Jobrequests { get; set; } = new List<Jobrequest>();

    public virtual Managmentcompany? Managment { get; set; }

    public virtual Requestotp? Opt { get; set; }
}
