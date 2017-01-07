using DeveloperDashboard.App_Start;
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
			OAuthConfig.ConfigureOAuth( app );
			WebApiConfig.Register( config );
			UnityConfig.RegisterComponents( config );

			app.UseCors( Microsoft.Owin.Cors.CorsOptions.AllowAll );
			app.UseWebApi( config );
		}

	}
}