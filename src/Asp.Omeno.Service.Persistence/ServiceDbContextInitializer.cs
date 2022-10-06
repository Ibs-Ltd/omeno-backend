using Asp.Omeno.Service.Common.Enums;
using Asp.Omeno.Service.Common.Extensions;
using Asp.Omeno.Service.Domain.Entities;
using Asp.Omeno.Service.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Asp.Omeno.Service.Persistence
{
    public class ServiceDbContextInitializer
    {
        public static void Initialize(ServiceDbContext context)
        {
            new ServiceDbContextInitializer().Seed(context);
        }
        private void Seed(ServiceDbContext context)
        {
            context.Database.EnsureCreated();

            SeedLanguages(context);
            SeedProductStatuses(context);
            SeedProducTypes(context);
            SeedProducSteps(context);
            SeedTokens(context);
            SeedAddressTypes(context);
            SeedRoles(context);
            SeedSuperUser(context);
            SeedUserClaims(context);
            SeedEmailTemplates(context);
        }
        private void SeedSuperUser(ServiceDbContext context)
        {
            if (context.Users.Any()) return;

            var user = new User
            {
                Id = Guid.Parse("8237efce-4c74-4cff-9830-d5769f3c1f2c"),
                FirstName = "Administrator",
                LastName = "User",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                DateOfBirth = DateTime.Now,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                Tokens = 0,
                LanguageId = Guid.Parse("75689b94-ebd1-47c4-afa6-ed5cd3b4e0c6"),
                AcceptedTerms = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = "AQAAAAEAACcQAAAAEOp1FcBk9/K+4fLVaumFiGFc/4HJ4Fm6NZ3KBDo+UgIdtt5+l71hChvyg/LiVlBZcg==" // Demo@2020!
            };
            context.Users.Add(user);

            var userRole = new UserRole
            {
                RoleId = RoleEnum.ADMINISTRATOR,
                UserId = user.Id
            };
            context.UserRoles.Add(userRole);

            context.SaveChanges();
        }

        private void SeedUserClaims(ServiceDbContext context)
        {
            if (context.UserClaims.Any()) return;

            var claims = ReadJson("user-claims.json").Deserialize<IList<UserClaim>>();
            context.UserClaims.AddRange(claims);
            context.SaveChanges();
        }

        private void SeedLanguages(ServiceDbContext context)
        {
            if (context.Languages.Any()) return;
            var languages = ReadJson("languages.json").Deserialize<IList<Language>>();
            context.Languages.AddRange(languages);
            context.SaveChanges();
        }

        private void SeedRoles(ServiceDbContext context)
        {
            if (context.Roles.Any()) return;
            var roles = ReadJson("roles.json").Deserialize<IList<Role>>();
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }

        private void SeedProductStatuses(ServiceDbContext context)
        {
            if (context.ProductStatuses.Any()) return;
            var productStatuses = ReadJson("product-statuses.json").Deserialize<IList<ProductStatus>>();
            context.ProductStatuses.AddRange(productStatuses);
            context.SaveChanges();
        }

        private void SeedProducTypes(ServiceDbContext context)
        {
            if (context.ProductTypes.Any()) return;
            var productTypes = ReadJson("product-types.json").Deserialize<IList<ProductType>>();
            context.ProductTypes.AddRange(productTypes);
            context.SaveChanges();
        }

        private void SeedProducSteps(ServiceDbContext context)
        {
            if (context.ProductSteps.Any()) return;
            var productSteps = ReadJson("product-steps.json").Deserialize<IList<ProductStep>>();
            context.ProductSteps.AddRange(productSteps);
            context.SaveChanges();
        }

        private void SeedTokens(ServiceDbContext context)
        {
            if (context.Tokens.Any()) return;
            var tokens = ReadJson("tokens.json").Deserialize<IList<Token>>();
            context.Tokens.AddRange(tokens);
            context.SaveChanges();
        }

        private void SeedAddressTypes(ServiceDbContext context)
        {
            if (context.AddressTypes.Any()) return;
            var addressTypes = ReadJson("address-types.json").Deserialize<IList<AddressType>>();
            context.AddressTypes.AddRange(addressTypes);
            context.SaveChanges();
        }

        private void SeedEmailTemplates(ServiceDbContext context)
        {
            if (context.EmailTemplates.Any()) return;
            var emailTemplates = ReadJson("email-templates.json").Deserialize<IList<EmailTemplate>>();
            context.EmailTemplates.AddRange(emailTemplates);
            context.SaveChanges();
        }

        private string ReadJson(string filename)
        {
            var assembly = typeof(ServiceDbContext).Assembly;

            var resources = assembly.GetManifestResourceNames();

            using (Stream stream = assembly.GetManifestResourceStream(resources.First(x => x.Contains(filename))))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
