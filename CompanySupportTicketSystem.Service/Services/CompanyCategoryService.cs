using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.CompanyCategories;
using CompanySupportTicketSystem.Service.DTOs.Tickets;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySupportTicketSystem.Service.Services;

public class CompanyCategoryService : ICompanyCategoryService
{
    IRepository<CompanyCategory> companyCategoryRepository = new Repository<CompanyCategory>();
    public async Task<bool> AddAsync(CompanyCategoryForCreationDto category)
    {
        var categories = await this.companyCategoryRepository.RetrievAllAsync();
        if (categories.Any(t => t.CategoryName == category.CategoryName))
            throw new TicketExceptions(409, "Category already exists");
        var mappedCategory = new CompanyCategory()
        {
            CategoryName = category.CategoryName,
            CategoryId = category.CategoryId,
            CreatedAt = DateTime.Now,
            Description = category.Description,
            IsActive = category.IsActive,
        };
        categories.Add(mappedCategory);
        return true;
    }





    public async Task<bool> DeleteByIdAsync(long id)
    {

        var isAvaible = await GetByIdAsync(id);
        if (isAvaible != null)
        {
            var deleteResponse = await this.companyCategoryRepository.DeleteByIdAsync(id);
            return true;
        }
        throw new TicketExceptions(404, "Category not found");
    }

    public async Task<IEnumerable<CompanyCategoryForResultDto>> GetAllAsync()
    {
        var categories = await this.companyCategoryRepository.RetrievAllAsync();
        if (!categories.Any())
            throw new TicketExceptions(404, "Category not found");

        var mappedTickets = categories.Select(t => new CompanyCategoryForResultDto()
        {
            CategoryName = t.CategoryName,
            Description = t.Description,
            IsActive = t.IsActive,
        }).ToList();

        return mappedTickets;
    }

    public async Task<CompanyCategoryForResultDto> GetByIdAsync(long id)
    {
        var category = await this.companyCategoryRepository.RetrievByIdAsync(id);
        if (category is null)
            throw new TicketExceptions(404, "Category not found");

        var mappedTicket = new CompanyCategoryForResultDto()
        {
            CategoryName = category.CategoryName,
            IsActive    = category.IsActive,
            Description = category.Description,
        };

        return mappedTicket;
    }

    public async Task<bool> UpdateAsync(long id, CompanyCategoryForUpdateDto category)
    {
        var categoryUpdate = await this.companyCategoryRepository.RetrievByIdAsync(id);
        if (categoryUpdate is null)
            throw new TicketExceptions(404, "Category not found");

        var mappedCategory = new CompanyCategory()
        {
            CategoryName = category.CategoryName,
            IsActive = category.IsActive,
            Description = category.Description,
            CategoryId = category.CategoryId,
            CreatedAt = categoryUpdate.CreatedAt,
            UpdatedAt = DateTime.UtcNow,
            Id = categoryUpdate.Id
        };

        await this.companyCategoryRepository.UpdateAsync(mappedCategory);
        return true;
    }
}
