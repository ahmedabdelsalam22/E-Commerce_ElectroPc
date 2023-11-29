using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectroPc_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modifyPrdImageProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BatteryLifeHours", "Brand", "Dimensions", "DisplayResolution", "DisplaySizeInches", "GraphicsCard", "ImageUrl", "Name", "OperatingSystem", "Processor", "RamSizeGB", "StorageCapacityGB", "StorageType", "WeightKg" },
                values: new object[,]
                {
                    { 1, 6.5, "Brand 1", "15 x 10 x 1 inches", "1920x1080", 15.6, "Graphics Card 1", "https://picsum.photos/200/300", "Product 1", "Windows 10", "Processor 1", 8, 256, "SSD", 1.8 },
                    { 10, 8.0, "Brand 10", "13 x 9 x 1 inches", "1366x768", 14.0, "Graphics Card 10", "https://picsum.photos/200/300", "Product 10", "Windows 10", "Processor 10", 16, 512, "HDD", 2.0 }
                });
        }
    }
}
