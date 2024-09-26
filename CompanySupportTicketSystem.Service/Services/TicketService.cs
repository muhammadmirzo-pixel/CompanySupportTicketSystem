using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Interfaces;

namespace CompanySupportTicketSystem.Service.Services;

public class TicketService : ITicketService
{
    public Task<bool> AddAsync(Ticket ticket)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CancelTicketAsync(int ticketId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TicketForResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TicketForResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TicketForUpdateDto> UpdateAsync(long id, TicketForUpdateDto ticket)
    {
        throw new NotImplementedException();
    }
}
