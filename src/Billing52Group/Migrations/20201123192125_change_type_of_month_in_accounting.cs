using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing52Group.Migrations
{
    public partial class change_type_of_month_in_accounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "mm",
                table: "contractaccount",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "mm",
                table: "contractaccount",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
