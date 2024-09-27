using CompanySupportTicketSystem.Service.DTOs.Orders;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface IOrderService
{
    Task<bool> AddAsync(OrderForCreationDto dto);
    Task<bool> UpdateAsync(long Id, OrderForUpdatedDto orderUpd);
    Task<bool> DeleteAsync(long Id);
    Task<OrderForResultDto> GetByIdAsync(long Id);
    Task<IEnumerable<OrderForResultDto>> GetAllAsync();
}
