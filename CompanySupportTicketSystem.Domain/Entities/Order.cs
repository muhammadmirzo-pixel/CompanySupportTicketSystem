using CompanySupportTicketSystem.Domain.Enums;
using CompanySupportTicketSystem.Domain.Common;

namespace CompanySupportTicketSystem.Domain.Entities;

public class Order : Auditable
{
    public string Seat { get; set; }
    public bool Paid { get; set; }
    public long UserId { get; set; }
    public long TicketId { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }

}

