using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PhishyBank.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace PhishyBank.Server.State
{
    public class StateHelper
    {
        [Inject]
        private ProtectedSessionStorage ProtectedSessionStore { get; set; }
        private NavigationManager NavManager { get; set; }

        public StateHelper(ProtectedSessionStorage protectedSessionStore, NavigationManager navManager)
        {
            ProtectedSessionStore = protectedSessionStore;
            NavManager = navManager;
        }

        public async Task<JwtSecurityToken?> GetJwtToken() {
            string? token = (await ProtectedSessionStore.GetAsync<string>("jwtToken")).Value;
            if (token == null) return null;

            JwtSecurityToken? jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            return jwtToken;
        }

        public async Task<User?> GetUser()
        {
            var jwtToken = await GetJwtToken();
            if (jwtToken == null) return null;

            var endpoint = new Uri(
            new Uri(NavManager.BaseUri), // base URI from current context
            $"/api/users/{jwtToken!.Subject}" // address relative to the base URI, use / if needed
            ).ToString();
            var response = await new HttpClient().GetAsync(endpoint);

            // var test = await response.Content.ReadAsStringAsync();
            var contentStream = await response.Content.ReadAsStreamAsync();
            var deserializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var loggedInUser = await JsonSerializer.DeserializeAsync
            <User>(contentStream, deserializerOptions);

            if (loggedInUser != null)
            {
                //Console.WriteLine(JsonSerializer.Serialize(currentUser));
                return loggedInUser;
            } else
            {
                return null;
            }
        }

        public async Task<List<Account>> GetAccounts()
        {
            var userAccounts = new List<Account>();
            var jwtToken = await GetJwtToken();

            if (jwtToken == null) return userAccounts;

            var endpoint = new Uri(
            new Uri(NavManager.BaseUri),
            $"/api/users/{jwtToken.Subject}/accounts"
            ).ToString();
            var response = await new HttpClient().GetAsync(endpoint);

            var contentStream = await response.Content.ReadAsStreamAsync();
            var deserializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var accounts = await JsonSerializer.DeserializeAsync
            <List<Account>>(contentStream, deserializerOptions);
            // Console.WriteLine(JsonSerializer.Serialize(accounts));

            if (accounts != null)
            {
                // NOTE Assuming one user has only one account, for now...
                userAccounts = accounts;
                // accountBalance = getAccountBalance(userAccount);
            }

            return userAccounts;
        }
    }

}