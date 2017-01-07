using Microsoft.AspNet.Identity.EntityFramework;

namespace DeveloperDashboard.Models.Identity.EntityFramework
{
	public class AuthContext : IdentityDbContext<IdentityUser>
	{
		public AuthContext()
			: base( "AuthContext" )
		{

		}
	}
}