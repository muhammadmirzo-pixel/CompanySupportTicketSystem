namespace CompanySupportTicketSystem.Service.DTOs.Tickets;

public class TicketForResultDto
{
    public string Seat { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
}
