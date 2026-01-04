using Microsoft.EntityFrameworkCore;

namespace ExpensesTracker.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users => Set<User>();
		public DbSet<Expense> Expenses => Set<Expense>();
		public DbSet<FinancialEntity> FinancialEntities => Set<FinancialEntity>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(b =>
			{
				b.HasKey(u => u.Id);
				b.HasIndex(u => u.Username).IsUnique();
			});

			modelBuilder.Entity<Expense>(b =>
			{
				b.HasKey(e => e.Id);
				b.HasOne(e => e.User).WithMany(u => u.Expenses).HasForeignKey(e => e.UserId);
				b.HasOne(e => e.FinancialEntity).WithMany(f => f.Expenses).HasForeignKey(e => e.FinancialEntityId);
			});

			// Seed Banks
			modelBuilder.Entity<FinancialEntity>().HasData(
				new FinancialEntity { Id = 1, Name = "Banco de la Nación Argentina", Type = EntityType.Bank },
				new FinancialEntity { Id = 2, Name = "Banco Provincia de Buenos Aires", Type = EntityType.Bank },
				new FinancialEntity { Id = 3, Name = "Banco de Galicia y Buenos Aires", Type = EntityType.Bank },
				new FinancialEntity { Id = 4, Name = "Banco de la Ciudad de Buenos Aires", Type = EntityType.Bank },
				new FinancialEntity { Id = 5, Name = "Banco Patagonia", Type = EntityType.Bank },
				new FinancialEntity { Id = 6, Name = "Banco Macro", Type = EntityType.Bank },
				new FinancialEntity { Id = 7, Name = "Banco Santander Argentina", Type = EntityType.Bank },
				new FinancialEntity { Id = 8, Name = "Banco BBVA Argentina", Type = EntityType.Bank },
				new FinancialEntity { Id = 9, Name = "Banco Credicoop Cooperativo Limitado", Type = EntityType.Bank },
				new FinancialEntity { Id = 10, Name = "Brubank S.A.U.", Type = EntityType.Bank },
				new FinancialEntity { Id = 11, Name = "Ualá Bank S.A.U.", Type = EntityType.Bank },
				new FinancialEntity { Id = 12, Name = "Banco Hipotecario S.A.", Type = EntityType.Bank },
				new FinancialEntity { Id = 13, Name = "Banco de Corrientes S.A.", Type = EntityType.Bank },
				new FinancialEntity { Id = 14, Name = "Banco de Córdoba S.A.", Type = EntityType.Bank },
				new FinancialEntity { Id = 15, Name = "Banco BICA S.A.", Type = EntityType.Bank },

				// Digital Wallets
				new FinancialEntity { Id = 16, Name = "Mercado Pago", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 17, Name = "Ualá", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 18, Name = "Naranja X", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 19, Name = "Cuenta DNI", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 20, Name = "Personal Pay", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 21, Name = "BNA+", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 22, Name = "MODO", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 23, Name = "Prex", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 24, Name = "Claro Pay", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 25, Name = "Lemon Cash", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 26, Name = "AstroPay", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 27, Name = "Moni", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 28, Name = "PayMovil", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 29, Name = "Pluspagos", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 30, Name = "Resimple", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 31, Name = "TodoPago", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 32, Name = "Valepei", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 33, Name = "Billetera País", Type = EntityType.DigitalWallet },
				new FinancialEntity { Id = 34, Name = "Xcoop", Type = EntityType.DigitalWallet }
			);
		}
	}
}
