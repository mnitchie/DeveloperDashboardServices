using Microsoft.AspNet.Identity.EntityFramework;

namespace DeveloperDashboardServices.Models.Auth
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext() : base( "AuthContext" )
		{
			// Empty
		}
	}
}