using Asp.Omeno.Service.Application.Interfaces;
using Asp.Omeno.Service.Application.Models;
using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.Omeno.Service.Application.Services.Users.Queries.ForgotPassword
{
    public class ForgotPasswordEmailNotificationHandler : INotificationHandler<ForgotPasswordEmailNotification>
    {
        private readonly IEmailService _emailService;
        private readonly IServiceDbContext _dbContext;
        public ForgotPasswordEmailNotificationHandler(IEmailService emailService, IServiceDbContext dbContext)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task Handle(ForgotPasswordEmailNotification notification, CancellationToken cancellationToken)
        {
            var template = PrepareTemplate(notification, _dbContext.EmailTemplates.FirstOrDefault(x => x.Id == EmailTemplateTypesEnum.ResetPassword));

            var emailModel = new EmailModel
            {
                IsHtmlBody = true,
                Content = template.Content,
                Receiver = notification.Email,
                Subject = template.Title
            };

            await _emailService.Send(emailModel);

        }

        private EmailTemplate PrepareTemplate(ForgotPasswordEmailNotification notification, EmailTemplate emailTemplate)
        {
            IDictionary<string, string> placeholders = new Dictionary<string, string>()
            {
                {"<#FIRSTNAME#>", notification.FirstName },
                {"<#LASTNAME#>", notification.LastName },
                {"<#URL#>", notification.URL }
            };

            foreach (var placeholder in placeholders)
            {
                emailTemplate.Content = emailTemplate.Content.Replace(placeholder.Key, placeholder.Value);
            }

            return emailTemplate;
        }

    }
}
