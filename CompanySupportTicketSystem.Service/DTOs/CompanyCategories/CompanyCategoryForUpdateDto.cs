namespace CompanySupportTicketSystem.Service.DTOs.CompanyCategories;

public class CompanyCategoryForUpdateDto
{
    public string CategoryName { get; set; }
    public string CategoryId { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
