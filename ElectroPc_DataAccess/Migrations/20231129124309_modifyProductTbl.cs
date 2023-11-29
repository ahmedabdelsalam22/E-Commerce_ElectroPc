using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroPc_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyProductTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasWebcam",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsTouchscreen",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasWebcam",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTouchscreen",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "HasWebcam", "IsTouchscreen" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "HasWebcam", "IsTouchscreen" },
                values: new object[] { true, false });
        }
    }
}
