using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Services;
public class MailService : IMailService
{

    private readonly SmtpSettings _smtpSettings;

    public MailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;

        var sender = new SmtpSender(() => new SmtpClient(_smtpSettings.SmtpHost)
        {
            UseDefaultCredentials = false,
            Port = _smtpSettings.SmtpPort,
            Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
            EnableSsl = true
        });

        Email.DefaultSender = sender;

    }


    public async Task SendMailAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        var email = Email
            .From(_smtpSettings.FromAddress)
            .To(to)
            .Subject(subject)
            .Body(body);

        await email.SendAsync(cancellationToken);
    }

}
