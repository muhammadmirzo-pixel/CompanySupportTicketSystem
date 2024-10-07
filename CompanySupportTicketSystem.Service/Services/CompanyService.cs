using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Data.Repositories;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Service.DTOs.Companies;
using CompanySupportTicketSystem.Service.DTOs.CompanyCategories;
using CompanySupportTicketSystem.Service.Exceptions;
using CompanySupportTicketSystem.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySupportTicketSystem.Service.Services;

public class CompanyService : ICompanyService
{
    IRepository<Company> companyRepository = new Repository<Company>();
    ICompanyCategoryService categoryService  = new CompanyCategoryService();
    public async Task<bool> AddAsync(CompanyForCreationDto company)
    {
        var companies = await this.companyRepository.RetrievAllAsync();
        if (companies.Any(t => t.CompanyName == company.CompanyName))
            throw new TicketExceptions(409, "Company already exists");

        var mappedCompany  = new Company()
        {
            CompanyName = company.CompanyName,
            Email = company.Email,
            Description = company.Description,
            Address = company.Address,
            CategoryId = company.CategoryId,
            CreatedAt = DateTime.Now,
            IsActive = company.IsActive,
            PhoneNumber = company.PhoneNumber,
            Rating = company.Rating,
        };
        companies.Add(mappedCompany);
        return true;
    }





    public async Task<bool> DeleteByIdAsync(long id)
    {

        var isAvaible = await GetByIdAsync(id);
        if (isAvaible != null)
        {
            var deleteResponse = await this.companyRepository.DeleteByIdAsync(id);
            return true;
        }
        throw new TicketExceptions(404, "Company not found");
    }

    public async Task<IEnumerable<CompanyForResultDto>> GetAllAsync()
    {
        var companies = await this.companyRepository.RetrievAllAsync();
        if (!companies.Any())
            throw new TicketExceptions(404, "Company not found");

        var companiesForResult = new List<CompanyForResultDto>();
        foreach (var i in companies) {

            var company = new CompanyForResultDto()
            {
                CompanyName = i.CompanyName,
                Rating = i.Rating,
                PhoneNumber = i.PhoneNumber,
                IsActive = i.IsActive,
                Address = i.Address,
                Category = await categoryService.GetByIdAsync(i.CategoryId),
                Description = i.Description,
                Email = i.Email,
                FoundedDate = i.CreatedAt
            };
            companiesForResult.Add(company);
        }

        return  companiesForResult;
    }

    public async Task<CompanyForResultDto> GetByIdAsync(long id)
    {
        var company = await this.companyRepository.RetrievByIdAsync(id);
        if (company is null)
            throw new TicketExceptions(404, "Company not found");

        var mappedCompany = new CompanyForResultDto()
        {
            Id = id ,
            CompanyName = company.CompanyName,
            Rating = company.Rating,
            PhoneNumber = company.PhoneNumber,
            IsActive = company.IsActive,
            Address = company.Address,
            Category = await categoryService.GetByIdAsync(company.CategoryId),
            Description = company.Description,
            Email = company.Email,
            FoundedDate = company.CreatedAt
        };

        return mappedCompany;
    }

    public async Task<CompanyForResultDto> SearchByName(string name)
    {
         var company = await GetAllAsync();
        if (company.Any(t => t.CompanyName == name))
            return company.Where(c => c.CompanyName == name).FirstOrDefault();
        throw new TicketExceptions(404, "Company not found");
    }

    public async Task<bool> UpdateAsync(long id, CompanyForUpdateDto company  )
    {
        var categoryUpdate = await this.companyRepository.RetrievByIdAsync(id);
        if (categoryUpdate is null)
            throw new TicketExceptions(404, "Category not found");

        var mappedCompany = new Company()
        {
            Id = id,
            CompanyName = company.CompanyName,
            Rating = company.Rating,
            PhoneNumber = company.PhoneNumber,
            IsActive = company.IsActive,
            Address = company.Address,
            CategoryId = company.CategoryId,
            Description = company.Description,
            Email = company.Email,
            CreatedAt = categoryUpdate.CreatedAt,
            UpdatedAt = DateTime.UtcNow
        };

        await this.companyRepository.UpdateAsync(mappedCompany);
        return true;
    }
}
