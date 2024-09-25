namespace CompanySupportTicketSystem.Service.DTOs.Companies;

public class CompanyForResultDto
{
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime FoundedDate { get; set; }
    public bool IsActive { get; set; }
    public decimal Rating { get; set; }
}
