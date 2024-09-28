using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.CompanyCategories;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface ICompanyCategoryService
{
    public Task<bool> AddAsync(CompanyCategoryForCreationDto category);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<bool> UpdateAsync(long id, CompanyCategoryForUpdateDto category);
    public Task<CompanyCategoryForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<CompanyCategoryForResultDto>> GetAllAsync();

}
    