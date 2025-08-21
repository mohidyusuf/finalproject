using BlazorGoogleMongo.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace CarRentalApp.Services
{
    public class BusinessCheckService
    {
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly IAboutShowroomService _aboutShowroomService;

        public BusinessCheckService(
            AuthenticationStateProvider authStateProvider,
            IAboutShowroomService aboutShowroomService)
        {
            _authStateProvider = authStateProvider;
            _aboutShowroomService = aboutShowroomService;
        }

        public async Task<bool> CheckUserAuthenticated()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            return authState.User.Identity?.IsAuthenticated ?? false;
        }

        public async Task<bool> CheckBusinessExists()
        {
            var userId = await GetCurrentUserIdAsync();
            if (string.IsNullOrEmpty(userId))
                return false;

            var business = await _aboutShowroomService.GetShowroomById(userId);
            return business?.Id != null; // Returns true only if business exists with valid ID
        }

        public async Task<string> GetBusinessId()
        {
            var client = await _authStateProvider.GetAuthenticationStateAsync();
            var user = client.User;
            var UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            string BusinessId = await _aboutShowroomService.GetBusinessIdByUserId(UserId);
            return BusinessId ?? string.Empty; // Return empty string if no business found
        }

        public async Task<string?> GetCurrentUserIdAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            return authState.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        // BusinessCheckService.cs

        public async Task<string> GetBusinessIdAsync()
        {
            var client = await _authStateProvider.GetAuthenticationStateAsync();
            var user = client.User;
            var UserId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
            string BusinessId = await _aboutShowroomService.GetBusinessIdByUserId(UserId);
            return BusinessId ?? string.Empty; // Return empty string if no business found
        }

    }
}