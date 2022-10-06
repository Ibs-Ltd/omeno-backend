using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Infrastructure
{
    public class EmailService : IEmailService
    {
        public async Task Send(EmailModel model)
        {
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Credentials = new NetworkCredential("noreply.omeno.app@gmail.com", "ZazaOmeno20201!");
                client.EnableSsl = true;

                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("butterfly@vision-agency.com");
                    message.To.Add(new MailAddress(model.Receiver));
                    message.Subject = model.Subject;
                    message.Body = model.Content;
                    message.IsBodyHtml = model.IsHtmlBody;
                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
