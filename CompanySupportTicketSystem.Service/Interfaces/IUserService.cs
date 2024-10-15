using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Users;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface IUserService
{
    public Task<bool> AddAsync(UserForCreationDto dto);
    public Task<bool> UpdateAsync(long id,UserForUpdateDto dto);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<UserForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
}
