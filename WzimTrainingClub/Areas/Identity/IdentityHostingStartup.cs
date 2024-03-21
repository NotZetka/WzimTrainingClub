[assembly: HostingStartup(typeof(WzimTrainingClub.Areas.Identity.IdentityHostingStartup))]
namespace WzimTrainingClub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}