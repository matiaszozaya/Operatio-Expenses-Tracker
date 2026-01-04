using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
	public partial class AddUSDRateToExpense : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<decimal>(
				name: "USDRate",
				table: "Expenses",
				type: "TEXT",
				nullable: false,
				defaultValue: 0m);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "USDRate",
				table: "Expenses");
		}
	}
}
