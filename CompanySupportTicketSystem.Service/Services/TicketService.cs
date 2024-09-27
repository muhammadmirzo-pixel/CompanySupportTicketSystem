using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;

namespace CompanySupportTicketSystem.Service.Services;

public class TicketService : ITicketService
{
    IRepository<Ticket> ticketRepository = new Repository<Ticket>();
    public async Task<bool> AddAsync(Ticket ticket)
    {
        var tickets = await this.ticketRepository.RetrievAllAsync();
        if(tickets.Any(t => t.Id == ticket.Id))
            throw new TicketExceptions(409, "Ticket already exists");
        tickets.Add(ticket);
        return true;
    }

    
        
    

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var deleteResponse = await this.ticketRepository.DeleteByIdAsync(id);
        if (deleteResponse)
            return true;
        throw new TicketExceptions(404, "Ticket not found");
    }

    public async Task<IEnumerable<TicketForResultDto>> GetAllAsync()
    {
        var tickets = await this.ticketRepository.RetrievAllAsync();
        if (!tickets.Any())
            throw new TicketExceptions(404, "Ticket not found");

        var mappedTickets = tickets.Select(t => new TicketForResultDto()
        {
            CompanyId = t.CompanyId,
            Description = t.Description,
            Price = t.Price,
            StartTime = t.StartTime,
            Seat = t.Seat,
        }).ToList();

        return mappedTickets;
    }

    public async Task<TicketForResultDto> GetByIdAsync(long id)
    {
        var ticket = await this.ticketRepository.RetrievByIdAsync(id);
        if (ticket is null)
            throw new TicketExceptions(404, "Ticket not found");

        var mappedTicket = new TicketForResultDto()
        {
            CompanyId = ticket.CompanyId,
            Description = ticket.Description,
            Price = ticket.Price,
            StartTime = ticket.StartTime,
            Seat = ticket.Seat,
        };

        return mappedTicket;
    }

    public async Task<bool> UpdateAsync(long id, TicketForUpdateDto ticket)
    {
        var ticketUpdate = await this.ticketRepository.RetrievByIdAsync(id);
        if (ticketUpdate is null)
            throw new TicketExceptions(404, "Ticket not found");

        var mappedTicket = new Ticket()
        {
            CompanyId = ticketUpdate.CompanyId,
            Description = ticketUpdate.Description,
            Price = ticketUpdate.Price,
            StartTime = ticketUpdate.StartTime,
            Seat = ticketUpdate.Seat,

        };

        await this.ticketRepository.UpdateAsync(mappedTicket);
        return true;
    }
}
