using CompanySupportTicketSystem.Service.DTOs.Companies;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;
using CompanySupportTicketSystem.Service.Services;
using System.Runtime.InteropServices;

namespace CompanySupportTicketSystem.Presentation;

public class CompanyPresentation
{
    CompanyService  companyService = new CompanyService();
    CompanyCategoryService companyCategoryService = new CompanyCategoryService();
    ITicketService ticketService = new TicketService();  
    
    
    public async Task ShowCompanyAsync(long companyId)
    {
        try
        {
            while (true)
            {
                await Console.Out.WriteLineAsync("1 -> Create Tickets ");
                await Console.Out.WriteLineAsync("2 -> Get All Tickets");
                await Console.Out.WriteLineAsync("3 -> Update Tickets");
                await Console.Out.WriteLineAsync("4 -> Remove Tickets");
                await Console.Out.WriteLineAsync("5 -> Company Account");
                var result = int.Parse(Console.ReadLine());
                
                switch (result)
                {
                    case 1: 
                        {
                            var ticket = new TicketForCreationDto();
                            await Console.Out.WriteLineAsync("Please Enter Title");
                            ticket.Seat = Console.ReadLine();
                            await Console.Out.WriteLineAsync("Enter Count of Places");
                            ticket.Count = int.Parse(Console.ReadLine());
                            await Console.Out.WriteLineAsync("Enter Registration time ()");
                            break;
                        }
                    case 2:
                        {
                            IEnumerable<TicketForResultDto> tickets = await ticketService.GetAllByCompanyIdAsync(companyId);
                            foreach(var i in tickets)
                            {
                                await Console.Out.WriteLineAsync($"Id  {i.Id}");
                                await Console.Out.WriteLineAsync("Title " + i.Seat);
                                await Console.Out.WriteLineAsync($"Start Registration Time : {i.StartTime}");
                                await Console.Out.WriteLineAsync($"Price {i.Price}");
                                await Console.Out.WriteLineAsync($"{i.Company.CompanyName}");
                            }
                            break;
                        }
                    case 3:
                        {

                            IEnumerable<TicketForResultDto> tickets = await ticketService.GetAllByCompanyIdAsync(companyId);
                            foreach (var i in tickets)
                            {
                                await Console.Out.WriteLineAsync($"Id  {i.Id}");
                                await Console.Out.WriteLineAsync("Title " + i.Seat);
                                await Console.Out.WriteLineAsync($"Start Registration Time : {i.StartTime}");
                                await Console.Out.WriteLineAsync($"Price {i.Price}");
                                await Console.Out.WriteLineAsync($"{i.Company.CompanyName}");
                            }
                            await Console.Out.WriteAsync("Enter TicketId for Update ");
                            var ticketId = long.Parse(Console.ReadLine());
                            await UpdateTicketAsync(ticketId);
                            break;
                        }
                    case 4:
                        {
                            IEnumerable<TicketForResultDto> tickets = await ticketService.GetAllByCompanyIdAsync(companyId);
                            foreach (var i in tickets)
                            {
                                await Console.Out.WriteLineAsync($"Id  {i.Id}");
                                await Console.Out.WriteLineAsync("Title " + i.Seat);
                                await Console.Out.WriteLineAsync($"Start Registration Time : {i.StartTime}");
                                await Console.Out.WriteLineAsync($"Price {i.Price}");
                                await Console.Out.WriteLineAsync($"{i.Company.CompanyName}");
                            }
                            await Console.Out.WriteAsync("Choose Ticket Id For Delete:");
                            var id = long.Parse(Console.ReadLine());
                            await ticketService.DeleteByIdAsync(id);
                            await Console.Out.WriteLineAsync("Ticket Successfully deleted");
                            break;
                        }
                }


            }
        }catch (TicketExceptions ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }


    public async Task ShowAccountAsync(long CompanyId)
    {
        try
        {
            while (true)
            {
                var company = await companyService.GetByIdAsync(CompanyId);
                Console.Clear();
                await Console.Out.WriteLineAsync("Choose option To change");
                await Console.Out.WriteLineAsync($"1 -> CompanyName: {company.CompanyName}");
                await Console.Out.WriteLineAsync($"2 -> Description: {company.Description}");
                await Console.Out.WriteLineAsync($"3 -> Email:  {company.Email}");
                await Console.Out.WriteLineAsync($"4 -> Address: {company.Address}");
                await Console.Out.WriteLineAsync($"5 -> Category: {company.Category}");
                await Console.Out.WriteLineAsync($"6 -> PhoneNumber: {company.PhoneNumber}");
                await Console.Out.WriteLineAsync($"     CreatedAt: {company.FoundedDate}");
                await Console.Out.WriteLineAsync("10 -> (EXIT)");
                var option = Console.ReadLine();
                int result;
                int.TryParse(option, out result);
                switch(result)
                {
                    case 1:
                        {
                            await Console.Out.WriteLineAsync("Enter New Company Name: ");
                            company.CompanyName = Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            await Console.Out.WriteLineAsync("Enter new Company Description");
                            company.Description  = Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            await Console.Out.WriteLineAsync("Enter new Company  Email");
                            company.Email = Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            await Console.Out.WriteLineAsync("Enter new Company Address");
                            company.Address = Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            await Console.Out.WriteLineAsync("Choose Category");
                            var categories = await companyCategoryService.GetAllAsync();
                            foreach (var category in categories)
                            {
                                await Console.Out.WriteLineAsync($"{category.Id}");
                                await Console.Out.WriteLineAsync($"{category.CategoryName}");
                                await Console.Out.WriteLineAsync($"{category.Description}");
                                await Console.Out.WriteLineAsync($"{category.IsActive}");
                                await Console.Out.WriteLineAsync();
                            }
                            company.Category.Id  = int.Parse(Console.ReadLine());
                            break;

                        }
                    case 6:
                        {
                            await Console.Out.WriteLineAsync("Enter New Phone Number");
                            company.PhoneNumber = Console.ReadLine();
                            break;
                        }
                    case 10:
                        {
                            return;
                        }
                }
                var mappingCompany = new CompanyForUpdateDto()
                {
                    Address = company.Address,
                    CategoryId = company.Category.Id,
                    CompanyName = company.CompanyName,
                    Description = company.Description,
                    Email = company.Email,
                    IsActive     = company.IsActive,
                    PhoneNumber = company.PhoneNumber,
                    Rating = company.Rating
                };
                await companyService.UpdateAsync(company.Id, mappingCompany);
            }
        }catch(TicketExceptions ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }catch (Exception  ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }



    public async Task UpdateTicketAsync(long TicketId) 
    {
        try
        {
            while (true)
            {
                var ticket = await ticketService.GetByIdAsync(TicketId);
                Console.Clear();
                await Console.Out.WriteLineAsync("Choose option To change");
                await Console.Out.WriteLineAsync($"Company: {ticket.Company}");
                await Console.Out.WriteLineAsync($"1 -> Description: {ticket.Description}");
                await Console.Out.WriteLineAsync($"2 -> Price:  {ticket.Price}");
                await Console.Out.WriteLineAsync($"3 -> Place Count: {ticket.Seat}");
                await Console.Out.WriteLineAsync($"4 -> Registretion Time: {ticket.StartTime}");
                await Console.Out.WriteLineAsync("10 -> (EXIT)");
                var option = Console.ReadLine();
                int result;
                int.TryParse(option, out result);
                switch (result)
                {
                    case 1:
                        {
                            await Console.Out.WriteLineAsync("Enter New Description: ");
                            ticket.Description = Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            await Console.Out.WriteLineAsync("Enter new Price");
                            ticket.Price = decimal.Parse(Console.ReadLine());
                            break;
                        }
                    case 3:
                        {
                            await Console.Out.WriteLineAsync("Enter new Place Count");
                            ticket.Seat = Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            await Console.Out.WriteLineAsync("Enter new Company Address");
                            ticket.StartTime = DateTime.Parse(Console.ReadLine());
                            break;
                        }
                    case 10:
                        {
                            return;
                        }
                }
                var mappingTicket = new TicketForUpdateDto()
                {
                    Count = ticket.Count,
                    Description = ticket.Description,
                    CompanyId = ticket.Company.Id,
                    Price = ticket.Price,
                    Seat= ticket.Seat,
                    StartTime = ticket.StartTime
                };
                await ticketService.UpdateAsync(ticket.Id, mappingTicket);
            }
        }
        catch (TicketExceptions ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
        catch (Exception ex)
        {
            await Console.Out.WriteLineAsync(ex.Message);
        }
    }


}
