using DeveloperDashboardServices.Models.Auth;
using DeveloperDashboardServices.Repositories.Auth;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeveloperDashboardServices.Controllers
{
	public class AccountController : ApiController
	{
		public AccountController()
		{
			//_repo = new AuthRepository(); yeah, no... use DI for this.
		}

		// POST api/Account/Register
		[AllowAnonymous]
		[Route( "Register" )]
		public async Task<IHttpActionResult> Register( User userModel )
		{
			if ( !ModelState.IsValid )
			{
				return BadRequest( ModelState );
			}

			IdentityResult result = await _repo.RegisterUser( userModel );

			IHttpActionResult errorResult = GetErrorResult( result );

			if ( errorResult != null )
			{
				return errorResult;
			}

			return Ok();
		}

		protected override void Dispose( bool disposing )
		{
			if ( disposing )
			{
				_repo.Dispose();
			}

			base.Dispose( disposing );
		}

		private IHttpActionResult GetErrorResult( IdentityResult result )
		{
			if ( result == null )
			{
				return InternalServerError();
			}

			if ( !result.Succeeded )
			{
				if ( result.Errors != null )
				{
					foreach ( var error in result.Errors )
					{
						ModelState.AddModelError( "", error );
					}
				}

				if ( ModelState.IsValid )
				{
					// No ModelState errors are available to send, so just return an empty BadRequest.
					return BadRequest();
				}

				return BadRequest( ModelState );
			}

			return null;
		}

		private readonly AuthRepository _repo;
	}
}