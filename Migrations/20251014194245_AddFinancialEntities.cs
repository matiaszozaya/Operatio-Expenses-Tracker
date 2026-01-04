using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesTracker.Migrations
{
	/// <inheritdoc />
	public partial class AddFinancialEntities : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "FinancialEntityId",
				table: "Expenses",
				type: "INTEGER",
				nullable: true);

			migrationBuilder.AddColumn<bool>(
				name: "IsPaid",
				table: "Expenses",
				type: "INTEGER",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AddColumn<bool>(
				name: "IsTransferred",
				table: "Expenses",
				type: "INTEGER",
				nullable: false,
				defaultValue: false);

			migrationBuilder.CreateTable(
				name: "FinancialEntities",
				columns: table => new
				{
					Id = table.Column<int>(type: "INTEGER", nullable: false)
						.Annotation("Sqlite:Autoincrement", true),
					Name = table.Column<string>(type: "TEXT", nullable: false),
					Type = table.Column<int>(type: "INTEGER", nullable: false),
					IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FinancialEntities", x => x.Id);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Expenses_FinancialEntityId",
				table: "Expenses",
				column: "FinancialEntityId");

			migrationBuilder.AddForeignKey(
				name: "FK_Expenses_FinancialEntities_FinancialEntityId",
				table: "Expenses",
				column: "FinancialEntityId",
				principalTable: "FinancialEntities",
				principalColumn: "Id");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
				name: "FK_Expenses_FinancialEntities_FinancialEntityId",
				table: "Expenses");

			migrationBuilder.DropTable(
				name: "FinancialEntities");

			migrationBuilder.DropIndex(
				name: "IX_Expenses_FinancialEntityId",
				table: "Expenses");

			migrationBuilder.DropColumn(
				name: "FinancialEntityId",
				table: "Expenses");

			migrationBuilder.DropColumn(
				name: "IsPaid",
				table: "Expenses");

			migrationBuilder.DropColumn(
				name: "IsTransferred",
				table: "Expenses");
		}
	}
}
