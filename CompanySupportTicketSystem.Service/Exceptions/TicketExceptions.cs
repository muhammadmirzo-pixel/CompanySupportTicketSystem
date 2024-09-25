namespace CompanySupportTicketSystem.Service.Exceptions;

public class TicketExceptions : Exception
{
    public int statusCode {  get; set; }
    public TicketExceptions(int StatusCode,string message) : base(message)
    { 
        this.statusCode = StatusCode;
    }
}
