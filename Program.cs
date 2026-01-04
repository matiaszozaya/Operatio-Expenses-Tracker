using ExpensesTracker.Data;
using ExpensesTracker.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=expenses.db"));
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddLogging(logging => logging.AddConsole());
builder.Services.AddScoped<DollarValues>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SimpleAuthStateProvider>(sp =>
	new SimpleAuthStateProvider(
		sp.GetRequiredService<AppDbContext>(),
		sp.GetRequiredService<ProtectedSessionStorage>(),
		sp.GetRequiredService<AuthService>()
	)
);
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<SimpleAuthStateProvider>());
builder.Services.AddScoped<ExpenseService>();
builder.Services.AddAuthorizationCore();

var app = builder.Build();

// Ensure database
try
{
	using (var scope = app.Services.CreateScope())
	{
		var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
		try
		{
			db.Database.Migrate();
			logger.LogInformation("Database migration completed successfully");
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "An error occurred while migrating the database");
			throw; // Re-throw to be caught by the outer try-catch
		}
	}
}
catch (Exception ex)
{
	if (app.Environment.IsDevelopment())
	{
		throw; // In development, let the exception bubble up
	}
	// In production, log the error but allow the app to start
	var logger = app.Services.GetRequiredService<ILogger<Program>>();
	logger.LogError(ex, "An error occurred while initializing the application");
}

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
else
{
	app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
