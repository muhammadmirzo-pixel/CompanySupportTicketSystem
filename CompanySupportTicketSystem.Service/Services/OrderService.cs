using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;
using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Service.DTOs.Orders;


namespace CompanySupportTicketSystem.Service.Services;
public class OrderService : IOrderService
{
    private readonly IRepository<Order> orderRepository = new Repository<Order>();

    public async Task<bool> AddAsync(OrderForCreationDto dto)
    {
        var orders = await this.orderRepository.RetrievAllAsync();

        var order = orders.Where(s => s.Seat == dto.Seat).FirstOrDefault();
        if (order is not null)
            throw new TicketExceptions(409, "User already exist");

        var orderMapping = new Order()
        {
            Seat = dto.Seat,
            UserId = dto.UserId,
            TicketId = dto.TicketId,
            Paid = false, // false qiganimi sababi yangi order to'lanmagan deb oldim
            CreatedAt = DateTime.Now
        };

        return await orderRepository.InsertAsync(orderMapping);
    }

    public async Task<bool> UpdateAsync(long orderId, OrderForUpdatedDto orderUpd) 
    {
        var order = await orderRepository.RetrievByIdAsync(orderId);
        if (order == null)
                throw new TicketExceptions(404, "seat not found");

        var orderMapping = new Order()
        {
            Id = order.Id,
            Seat = orderUpd.Seat,
            Paid = orderUpd.Paid,
            UserId = order.UserId,
            TicketId = order.TicketId,
            CreatedAt = order.CreatedAt
        };

        var orderUpdated = await orderRepository.UpdateAsync(orderMapping);
        return orderUpdated;
    }

    public async Task<OrderForResultDto> GetByIdAsync(long orderId) 
    {
        var orders = await orderRepository.RetrievAllAsync();
        var order = orders.Where(o => o.Id == orderId).FirstOrDefault();
        if (order == null)
            throw new TicketExceptions(404, "order not found");

        var mappedOrder = new OrderForResultDto()
        {
            OrderId = order.Id,
            Seat = order.Seat,
            Paid = order.Paid,
            UserId = order.UserId,
            TicketId = order.TicketId,
            CreatedAt = order.CreatedAt
        };

        return mappedOrder;
    }

    public async Task<bool> DeleteAsync(long orderId)
    {
        var order = await orderRepository.RetrievByIdAsync(orderId);

        if (order == null)
            throw new TicketExceptions(404, $"Order with ID {orderId} not found.");
        

        await orderRepository.DeleteByIdAsync(orderId);
        return true;
    }


    public async Task<IEnumerable<OrderForResultDto>> GetAllAsync()
    {
        var orders = await orderRepository.RetrievAllAsync();

        var orderDtos = orders.Select(order => new OrderForResultDto
        {
            OrderId = order.Id,
            Seat = order.Seat,
            Paid = order.Paid,
            UserId = order.UserId,
            TicketId = order.TicketId,
            CreatedAt = order.CreatedAt
        });

        return orderDtos;
    }

}

