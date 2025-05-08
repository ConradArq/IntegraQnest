using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using IntegraQnest.Client;
using Radzen;
using IntegraQnest.Client.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using IntegraQnest.Client.Providers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<UserState>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<JwtAuthStateProvider>());

builder.Services.AddHttpClient("IntegraQnest.ServerAPI", client =>
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
