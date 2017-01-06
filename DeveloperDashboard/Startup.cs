using Microsoft.Owin;
using Owin;

[assembly: OwinStartup( typeof( DeveloperDashboard.Startup ) )]
namespace DeveloperDashboard
{
	public class Startup
	{
		public void Configuration( IAppBuilder app )
		{
			System.Diagnostics.Debug.WriteLine( "Hello" );
		}

	}
}