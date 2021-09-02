using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Xunit;

namespace MicrosoftGraphApi
{
    public class UnitTest
    {
        [Fact]
        public async Task UpdateUser()
        {
            var scopes = new[] { ".default" };
            var tenantId = "{tenantId}";
            var clientId = "{clientId}";
            var clientSecret = "{clientSecret}";

            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret, options);

            var microsoftGraphApi = new GraphServiceClient(clientSecretCredential, scopes);

            var patchUser = new Microsoft.Graph.User()
            {
                Surname = "Some Surname",
                GivenName = "Some GivenName",
                StreetAddress = "1111 8th Street",
                City = "El Dorado",
                Country = "Rawanda",
                State = "Mumbai",
                PostalCode = "7777777"
            };

            var updatedUser = await microsoftGraphApi.Users["{User's ObjectId}"]
                .Request().UpdateAsync(patchUser);


            Assert.True(updatedUser != null, "User is null");
            Assert.True(updatedUser.Surname == patchUser.Surname, "Surname is not correct");
            Assert.True(updatedUser.GivenName == patchUser.GivenName, "GivenName is not correct");
            Assert.True(updatedUser.StreetAddress == patchUser.StreetAddress, "StreetAddress is not correct");
            Assert.True(updatedUser.City == patchUser.City, "City is not correct");
            Assert.True(updatedUser.Country == patchUser.Country, "Country is not correct");
            Assert.True(updatedUser.State == patchUser.State, "State is not correct");
            Assert.True(updatedUser.PostalCode == patchUser.PostalCode, "PostalCode is not correct");
        }
    }
}
