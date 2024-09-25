using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Companies;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface ICompanyService
{
    public Task<bool> AddAsync(Company company);
    public Task<bool> UpdateAsync(long id,CompanyForUpdateDto company);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<CompanyForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<CompanyForResultDto>> GetAllAsync();
    public Task<Company> SearchByName(string name);
}
