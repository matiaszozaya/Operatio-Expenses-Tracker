using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Data
{
    public enum EntityType
    {
        Bank,
        DigitalWallet
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
        public string? Notes { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? FinancialEntityId { get; set; }
        public FinancialEntity? FinancialEntity { get; set; }
        public bool IsTransferred { get; set; }
        public bool IsPaid { get; set; }
    }
}
