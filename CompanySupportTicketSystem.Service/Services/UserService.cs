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

    public async Task<bool> AddAsync(UserForCreationDto dto)
    {
        var users = await this.userRepository.RetrievAllAsync();
        // check the user is avaiable or not 
        var user = users.Where(u => u.Email.ToLower() == dto.Email.ToLower()).FirstOrDefault();
        if (user is not null)
            throw new TicketExceptions(400, "User already exist");

        var mappedUser = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Address = dto.Address,
            DateOfBirth = dto.DateOfBirth,
            Gender = dto.Gender,
            PhoneNumber = dto.PhoneNumber,

        };

        return await this.userRepository.InsertAsync(mappedUser);
        
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var user = await this.userRepository.RetrievByIdAsync(id);
        if (user is null)
            throw new TicketExceptions(404, "User is not found");

        await this.userRepository.DeleteByIdAsync(id);
        return true;
    }

    public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
    {
        var allUsers = await this.userRepository.RetrievAllAsync();
        var userList = new List<UserForResultDto>();
        foreach(var user in allUsers)
        {
            var mapping = new UserForResultDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
            };
        }
        return userList;
    }

    public async Task<UserForResultDto> GetByIdAsync(long id)
    {
        var users = await this.userRepository.RetrievAllAsync();
        var user = users.Where(u => u.Id == id).FirstOrDefault();
        if (user is null)
            throw new TicketExceptions(404, "User is not found");

        var mappedUser = new UserForResultDto()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber,

        };
        return mappedUser;
    }

    public async Task<bool> UpdateAsync(long id, UserForUpdateDto dto)
    {
        var user = await this.userRepository.RetrievByIdAsync(id);
        if (user is null)
            throw new TicketExceptions(404, "User is not found");

        var mappedUser = new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Gender = user.Gender,
            PhoneNumber = user.PhoneNumber,
            Address = user.Address,
            DateOfBirth = user.DateOfBirth,

        };

        var updatedUser = await this.userRepository.UpdateAsync(mappedUser);
        return updatedUser;
    }
}
