using CompanySupportTicketSystem.Service.DTOs.Companies;

namespace CompanySupportTicketSystem.Service.DTOs.Tickets;

public class TicketForResultDto
{
    public long Id { get; set; }
    public string Seat { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
    public CompanyForResultDto Company { get; set; }
    public long Count { get; set; }
}
