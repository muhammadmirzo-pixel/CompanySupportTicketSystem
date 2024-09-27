/*{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}*/

using System;
using System.IO;
using System.Threading.Tasks;
using CompanySupportTicketSystem.Service.Services;
using CompanySupportTicketSystem.Service.DTOs.Orders;

namespace CompanySupportTicketSystem.Presentation;

class Program
{
    static async Task Main(string[] args)
    {
        var orderService = new OrderService();
        var orderDto = new OrderForCreationDto
        {
            Seat = "1A",
            UserId = 123, // mavjud UserId
            TicketId = 456 // mavjud TicketId
        };

        // Order qo'shish
        bool result = await orderService.AddAsync(orderDto);

        // Order.json faylini tekshirish
        var filePath = "D:\\Imtihon\\Company Support Ticket System\\CompanySupportTicketSystem.Data\\DataBases\\Order.json"; // Faylning to'liq yo'lini kiriting
        if (File.Exists(filePath))
        {
            var jsonContent = await File.ReadAllTextAsync(filePath);
            Console.WriteLine("Faylning mazmuni:");
            Console.WriteLine(jsonContent);
        }
        else
        {
            Console.WriteLine("Order.json fayli topilmadi.");
        }


       
    }
}
