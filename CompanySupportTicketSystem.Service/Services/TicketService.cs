using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;

namespace CompanySupportTicketSystem.Service.Services;

public class TicketService : ITicketService
{
    IRepostiory<Ticket> ticketRepository  = new Repository<Ticket>();
    public async Task<bool> AddAsync(Ticket ticket)
    {
        var users = await this.ticketRepository.RetrievAllAsync();
        if (users.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            throw new TicketExceptions(409, "User already exists");
        users.Add(user);
        return true;
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
