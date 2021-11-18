using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PieGallery.Areas.Identity.IdentityHostingStartup))]
namespace PieGallery.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}