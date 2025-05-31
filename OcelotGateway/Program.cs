using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //  Load ocelot.json before building the app
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            // Add Ocelot
            builder.Services.AddOcelot();

           

            var app = builder.Build();

        

            // Optional: only needed if using [Authorize]
            app.UseAuthorization();

            // Optional: Map controllers if any (can skip for pure gateway)
            app.MapControllers();

            //  Important: Run Ocelot middleware
            await app.UseOcelot();

            app.Run();
        }
    }
}
