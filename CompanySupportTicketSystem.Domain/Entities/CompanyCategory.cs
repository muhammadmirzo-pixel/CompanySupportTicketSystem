using CompanySupportTicketSystem.Domain.Common;

namespace CompanySupportTicketSystem.Domain.Entities;
public class CompanyCategory : Auditable
{
    public string CategoryName { get; set; }
    public string Description {  get; set; }
    public bool IsActive {  get; set; }
}
