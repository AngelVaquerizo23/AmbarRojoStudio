using BlazorCRUD.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorCRUD.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5264") });

builder.Services.AddScoped<IRolesServices, RolesServices>();
builder.Services.AddScoped<IPersonasSevices, PersonasServices>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();