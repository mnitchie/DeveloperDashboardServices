using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup( typeof( DeveloperDashboard.Startup ) )]
namespace DeveloperDashboard
{
	public class Startup
	{
		public void Configuration( IAppBuilder app )
		{
			var config = new HttpConfiguration();
			WebApiConfig.Register( config );
			UnityConfig.RegisterComponents();
			app.UseWebApi( config );
		}

	}
}