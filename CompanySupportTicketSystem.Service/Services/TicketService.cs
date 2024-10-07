using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;

namespace CompanySupportTicketSystem.Service.Services;

public class TicketService : ITicketService
{
    ICompanyService companyService  = new CompanyService();
    IRepository<Ticket> ticketRepository = new Repository<Ticket>();
    public async Task<bool> AddAsync(TicketForCreationDto ticket)
    {

        var tickets = await this.ticketRepository.RetrievAllAsync();
        if(tickets.Any(t => t.Description == ticket.Description && t.CompanyId == ticket.CompanyId))
            throw new TicketExceptions(409, "Ticket already exists");
        var mappingTicket = new Ticket()
        {
            Description = ticket.Description,
            CompanyId = ticket.CompanyId,
            Count = ticket.Count,
            CreatedAt = DateTime.Now,
            Price = ticket.Price,
            StartTime = ticket.StartTime,
            Seat = ticket.Seat,
            
        };
        await ticketRepository.InsertAsync(mappingTicket);
        return true;
    }

    
        
    

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var ticket = await GetByIdAsync(id);
        if (ticket != null)
        {
            await this.ticketRepository.DeleteByIdAsync(id);
            return true;
        }
        throw new TicketExceptions(404, "Ticket not found");
    }

    public async Task<IEnumerable<TicketForResultDto>> GetAllAsync()
    {
        
        var tickets = await this.ticketRepository.RetrievAllAsync();
        
        if (!tickets.Any())
            throw new TicketExceptions(404, "Ticket not found");

        var mappedTickets  = new List<TicketForResultDto>();
        foreach (var ticket in tickets)
        {
            var mappedTicket = new TicketForResultDto()
            {
                Id = ticket.Id,
                Company = await companyService.GetByIdAsync(ticket.CompanyId),
                Description = ticket.Description,
                Price = ticket.Price,
                StartTime = ticket.StartTime,
                Seat = ticket.Seat,
                Count = ticket.Count
                
            };
            mappedTickets.Add(mappedTicket);
        }
        return mappedTickets;
    }

    public async Task<IEnumerable<TicketForResultDto>> GetAllByCompanyIdAsync(long id)
    {
        var tickets = (await ticketRepository.RetrievAllAsync())
            .Where(e => e.CompanyId == id)
            .Select(async i=> new TicketForResultDto()
            {
                Id = i.Id,
                Company = await companyService.GetByIdAsync(id), 
                Description = i.Description,
                Count = i.Count,
                Price=i.Price,
                Seat = i.Seat,
                StartTime =i.StartTime
            });
        return await Task.WhenAll(tickets);
        

    }

    public async Task<TicketForResultDto> GetByIdAsync(long id)
    {
        var ticket = await this.ticketRepository.RetrievByIdAsync(id);
        if (ticket is null)
            throw new TicketExceptions(404, "Ticket not found");

        var mappedTicket = new TicketForResultDto()
        {
            Id = ticket.Id,
            Company = await companyService.GetByIdAsync(ticket.CompanyId),
            Description = ticket.Description,
            Price = ticket.Price,
            StartTime = ticket.StartTime,
            Seat = ticket.Seat,
            Count = ticket.Count
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
            Id = ticketUpdate.Id,
            CompanyId = ticketUpdate.CompanyId,
            Description = ticketUpdate.Description,
            Price = ticketUpdate.Price,
            StartTime = ticketUpdate.StartTime,
            Seat = ticketUpdate.Seat,
            Count = ticketUpdate.Count,
            CreatedAt = ticketUpdate.CreatedAt,
            UpdatedAt = DateTime.Now
        };

        await this.ticketRepository.UpdateAsync(mappedTicket);
        return true;
    }
}
