using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElevenIsland.API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    idProduct = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ShortDescription = table.Column<string>(type: "TEXT", nullable: false),
                    FullDescription = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    OldPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.idProduct);
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductAttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductidProduct = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attribute_Products_ProductidProduct",
                        column: x => x.ProductidProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Src = table.Column<string>(type: "TEXT", nullable: false),
                    ProductidProduct = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Products_ProductidProduct",
                        column: x => x.ProductidProduct,
                        principalTable: "Products",
                        principalColumn: "idProduct");
                });

            migrationBuilder.CreateTable(
                name: "AttributeValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: true),
                    AttributeId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValue_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_ProductidProduct",
                table: "Attribute",
                column: "ProductidProduct");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValue_AttributeId",
                table: "AttributeValue",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductidProduct",
                table: "Image",
                column: "ProductidProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeValue");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
