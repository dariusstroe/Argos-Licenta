using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Argos.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Descriere1", "https://mcdn.elefant.ro/mnresize/350/350/is/product-images/cartero/120e608a/8874/4e34/8c0b/94ec3204b406/120e608a-8874-4e34-8c0b-94ec3204b406_1.jpg", 9.99m, "Carte1" },
                    { 2, "Descriere2", "https://mcdn.elefant.ro/mnresize/350/350/images/63/2010963/atomic-habits-o-cale-usoara-si-eficienta-de-a-ti-forma-obiceiuri-bune-si-a-scapa-de-cele-proaste_1_fullsize.jpg", 19.99m, "Carte2" },
                    { 3, "Descriere3", "https://mcdn.elefant.ro/mnresize/350/350/images/90/276490/ugly-love-despre-fata-urata-a-iubirii_1_fullsize.jpg", 29.99m, "Carte3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
