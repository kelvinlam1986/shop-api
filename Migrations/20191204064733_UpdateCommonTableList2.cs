using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApi.Migrations
{
    public partial class UpdateCommonTableList2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(3)", nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTypes", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierTypes");
        }
    }
}
