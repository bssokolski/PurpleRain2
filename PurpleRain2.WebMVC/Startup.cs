using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PurpleRain2.WebMVC.Startup))]
namespace PurpleRain2.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
