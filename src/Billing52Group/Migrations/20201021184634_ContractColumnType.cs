using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing52Group.Migrations
{
    public partial class ContractColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "fc",
                table: "contract",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "fc",
                table: "contract",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
