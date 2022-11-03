using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASM;
using BlazorWASM.Auth;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddScoped<IPostService,PostHttpClient>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped(sp => new HttpClient
    { BaseAddress = new Uri("https://localhost:7188") });
await builder.Build().RunAsync();