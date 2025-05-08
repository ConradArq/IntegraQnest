using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace IntegraQnest.Client.Pages._Base
{
    public abstract class ProtectedPageBase : ComponentBase
    {
        [Inject] protected NavigationManager Navigation { get; set; } = default!;
        [Inject] protected AuthenticationStateProvider AuthProvider { get; set; } = default!;

        protected abstract string RequiredRole { get; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (!user.Identity?.IsAuthenticated ?? true || !user.IsInRole(RequiredRole))
            {
                Navigation.NavigateTo("/login", forceLoad: true);
            }
        }
    }

}
