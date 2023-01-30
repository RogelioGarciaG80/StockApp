using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyOrder",
                columns: table => new
                {
                    BuyOrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSymbol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateAndTimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyOrder", x => x.BuyOrderID);
                });

            migrationBuilder.CreateTable(
                name: "SellOrder",
                columns: table => new
                {
                    SellOrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockSymbol = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateAndTimeOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellOrder", x => x.SellOrderID);
                });

            migrationBuilder.InsertData(
                table: "BuyOrder",
                columns: new[] { "BuyOrderID", "DateAndTimeOfOrder", "Price", "Quantity", "StockName", "StockSymbol" },
                values: new object[,]
                {
                    { new Guid("3a09d4e8-97da-48e2-a2c7-2df312b0c851"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.5, 1L, "META", "META" },
                    { new Guid("3c153be8-933f-4119-8890-fb47c24a0e86"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 141.86000000000001, 1L, "Apple", "AAPL" },
                    { new Guid("417e0310-ce0d-4c7f-a2e1-f8a02ddf8da8"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 144.43000000000001, 1L, "Tesla", "TSLA" },
                    { new Guid("b1cb2909-0265-4ab7-ad5c-6bdccdbdb191"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 240.61000000000001, 1L, "Microsoft", "MSFT" }
                });

            migrationBuilder.InsertData(
                table: "SellOrder",
                columns: new[] { "SellOrderID", "DateAndTimeOfOrder", "Price", "Quantity", "StockName", "StockSymbol" },
                values: new object[,]
                {
                    { new Guid("2b8a325a-afaa-4b34-ac9b-5992b48ca897"), new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 367.95999999999998, 2L, "Netflix, Inc. ", "NFLX" },
                    { new Guid("a684ccee-322f-4b23-80e1-8ecd8c113300"), new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 490.88, 1L, "Costco Wholesale Corporation", "COST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyOrder");

            migrationBuilder.DropTable(
                name: "SellOrder");
        }
    }
}
