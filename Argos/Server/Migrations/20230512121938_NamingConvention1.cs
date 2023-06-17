using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Argos.Server.Migrations
{
	/// <inheritdoc />
	public partial class NamingConvention1 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.RenameTable(
				name: "ProductTypes",
				newName: "ItemTypes");

			migrationBuilder.RenameTable(
				name: "ProductVariants",
				newName: "ItemVariants");

		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
