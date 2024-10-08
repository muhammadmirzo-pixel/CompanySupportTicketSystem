﻿using CompanySupportTicketSystem.Domain.Enums;

namespace CompanySupportTicketSystem.Service.DTOs.Orders;

public class OrderForCreationDto 
{
    public string Seat { get; set; }
    public long UserId { get; set; }
    public long TicketId { get; set; }
    public EPaymentMethod PaymentMethod { get; set; }
}
