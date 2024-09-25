using CompanySupportTicketSystem.Domain.Common;

namespace CompanySupportTicketSystem.Domain.Entities;

public class Ticket : Auditable
{
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    public long Count { get; set; }
}
