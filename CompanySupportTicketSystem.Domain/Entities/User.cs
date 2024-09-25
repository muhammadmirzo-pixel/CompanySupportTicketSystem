﻿using CompanySupportTicketSystem.Domain.Common;

namespace CompanySupportTicketSystem.Domain.Entities;

public class User : Auditable
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber {  get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address {  get; set; }
    public string PaymentMethod {  get; set; }
    public string Gender {  get; set; }
}
