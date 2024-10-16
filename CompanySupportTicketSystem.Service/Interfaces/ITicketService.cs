using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface ITicketService
{
    public Task<bool> AddAsync(TicketForCreationDto ticket);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<bool> UpdateAsync(long id, TicketForUpdateDto ticket);
    public Task<TicketForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<TicketForResultDto>> GetAllAsync();

    public Task<IEnumerable<TicketForResultDto>> GetAllByCompanyIdAsync(long id);
}
