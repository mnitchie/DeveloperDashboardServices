using DeveloperDashboard.Models.Identity;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeveloperDashboard.Controllers
{
	[RoutePrefix( "api/Account" )] // TODO: configure 'api' somewhere, so this doesn't need to go in every controller?
	public class AccountController : ApiController
	{
		private readonly IAuthRepository _repo;

		public AccountController( IAuthRepository authRepository )
		{
			_repo = authRepository;
		}

		// POST api/Account/Register
		[AllowAnonymous]

		[Route( "" )] //TODO: Does "" need to be explicit here, or can I just leave out the attribute?
		[HttpPost]
		public async Task<IHttpActionResult> Register( UserModel userModel )
		{
			var result = await _repo.RegisterUser( userModel );

			var errorResult = GetErrorResult( result );

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
					foreach ( string error in result.Errors )
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
	}
}