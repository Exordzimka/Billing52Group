using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing52Group.Migrations
{
    public partial class change_month_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "mm",
                table: "contractbalance",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "mm",
                table: "contractbalance",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
