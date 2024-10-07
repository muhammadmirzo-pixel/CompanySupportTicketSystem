using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanySupportTicketSystem.Service.DTOs.Tickets;      

public class TicketForCreationDto
{
    public string Description { get; set; }
    public DateTime StartTime { get; set; }
    public decimal Price { get; set; }
    public long CompanyId { get; set; }
    public string Seat { get; set; }
    public long Count { get; set; }
}
