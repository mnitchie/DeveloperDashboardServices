using Microsoft.AspNet.Identity.EntityFramework;

namespace DeveloperDashboard.API.Models.Auth
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext() : base( "AuthContext" )
		{

		}
	}
}