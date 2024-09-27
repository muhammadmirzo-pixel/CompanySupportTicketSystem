namespace CompanySupportTicketSystem.Service.DTOs.Orders;

public class OrderForResultDto
{
    public long OrderId { get; set; }
    public string Seat { get; set; }
    public bool Paid { get; set; }
    public long UserId { get; set; }
    public long TicketId { get; set; }
    public DateTime CreatedAt { get; set; }
}