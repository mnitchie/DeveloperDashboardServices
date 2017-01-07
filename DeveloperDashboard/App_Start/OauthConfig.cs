using DeveloperDashboard.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace DeveloperDashboard.App_Start
{
	public class OAuthConfig
	{
		public static void ConfigureOAuth( IAppBuilder app )
		{
			var oauthServerOptions = new OAuthAuthorizationServerOptions()
			{
				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString( "/token" ),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays( 1 ),
				Provider = new SimpleAuthorizationServerProvider()
			};

			// Token Generation
			app.UseOAuthAuthorizationServer( oauthServerOptions );
			app.UseOAuthBearerAuthentication( new OAuthBearerAuthenticationOptions() );

		}
	}
}