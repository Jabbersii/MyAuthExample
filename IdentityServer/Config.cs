using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("api1", "My API");
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client()
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1" }
            };

            yield return new Client()
            {
                ClientId = "ro.client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1" }
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            yield return new TestUser()
            {
                SubjectId = "1",
                Username = "alice",
                Password = "password"
            };

            yield return new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "password"
            };
        }
    }
}
