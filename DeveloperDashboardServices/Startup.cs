using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup( typeof( DeveloperDashboardServices.Startup ) )]
namespace DeveloperDashboardServices
{
	public class Startup
	{
		public void Configuration( IAppBuilder app )
		{
			// Used to configure routes etc...
			var config = new HttpConfiguration();
			WebApiConfig.Register( config );

			app.UseWebApi( config );
		}
	}
}
