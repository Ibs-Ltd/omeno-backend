using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Asp.Omeno.Service.Application.Configurations
{
    public class IdentityConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            var list = new List<ApiResource>
            {
                new ApiResource("omeno_service","Omeno API"){
                    ApiSecrets = { new Secret("omeno-service".Sha256()) }
                },
                new ApiResource("claims_service","Omeno Claims API", new[] {
                    "firstName",
                    "lastName",
                    "userId",
                    "email",
                    "userName",
                    ClaimTypes.Role
                })
            };

            return list;
        }
        public static IEnumerable<Client> GetClients()
        {
            var list = new List<Client> {
                new Client{
                    ClientId = "omeno-admin-client",
                    ClientName = "Omeno Admin Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret("omeno-admin".Sha256())
                    },
                    AllowedScopes = {
                        "omeno_service",
                        "claims_service"
                    },
                    AllowedCorsOrigins = new[]{
                        "http://localhost:8080",
                    },
                    AccessTokenLifetime = 31536000,
                    AllowOfflineAccess = true,
                    BackChannelLogoutSessionRequired = true,
                    FrontChannelLogoutSessionRequired = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true
                },
                new Client{
                    ClientId = "omeno-mobile-client",
                    ClientName = "Omeno Mobile Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = {
                        new Secret("omeno-mobile".Sha256())
                    },
                    AllowedScopes = {
                        "omeno_service",
                        "claims_service"
                    },
                    AllowedCorsOrigins = new[]{
                        "http://localhost:8080",
                    },
                    AccessTokenLifetime = 31536000,
                    AllowOfflineAccess = true,
                    BackChannelLogoutSessionRequired = true,
                    FrontChannelLogoutSessionRequired = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true
                },
                new Client{
                    ClientId = "omeno-internal-client",
                    ClientName = "Omeno Internal Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                        new Secret("omeno-internal".Sha256())
                    },
                    AllowedScopes = {
                        "omeno_service"
                    },
                    AllowedCorsOrigins = new[]{
                        "http://localhost:8080",
                    },
                    AccessTokenLifetime = 31536000,
                    AllowOfflineAccess = true,
                    BackChannelLogoutSessionRequired = true,
                    FrontChannelLogoutSessionRequired = true,
                    AccessTokenType = AccessTokenType.Reference,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowAccessTokensViaBrowser = true
                },
            };

            return list;
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }
    }
}
