using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElectroPc_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addProductAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RamSizeGB = table.Column<int>(type: "int", nullable: false),
                    StorageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageCapacityGB = table.Column<int>(type: "int", nullable: false),
                    DisplaySizeInches = table.Column<double>(type: "float", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraphicsCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryLifeHours = table.Column<double>(type: "float", nullable: false),
                    WeightKg = table.Column<double>(type: "float", nullable: false),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsTouchscreen = table.Column<bool>(type: "bit", nullable: false),
                    HasWebcam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BatteryLifeHours", "Brand", "Dimensions", "DisplayResolution", "DisplaySizeInches", "GraphicsCard", "HasWebcam", "IsTouchscreen", "Name", "OperatingSystem", "Processor", "RamSizeGB", "StorageCapacityGB", "StorageType", "WeightKg" },
                values: new object[,]
                {
                    { 1, 6.5, "Brand 1", "15 x 10 x 1 inches", "1920x1080", 15.6, "Graphics Card 1", true, true, "Product 1", "Windows 10", "Processor 1", 8, 256, "SSD", 1.8 },
                    { 10, 8.0, "Brand 10", "13 x 9 x 1 inches", "1366x768", 14.0, "Graphics Card 10", true, false, "Product 10", "Windows 10", "Processor 10", 16, 512, "HDD", 2.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
