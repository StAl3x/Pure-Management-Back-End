using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PricePerUnit",
                table: "ProductTable",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "ProductTable",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTable_CompanyTable_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "CompanyTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseTable_CompanyId",
                table: "WarehouseTable",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTable_CompanyId",
                table: "ProductTable",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTable_CompanyId",
                table: "UserTable",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTable_CompanyTable_CompanyId",
                table: "ProductTable",
                column: "CompanyId",
                principalTable: "CompanyTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseTable_CompanyTable_CompanyId",
                table: "WarehouseTable",
                column: "CompanyId",
                principalTable: "CompanyTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTable_CompanyTable_CompanyId",
                table: "ProductTable");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseTable_CompanyTable_CompanyId",
                table: "WarehouseTable");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "CompanyTable");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseTable_CompanyId",
                table: "WarehouseTable");

            migrationBuilder.DropIndex(
                name: "IX_ProductTable_CompanyId",
                table: "ProductTable");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProductTable");

            migrationBuilder.AlterColumn<float>(
                name: "PricePerUnit",
                table: "ProductTable",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }
    }
}
