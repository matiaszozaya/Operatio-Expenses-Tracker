using ExpensesTracker.Data;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Services
{
	public class AuthService
	{
		private readonly AppDbContext _db;
		private readonly ProtectedSessionStorage _session;
		public event Action? AuthChanged;
		private readonly ILogger<AuthService> _logger;

		public AuthService(AppDbContext db, ProtectedSessionStorage session, ILogger<AuthService> logger)
		{
			_db = db;
			_session = session;
			_logger = logger;
		}

		public async Task<(bool ok, string? error)> RegisterAsync(string username, string password)
		{
			try
			{
				username = username.Trim();
				if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
					return (false, "Username and password are required");

				if (await _db.Users.AnyAsync(u => u.Username == username))
				{
					_logger.LogInformation("Register failed: username {User} already taken", username);
					return (false, "Username already taken");
				}

				var user = new User { Username = username, PasswordHash = BCrypt.Net.BCrypt.HashPassword(password) };
				_db.Users.Add(user);
				await _db.SaveChangesAsync();
				await _session.SetAsync("userId", user.Id);
				_logger.LogInformation("User registered: {UserId} ({User})", user.Id, user.Username);
				AuthChanged?.Invoke();
				return (true, null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error during registration for user {User}", username);
				return (false, "An error occurred during registration");
			}
		}

		public async Task<(bool ok, string? error)> LoginAsync(string username, string password)
		{
			try
			{
				var user = await _db.Users.SingleOrDefaultAsync(u => u.Username == username);
				if (user == null)
				{
					_logger.LogInformation("Login failed for user {User}: not found", username);
					return (false, "Invalid username or password");
				}
				if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
				{
					_logger.LogInformation("Login failed for user {User}: invalid password", username);
					return (false, "Invalid username or password");
				}
				await _session.SetAsync("userId", user.Id);
				_logger.LogInformation("User logged in: {UserId} ({User})", user.Id, user.Username);
				AuthChanged?.Invoke();
				return (true, null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error during login for user {User}", username);
				return (false, "An error occurred during login");
			}
		}

		public async Task LogoutAsync()
		{
			await _session.DeleteAsync("userId");
			AuthChanged?.Invoke();
		}

		public async Task<User?> GetCurrentUserAsync()
		{
			var res = await _session.GetAsync<int>("userId");
			if (!res.Success) return null;
			return await _db.Users.FindAsync(res.Value);
		}
	}
}
