using DeveloperDashboard.ActionFilters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace DeveloperDashboard
{
	public static class WebApiConfig
	{
		public static void Register( HttpConfiguration config )
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();
			ConfigureJsonFormatting( config );
			AddFilters( config );

			//config.Routes.MapHttpRoute( // using attribute routing (see above) so don't need
			//	name: "DefaultApi",
			//	routeTemplate: "api/{controller}/{id}",
			//	defaults: new { id = RouteParameter.Optional }
			//);


		}

		private static void ConfigureJsonFormatting( HttpConfiguration config )
		{
			var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
			jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

			var settings = jsonFormatter.SerializerSettings;
			settings.Formatting = Formatting.Indented;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
		}

		private static void AddFilters( HttpConfiguration config )
		{
			config.Filters.Add( new ValidateModelAttribute() );
		}
	}
}
