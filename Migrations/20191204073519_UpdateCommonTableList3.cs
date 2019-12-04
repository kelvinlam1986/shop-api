using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class UpdateCommonTableList3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceBatches",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(3)", nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BatchDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceBatches", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoiceBatches");
        }
    }
}
