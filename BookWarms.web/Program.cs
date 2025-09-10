using BookWarms.web;
using BookWarms.web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BookWarms.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            var apiBase = new Uri("https://localhost:7222/");

            builder.Services.AddHttpClient<BooksApiClient>(c => c.BaseAddress = apiBase);
            builder.Services.AddHttpClient<UsersApiClient>(c => c.BaseAddress = apiBase);
            builder.Services.AddHttpClient<ReviewsApiClient>(c => c.BaseAddress = new Uri("https://localhost:7222/"));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}