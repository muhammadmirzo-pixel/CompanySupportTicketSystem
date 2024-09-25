namespace CompanySupportTicketSystem.Service.DTOs.Tickets;

public class TicketForUpdateDto
{
    public string Seat { get; set; }
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
    public long UserId { get; set; }
    public bool Paid { get; set; }
}
