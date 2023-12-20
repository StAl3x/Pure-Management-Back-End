using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class fixUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserWarehouseTable_WarehouseId",
                table: "UserWarehouseTable");

            migrationBuilder.CreateIndex(
                name: "IX_UserWarehouseTable_WarehouseId",
                table: "UserWarehouseTable",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserWarehouseTable_WarehouseId",
                table: "UserWarehouseTable");

            migrationBuilder.CreateIndex(
                name: "IX_UserWarehouseTable_WarehouseId",
                table: "UserWarehouseTable",
                column: "WarehouseId",
                unique: true);
        }
    }
}
