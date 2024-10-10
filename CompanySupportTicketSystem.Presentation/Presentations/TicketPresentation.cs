using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Services;

namespace CompanySupportTicketSystem.Presentation.Presentations;

public class TicketPresentation
{
    public static async Task Show()
    {
        TicketService ticketService = new TicketService();
        bool check = true;
        while (true)
        {
            try
            {
                Console.WriteLine("1 -> Create new ticket");
                Console.WriteLine("2 -> Update ticket");
                Console.WriteLine("3 -> Get by Id ");
                Console.WriteLine("4 -> Get All");
                Console.WriteLine("5 -> Delete ticket By Id");
                Console.WriteLine("6 -> Close");

                Console.Write("Enter your option -> ");
                int number = int.Parse(Console.ReadLine());
                Ticket ticket = new Ticket();
                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Enter the Description -> ");
                        ticket.Description = Console.ReadLine();

                        Console.Write("Enter the count ");
                        ticket.Count = long.Parse(Console.ReadLine());

                        Console.Write("Enter the Price -> ");
                        ticket.Price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter the Seat -> ");
                        ticket.Seat = Console.ReadLine();

                        Console.Write("Enter the Start time (e.g., 09/29/2024 14:30) -> ");
                        ticket.StartTime = DateTime.Parse(Console.ReadLine());

                        await ticketService.AddAsync(ticket);
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Enter the id of ticket -> ");
                        int ticketId = int.Parse(Console.ReadLine());
                        TicketForUpdateDto ticketUpd = new TicketForUpdateDto();

                        Console.Write("Enter the Description -> ");
                        ticketUpd.Description = Console.ReadLine();

                        Console.Write("Enter the Price -> ");
                        ticketUpd.Price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter the Seat -> ");
                        ticketUpd.Seat = Console.ReadLine();

                        Console.Write("Enter the Start time (e.g., 09/29/2024 14:30) -> ");
                        ticketUpd.StartTime = DateTime.Parse(Console.ReadLine());

                        await ticketService.UpdateAsync(ticketId, ticketUpd);
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Enter the ticket Id -> ");
                        int id = int.Parse(Console.ReadLine());
                        var ticketInfo = await ticketService.GetByIdAsync(id);

                        Console.WriteLine($"Description : {ticketInfo.Description}\n,Seat : {ticketInfo.Seat}\n, Price : {ticketInfo.Price}\n, Starttime : {ticketInfo.StartTime}\n");

                        break;
                    case 4:
                        Console.Clear();
                        var ticketInfos = await ticketService.GetAllAsync();
                        foreach(var ticketInf in ticketInfos) 
                        {
                            Console.WriteLine($"Description : {ticketInf.Description}\n,Seat : {ticketInf.Seat}\n, Price : {ticketInf.Price}\n, Starttime : {ticketInf.StartTime}\n");

                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Enter the user id -> ");
                        var ticketid = int.Parse(Console.ReadLine());

                        var deleteResponse = await ticketService.DeleteByIdAsync(ticketid);

                        if (deleteResponse)
                            Console.WriteLine("Successfully deleted!");
                        break;
                    case 6:

                        Console.Clear();
                        Console.WriteLine("Thank you)))");
                        check = false;
                        break;

                }


            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
