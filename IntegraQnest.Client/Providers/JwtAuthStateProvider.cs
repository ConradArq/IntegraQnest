using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace IntegraQnest.Client.Providers
{
    public class JwtAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        public const string TokenKey = "authToken";

        public JwtAuthStateProvider(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsync<string>(TokenKey);

            if (string.IsNullOrWhiteSpace(token))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
            if (jwt.ValidTo < DateTime.UtcNow)
            {
                await _localStorage.RemoveItemAsync(TokenKey);
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var identity = new ClaimsIdentity(jwt.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public async Task NotifyUserAuthenticationAsync(string token)
        {
            await _localStorage.SetItemAsync(TokenKey, token);
            var identity = new ClaimsIdentity(new JwtSecurityTokenHandler().ReadJwtToken(token).Claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task NotifyUserLogoutAsync()
        {
            await _localStorage.RemoveItemAsync(TokenKey);
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
