namespace CompanySupportTicketSystem.Service.DTOs.Companies;

public class CompanyForCreationDto
{
    public string CompanyName { get; set; }
    public long CategoryId { get; set; }
    public string Description { get; set; }
    public int CompanyId { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public decimal Rating { get; set; }
}
