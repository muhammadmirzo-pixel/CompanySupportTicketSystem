using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.Interfaces;
using CompanySupportTicketSystem.Service.Services;

namespace CompanySupportTicketSystem.Presentation;


class Program
{
    static async Task Main(string[] args)
    {
        IOrderService orderService = new OrderService();

        var order = new CompanySupportTicketSystem.Service.DTOs.Orders.OrderForCreationDto
        {
            Seat = "45",
            TicketId = 1,
            UserId = 1,
            //Paid = true,
            PaymentMethod = Domain.Enums.EPaymentMethod.BankCard
        };
        await orderService.AddAsync(order);
        

    }
}
