using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Data
{
	public enum EntityType
	{
		Bank,
		DigitalWallet
	}

	public enum PaymentMethod
	{
		Cash,
		Entity
	}

	public class FinancialEntity
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = null!;
		public EntityType Type { get; set; }
		public bool IsActive { get; set; } = true;
		public List<Expense> Expenses { get; set; } = new();
	}

	public class User
	{
		public int Id { get; set; }
		[Required]
		public string Username { get; set; } = null!;
		[Required]
		public string PasswordHash { get; set; } = null!;
		public List<Expense> Expenses { get; set; } = new();
	}

	public class Expense
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = null!;
		// Notes removed per feature request
		public decimal Amount { get; set; }
		public decimal USDRate { get; set; }
		// 0 = ARS (default), 1 = USD
		public int StoredCurrency { get; set; } = 0;
		public DateTime Date { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }
		public int? FinancialEntityId { get; set; }
		public FinancialEntity? FinancialEntity { get; set; }
		public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Entity;
		public bool IsTransferred { get; set; }
		public bool IsPaid { get; set; }
	}
}
