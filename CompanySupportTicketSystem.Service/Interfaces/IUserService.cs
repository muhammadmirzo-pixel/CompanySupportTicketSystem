using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Users;

namespace CompanySupportTicketSystem.Service.Interfaces;

public interface IUserService
{
    public Task<bool> AddAsync(User user);
    public Task<bool> UpdateAsync(long id,UserForUpdateDto dto);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<UserForResultDto> GetByIdAsync(int id);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
}
