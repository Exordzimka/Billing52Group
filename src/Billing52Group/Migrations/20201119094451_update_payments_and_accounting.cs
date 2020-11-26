using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing52Group.Migrations
{
    public partial class update_payments_and_accounting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "payment");

            migrationBuilder.AddColumn<int>(
                name: "activationtypeid",
                table: "tariffplan",
                nullable: true,
                defaultValueSql: "'0'");

            migrationBuilder.AddColumn<int>(
                name: "ActivationTypeId",
                table: "service",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "contractpayment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivationType",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationType", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tariffplan_activationtypeid",
                table: "tariffplan",
                column: "activationtypeid");

            migrationBuilder.CreateIndex(
                name: "IX_service_ActivationTypeId",
                table: "service",
                column: "ActivationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FKactivation2",
                table: "service",
                column: "ActivationTypeId",
                principalTable: "ActivationType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FKactivation1",
                table: "tariffplan",
                column: "activationtypeid",
                principalTable: "ActivationType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKactivation2",
                table: "service");

            migrationBuilder.DropForeignKey(
                name: "FKactivation1",
                table: "tariffplan");

            migrationBuilder.DropTable(
                name: "ActivationType");

            migrationBuilder.DropIndex(
                name: "IX_tariffplan_activationtypeid",
                table: "tariffplan");

            migrationBuilder.DropIndex(
                name: "IX_service_ActivationTypeId",
                table: "service");

            migrationBuilder.DropColumn(
                name: "activationtypeid",
                table: "tariffplan");

            migrationBuilder.DropColumn(
                name: "ActivationTypeId",
                table: "service");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "contractpayment");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "payment",
                type: "date",
                nullable: true);
        }
    }
}
