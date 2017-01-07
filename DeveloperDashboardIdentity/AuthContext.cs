using Microsoft.AspNet.Identity.EntityFramework;

namespace DeveloperDashboardIdentity
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext( string connectionString )
			: base( connectionString )
		{
			// Empty
		}
	}
}
