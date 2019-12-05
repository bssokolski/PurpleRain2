using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PurpleRain2.WebAPI.Startup))]
namespace PurpleRain2.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
