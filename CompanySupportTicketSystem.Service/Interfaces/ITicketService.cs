using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface ITicketService
{
    public Task<bool> AddAsync(Ticket ticket);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<TicketForUpdateDto> UpdateAsync(long id, TicketForUpdateDto ticket);
    public Task<TicketForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<TicketForResultDto>> GetAllAsync();
    public Task<bool> CancelTicketAsync(int  ticketId);
}
