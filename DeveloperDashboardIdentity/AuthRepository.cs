﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace DeveloperDashboardIdentity
{
	public interface IAuthRepository
	{
		Task<IdentityResult> RegisterUser( UserModel userModel );
		Task<IdentityUser> FindUser( string userName, string password );
	}

	public class AuthRepository : IAuthRepository, IDisposable
	{
		private IdentityDbContext<IdentityUser> _ctx;

		private UserManager<IdentityUser> _userManager;

		public AuthRepository( IdentityDbContext<IdentityUser> context )
		{
			_ctx = context;
			_userManager = new UserManager<IdentityUser>( new UserStore<IdentityUser>( _ctx ) );
		}

		public async Task<IdentityResult> RegisterUser( UserModel userModel )
		{
			IdentityUser user = new IdentityUser
			{
				UserName = userModel.UserName
			};

			var result = await _userManager.CreateAsync( user, userModel.Password );

			return result;
		}

		public async Task<IdentityUser> FindUser( string userName, string password )
		{
			IdentityUser user = await _userManager.FindAsync( userName, password );

			return user;
		}

		public void Dispose()
		{
			_ctx.Dispose();
			_userManager.Dispose();

		}
	}
}
