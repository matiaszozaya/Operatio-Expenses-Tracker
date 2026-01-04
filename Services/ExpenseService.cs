using Microsoft.EntityFrameworkCore;
using ExpensesTracker.Data;

namespace ExpensesTracker.Services
{
	public class ExpenseService
	{
		private readonly AppDbContext _db;

		public ExpenseService(AppDbContext db) { _db = db; }

		public async Task<List<FinancialEntity>> GetFinancialEntitiesAsync()
			=> await _db.FinancialEntities.Where(e => e.IsActive).OrderBy(e => e.Name).ToListAsync();

		public async Task<List<FinancialEntity>> GetFinancialEntitiesByTypeAsync(EntityType type)
			=> await _db.FinancialEntities.Where(e => e.IsActive && e.Type == type).OrderBy(e => e.Name).ToListAsync();

		public async Task<FinancialEntity?> GetFinancialEntityAsync(int id)
			=> await _db.FinancialEntities.FindAsync(id);

		public async Task<List<Expense>> GetByUserAsync(int userId)
			=> await _db.Expenses
				.Include(e => e.FinancialEntity)
				.Where(e => e.UserId == userId)
				.OrderByDescending(e => e.Date)
				.ToListAsync();

		public async Task<Expense?> GetAsync(int id)
			=> await _db.Expenses
				.Include(e => e.FinancialEntity)
				.FirstOrDefaultAsync(e => e.Id == id);

		public async Task AddAsync(Expense expense)
		{
			_db.Expenses.Add(expense);
			await _db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Expense expense)
		{
			_db.Expenses.Update(expense);
			await _db.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var e = await _db.Expenses.FindAsync(id);
			if (e == null) return;
			_db.Expenses.Remove(e);
			await _db.SaveChangesAsync();
		}
	}
}
