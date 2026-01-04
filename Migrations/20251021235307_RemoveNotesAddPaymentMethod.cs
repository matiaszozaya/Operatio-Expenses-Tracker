using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
	/// <inheritdoc />
	public partial class RemoveNotesAddPaymentMethod : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "Notes",
				table: "Expenses");

			migrationBuilder.AddColumn<int>(
				name: "PaymentMethod",
				table: "Expenses",
				type: "INTEGER",
				nullable: false,
				defaultValue: 0);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "PaymentMethod",
				table: "Expenses");

			migrationBuilder.AddColumn<string>(
				name: "Notes",
				table: "Expenses",
				type: "TEXT",
				nullable: true);
		}
	}
}
