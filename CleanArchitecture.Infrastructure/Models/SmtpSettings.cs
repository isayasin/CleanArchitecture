namespace CleanArchitecture.Infrastructure.Models;
public sealed class SmtpSettings
{
    public string FromAddress { get; set; }
    public string SmtpHost { get; set; }
    public int SmtpPort { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
