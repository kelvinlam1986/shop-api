using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class PurchaseInvoiceDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BranchId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ImportTaxtRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    InvoiceId = table.Column<string>(type: "varchar(10)", nullable: false),
                    InvoiceSystemId = table.Column<int>(nullable: false),
                    OrdinalNumber = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    VATRate = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_PurchaseInvoices_InvoiceSystemId",
                        column: x => x.InvoiceSystemId,
                        principalTable: "PurchaseInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_BranchId",
                table: "PurchaseInvoiceDetails",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_InvoiceSystemId",
                table: "PurchaseInvoiceDetails",
                column: "InvoiceSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_ProductId",
                table: "PurchaseInvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_InvoiceId_OrdinalNumber",
                table: "PurchaseInvoiceDetails",
                columns: new[] { "InvoiceId", "OrdinalNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoiceDetails");
        }
    }
}
