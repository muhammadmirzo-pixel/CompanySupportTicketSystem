using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.CompanyCategories;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface ICompanyCategoryService
{
    public Task<bool> AddAsync(CompanyCategory category);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<bool> UpdateAsync(CompanyCategory category);
    public Task<CompanyCategoryForResultDto> GetByIdAsync(long id);
    public Task<CompanyCategoryForResultDto> GetAllAsync();

}
