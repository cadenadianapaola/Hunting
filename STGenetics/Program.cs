using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using STGenetics;
using MudBlazor.Services;
using STGenetics.Services;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7246") });
builder.Services.AddScoped<IAnimalService, AnimalService>();

builder.Services.AddMudServices();

//builder.Services.AddServerSideBlazor();




await builder.Build().RunAsync();
