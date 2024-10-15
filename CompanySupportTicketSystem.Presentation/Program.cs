using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.Services;
using CompanySupportTicketSystem.Service.Interfaces;
using CompanySupportTicketSystem.Service.DTOs.Orders;
using CompanySupportTicketSystem.Presentation.Presentations;

namespace CompanySupportTicketSystem.Presentation;


class Program
{
    static async Task Main(string[] args)
    {
        await UserPresentation.Show();  
        

    }
}

