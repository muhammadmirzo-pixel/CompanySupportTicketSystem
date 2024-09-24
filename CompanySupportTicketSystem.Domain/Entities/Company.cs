using CompanySupportTicketSystem.Domain.Common;

namespace CompanySupportTicketSystem.Domain.Entities;

public class Company : Auditable
{
    public string CompanyName { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
}
