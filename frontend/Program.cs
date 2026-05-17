using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using frontend;
using frontend.Security;
using Blazored.LocalStorage; 
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Localstorage
builder.Services.AddBlazoredLocalStorage();

//register injector
builder.Services.AddTransient<JwtHeaderHandler>();

//configure http Client - url backend
builder.Services.AddHttpClient("BackendAPI", client => 
    client.BaseAddress = new Uri("http://localhost:5296/")) 
    .AddHttpMessageHandler<JwtHeaderHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BackendAPI"));

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
