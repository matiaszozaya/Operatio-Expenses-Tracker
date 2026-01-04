using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using ExpensesTracker.Data;

namespace ExpensesTracker.Services
{
	public class SimpleAuthStateProvider : AuthenticationStateProvider
	{
		private readonly AppDbContext _db;
		private readonly ProtectedSessionStorage _session;
		private readonly AuthService _authService;

		public SimpleAuthStateProvider(AppDbContext db, ProtectedSessionStorage session, AuthService authService)
		{
			_db = db;
			_session = session;
			_authService = authService;
			_authService.AuthChanged += NotifyAuthChanged;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			try
			{
				var res = await _session.GetAsync<int>("userId");
				if (!res.Success)
				{
					return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
				}
				var user = await _db.Users.FindAsync(res.Value);
				if (user == null)
				{
					return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
				}
				var claims = new[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Name, user.Username)
				};
				var identity = new ClaimsIdentity(claims, "CustomAuth");
				return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
			}
			catch (InvalidOperationException)
			{
				// Return anonymous during pre-rendering
				return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
			}
		}

		public void NotifyAuthChanged()
		{
			NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}
	}
}
