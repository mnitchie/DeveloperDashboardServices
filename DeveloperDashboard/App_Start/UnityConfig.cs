using DeveloperDashboardIdentity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace DeveloperDashboard
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();

			container.RegisterType<IAuthRepository, AuthRepository>();
			container.RegisterType<IdentityDbContext<IdentityUser>, AuthContext>();
			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver( container );
		}
	}
}