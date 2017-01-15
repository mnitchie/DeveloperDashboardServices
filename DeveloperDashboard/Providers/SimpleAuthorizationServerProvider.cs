using DeveloperDashboard.Models.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeveloperDashboard.Providers
{
	public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
	{
		public override async Task ValidateClientAuthentication( OAuthValidateClientAuthenticationContext context )
		{
			context.Validated();
		}

		public override async Task GrantResourceOwnerCredentials( OAuthGrantResourceOwnerCredentialsContext context )
		{

			context.OwinContext.Response.Headers.Add( "Access-Control-Allow-Origin", new[] { "*" } );

			using ( var repo = new AuthRepository() ) // DI?
			{
				var user = await repo.FindUser( context.UserName, context.Password );

				if ( user == null )
				{
					context.SetError( "invalid_grant", "The Username or password is incorrect." );
					return;
				}
			}

			var identity = new ClaimsIdentity( context.Options.AuthenticationType );
			identity.AddClaim( new Claim( "sub", context.UserName ) );
			identity.AddClaim( new Claim( "role", "user" ) );
			// can add more claims here

			context.Validated( identity );
		}
	}
}