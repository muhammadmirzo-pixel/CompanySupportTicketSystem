using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySupportTicketSystem.Service.DTOs.CompanyCategories;

public class CompanyCategoryForCreationDto
{
    public string CategoryName { get; set; }
    public string CategoryId { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

}
