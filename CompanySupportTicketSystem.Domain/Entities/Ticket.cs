using CompanySupportTicketSystem.Domain.Common;

namespace CompanySupportTicketSystem.Domain.Entities;

public class Ticket : Auditable
{
    public string Seat { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    public long UserId { get; set; }
    public bool Paid { get; set; }
}
