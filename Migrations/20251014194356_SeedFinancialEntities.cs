using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesTracker.Migrations
{
	/// <inheritdoc />
	public partial class SeedFinancialEntities : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.InsertData(
				table: "FinancialEntities",
				columns: new[] { "Id", "IsActive", "Name", "Type" },
				values: new object[,]
				{
					{ 1, true, "Banco de la Nación Argentina", 0 },
					{ 2, true, "Banco Provincia de Buenos Aires", 0 },
					{ 3, true, "Banco de Galicia y Buenos Aires", 0 },
					{ 4, true, "Banco de la Ciudad de Buenos Aires", 0 },
					{ 5, true, "Banco Patagonia", 0 },
					{ 6, true, "Banco Macro", 0 },
					{ 7, true, "Banco Santander Argentina", 0 },
					{ 8, true, "Banco BBVA Argentina", 0 },
					{ 9, true, "Banco Credicoop Cooperativo Limitado", 0 },
					{ 10, true, "Brubank S.A.U.", 0 },
					{ 11, true, "Ualá Bank S.A.U.", 0 },
					{ 12, true, "Banco Hipotecario S.A.", 0 },
					{ 13, true, "Banco de Corrientes S.A.", 0 },
					{ 14, true, "Banco de Córdoba S.A.", 0 },
					{ 15, true, "Banco BICA S.A.", 0 },
					{ 16, true, "Mercado Pago", 1 },
					{ 17, true, "Ualá", 1 },
					{ 18, true, "Naranja X", 1 },
					{ 19, true, "Cuenta DNI", 1 },
					{ 20, true, "Personal Pay", 1 },
					{ 21, true, "BNA+", 1 },
					{ 22, true, "MODO", 1 },
					{ 23, true, "Prex", 1 },
					{ 24, true, "Claro Pay", 1 },
					{ 25, true, "Lemon Cash", 1 },
					{ 26, true, "AstroPay", 1 },
					{ 27, true, "Moni", 1 },
					{ 28, true, "PayMovil", 1 },
					{ 29, true, "Pluspagos", 1 },
					{ 30, true, "Resimple", 1 },
					{ 31, true, "TodoPago", 1 },
					{ 32, true, "Valepei", 1 },
					{ 33, true, "Billetera País", 1 },
					{ 34, true, "Xcoop", 1 }
				});
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 2);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 3);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 4);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 5);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 6);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 7);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 8);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 9);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 10);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 11);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 12);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 13);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 14);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 15);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 16);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 17);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 18);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 19);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 20);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 21);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 22);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 23);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 24);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 25);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 26);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 27);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 28);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 29);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 30);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 31);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 32);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 33);

			migrationBuilder.DeleteData(
				table: "FinancialEntities",
				keyColumn: "Id",
				keyValue: 34);
		}
	}
}
