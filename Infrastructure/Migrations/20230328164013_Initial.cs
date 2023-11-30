using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TotalAmount = table.Column<double>(type: "double", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<double>(type: "double", nullable: false),
                    IsSandwich = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFries = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDrink = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OrderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Created", "IsActive", "IsDrink", "IsFries", "IsSandwich", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("264fd9cd-ec97-44d0-840d-f67962d3761c"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, true, "X Egg", 4.5 },
                    { new Guid("357a5f62-89f9-4e68-80e1-a94be2fc06d3"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, true, "X Burguer", 5.0 },
                    { new Guid("51928c2f-2587-4489-8b81-b4291232c7ea"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, false, false, "Soft Drink", 2.5 },
                    { new Guid("8d26a9b2-774a-467b-a3ad-4f59bcc75bd2"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, true, "X Bacon", 7.0 },
                    { new Guid("eb673ac1-9dfb-46a0-815e-115dcb078668"), new DateTime(2023, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, true, false, "Fries", 2.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_OrderId",
                table: "Detail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_ProductId",
                table: "Detail",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
