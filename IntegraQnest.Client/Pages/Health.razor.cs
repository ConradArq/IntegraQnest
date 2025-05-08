using IntegraQnest.Client.Pages._Base;
using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http.Json;

namespace IntegraQnest.Client.Pages
{
    public partial class Health : ProtectedPageBase
    {
        [Inject] public IHttpClientFactory ClientFactory { get; set; } = default!;

        [Inject] public NotificationService NotificationService { get; set; } = default!;

        private string? status;
        protected override string RequiredRole => "Admin";

        private async Task CheckHealth()
        {
            var client = ClientFactory.CreateClient("IntegraQnest.ServerAPI");

            try
            {
                var response = await client.GetFromJsonAsync<HealthResponse>("api/health");
                status = response?.Status ?? "Unknown";

                var isHealthy = status.Equals("Healthy", StringComparison.OrdinalIgnoreCase);

                NotificationService.Notify(new NotificationMessage
                {
                    Severity = isHealthy ? NotificationSeverity.Success : NotificationSeverity.Error,
                    Summary = "System Health",
                    Detail = $"Server status: {status}",
                    Duration = 4000
                });
            }
            catch
            {
                status = "Unreachable";
            }
        }

        private class HealthResponse
        {
            public string Status { get; set; } = string.Empty;
        }
    }
}