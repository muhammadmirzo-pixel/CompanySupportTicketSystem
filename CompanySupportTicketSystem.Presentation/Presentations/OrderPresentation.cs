using static System.Console;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.Services;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.DTOs.Orders;

namespace CompanySupportTicketSystem.Presentation.Presentations;

public class OrderPresentation
{
    public static async Task Show()
    {
        OrderService orderService = new OrderService();
        bool check = true;
        while (check)
        {
            try
            {
                await Out.WriteLineAsync("1. Create new Order");
                await Out.WriteLineAsync("2. Delete Order by Id");
                await Out.WriteLineAsync("3. Update Order");
                await Out.WriteLineAsync("4. Get Order by Id");
                await Out.WriteLineAsync("5. Get all Orders");
                await Out.WriteLineAsync("6. Close");

                int number = int.Parse(ReadLine());
                Service.DTOs.Orders.OrderForCreationDto orderDto = new Service.DTOs.Orders.OrderForCreationDto();
                switch (number)
                {
                    case 1:
                        Clear();
                        await Out.WriteAsync("Enter the Seat: ");
                        orderDto.Seat = ReadLine();

                        await Out.WriteAsync("Enter the UserId: ");
                        orderDto.UserId = long.Parse(ReadLine());

                        await Out.WriteAsync("Enter the TicketId: ");
                        orderDto.TicketId = long.Parse(ReadLine());

                        var added = await orderService.AddAsync(orderDto);
                        if (added)
                            await Out.WriteLineAsync("Order created successfully.");
                        break;

                    case 2:
                        Clear();
                        await Out.WriteAsync("Enter the OrderId -> ");
                        int orderId = int.Parse(ReadLine());

                        var deleteOrder = await orderService.DeleteAsync(orderId);
                        if (deleteOrder)
                            await Out.WriteLineAsync("Order successfully deleted");
                        break;

                    case 3:
                        Clear();
                        await Out.WriteAsync("Enter the Order ID: ");
                        int Id = int.Parse(ReadLine());
                        OrderForUpdatedDto orderUpd = new OrderForUpdatedDto();

                        await Out.WriteAsync("Enter the Seat: ");
                        orderUpd.Seat = ReadLine();

                        await Out.WriteAsync("Is Paid (true/false): ");
                        orderUpd.Paid = bool.Parse(ReadLine());

                        var updated = await orderService.UpdateAsync(Id, orderUpd);
                        if (updated)
                            await Out.WriteLineAsync("Order updated successfully.");
                        break;

                    case 4:
                        Clear();
                        await Out.WriteAsync("Enter the Order ID: ");
                        long OrderId = long.Parse(ReadLine());
                        var orderInfo = await orderService.GetByIdAsync(OrderId);

                        await Out.WriteLineAsync($"OrderId: {orderInfo.OrderId}" +
                            $"\nSeat: {orderInfo.Seat}" +
                            $"\nUserId: {orderInfo.UserId}" +
                            $"\nTicketId: {orderInfo.TicketId}" +
                            $"\nPaid: {orderInfo.Paid}" +
                            $"\nCreatedAt: {orderInfo.CreatedAt}");
                        break;

                    case 5:
                        Clear();
                        var orderInfos = await orderService.GetAllAsync();
                        foreach (var order in orderInfos)
                            await Out.WriteLineAsync($"OrderId: {order.OrderId}" +
                                $"\nSeat: {order.Seat}" +
                                $"\nUserId: {order.UserId}" +
                                $"\nTicketId: {order.TicketId}" +
                                $"\nPaid: {order.Paid}" +
                                $"\nCreatedAt: {order.CreatedAt}\n");
                        break;

                    case 6:
                        Console.Clear();
                        await Out.WriteLineAsync("Thank you :)");
                        check = false;
                        break;
                }
            }
            catch (TicketExceptions ex)
            {
                await Out.WriteLineAsync($"{ex.statusCode} : {ex.Message}");
            }
            catch (Exception ex)
            {
                await Out.WriteLineAsync(ex.Message);
            }
            finally
            {
                await Out.WriteLineAsync();
            }
        }
    }
}
