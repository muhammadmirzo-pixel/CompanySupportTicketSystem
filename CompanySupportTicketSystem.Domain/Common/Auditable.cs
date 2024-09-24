namespace CompanySupportTicketSystem.Domain.Common;

public class Auditable
{
    public long Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
