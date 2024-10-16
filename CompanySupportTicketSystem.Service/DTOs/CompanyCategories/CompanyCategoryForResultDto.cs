namespace CompanySupportTicketSystem.Service.DTOs.CompanyCategories;

public class CompanyCategoryForResultDto
{
    public long Id {  get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}
