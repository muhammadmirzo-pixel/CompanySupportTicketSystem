using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Service.DTOs.Users;
using CompanySupportTicketSystem.Service.Interfaces;
using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Service.Exceptions;


namespace CompanySupportTicketSystem.Service.Services;

public class UserService : IUserService
{
    IRepository<User> userRepository = new Repository<User>();

    public async Task<bool> AddAsync(User user)
    {
        var users = await this.userRepository.RetrievAllAsync();
        if (users.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            throw new TicketExceptions(409, "User already exists");
        await userRepository.InsertAsync(user);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var deleteResponse = await this.userRepository.RetrievByIdAsync(id);
        if (deleteResponse == null)
            throw new TicketExceptions(404, "User not found");

        await userRepository.DeleteByIdAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var users = await this.userRepository.RetrievAllAsync();
        if (!users.Any())
            throw new TicketExceptions(404, "Users not found");

        var mappedUsers = users.Select(u => new UserForResultDto(){
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            Gender = u.Gender,
            
        }).ToList();

        return mappedUsers;
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var user = await this.userRepository.RetrievByIdAsync(id);
        if (user is null)
            throw new TicketExceptions(404, "User not found");
        var mappedUser = new UserForResultDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Gender = user.Gender,
        };

        return mappedUser;
    }

    public async Task<bool> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var userUpdate = await this.userRepository.RetrievByIdAsync(id);
        if (userUpdate is null)
            throw new TicketExceptions(404, "User not found");

        var mappedUser = new User()
        {
            Id = userUpdate.Id,
            FirstName = userUpdate.FirstName,
            LastName = userUpdate.LastName,
            Email = userUpdate.Email,
            PhoneNumber = userUpdate.PhoneNumber,
            Gender = userUpdate.Gender,
            Password = userUpdate.Password,
            Address = userUpdate.Address,
            DateOfBirth = userUpdate.DateOfBirth,
            CreatedAt = userUpdate.CreatedAt,
            UpdatedAt = userUpdate.UpdatedAt,

        };

        await this.userRepository.UpdateAsync(mappedUser);
        return true;
    }
}
