namespace DIENAPPRESTAPI.Models;

public partial class Jobpayment
{
    public int? JobpaymentId { get; set; }

    public int? Jobid { get; set; }

    public int? Sekkerid { get; set; }

    public string? Amount { get; set; }

    public string? Status { get; set; }

    public DateTime? Createddate { get; set; }

    public virtual Job? Job { get; set; }

    public virtual Seeker? Sekker { get; set; }
}
