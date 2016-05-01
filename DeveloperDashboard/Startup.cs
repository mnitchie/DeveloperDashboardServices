using DeveloperDashboard.API.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;

[assembly: OwinStartup( typeof( DeveloperDashboard.API.Startup ) )]
namespace DeveloperDashboard.API
{
	public class Startup
	{
		public void Configuration( IAppBuilder app )
		{
			ConfigureOAuth( app );
			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register( config );
			app.UseWebApi( config );
		}

		private void ConfigureOAuth( IAppBuilder app )
		{
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions() {
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString( "/token" ),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays( 1 ),
				Provider = new SimpleAuthorizationServerProvider()
			};

			app.UseOAuthAuthorizationServer( OAuthServerOptions );
			app.UseOAuthBearerAuthentication( new OAuthBearerAuthenticationOptions() );
		}
	}
}