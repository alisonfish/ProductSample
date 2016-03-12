using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductSample.Startup))]
namespace ProductSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
