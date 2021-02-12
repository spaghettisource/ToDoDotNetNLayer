using Microsoft.Owin;
using Owin;
using ToDoDotNet.App_Start;

namespace ToDoDotNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = SimpleInjectorInitializer.Initialize(app);
            ConfigureAuth(app, container);
        }
    }
}