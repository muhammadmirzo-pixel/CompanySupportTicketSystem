﻿namespace CompanySupportTicketSystem.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Gender { get; set; }
}
