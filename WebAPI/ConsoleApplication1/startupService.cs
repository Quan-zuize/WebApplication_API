using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConsoleApplication1
{
    public class startupService
    {
        public void Configuration(IAppBuilder appbuilder)
        {
            //System.Web.Http
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(name: "Quan",
                routeTemplate: "Quan/{Controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            appbuilder.UseWebApi(config);
        }
    }
}
