using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing52Group.Server.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contractgroup",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    comment = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractgroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "limit",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    limit = table.Column<string>(type: "varchar(45)", nullable: false, defaultValueSql: "'0'")
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_limit", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    title = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    comment = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tariffgroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffgroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Login = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Login, x.Password })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                });

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    date1 = table.Column<DateTime>(type: "date", nullable: false),
                    date2 = table.Column<DateTime>(type: "date", nullable: true),
                    fc = table.Column<sbyte>(nullable: false),
                    comment = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractgroupid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.id);
                    table.ForeignKey(
                        name: "FKgroup1",
                        column: x => x.contractgroupid,
                        principalTable: "contractgroup",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    comment = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    cost = table.Column<double>(nullable: false),
                    moduleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.id);
                    table.ForeignKey(
                        name: "FKmodule3",
                        column: x => x.moduleid,
                        principalTable: "module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tariffplan",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    tariffgroupid = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    cost = table.Column<double>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffplan", x => x.id);
                    table.ForeignKey(
                        name: "FKmodule1",
                        column: x => x.tariffgroupid,
                        principalTable: "tariffgroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractaccount",
                columns: table => new
                {
                    yy = table.Column<int>(nullable: false),
                    mm = table.Column<bool>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    summa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.yy, x.mm, x.contractid })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "FKcontract7",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractbalance",
                columns: table => new
                {
                    yy = table.Column<int>(nullable: false),
                    mm = table.Column<bool>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    summa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.yy, x.mm, x.contractid })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "FKcontract3",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractcharge",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    summa = table.Column<double>(nullable: false),
                    comment = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractid = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractcharge", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract2",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractlimit",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    limitid = table.Column<int>(nullable: false),
                    startdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractlimit", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract9",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKlimit1",
                        column: x => x.limitid,
                        principalTable: "limit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractmodule",
                columns: table => new
                {
                    contractid = table.Column<int>(nullable: false),
                    moduleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.contractid, x.moduleid })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "FKcontract1",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKmodule2",
                        column: x => x.moduleid,
                        principalTable: "module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractparams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contractId = table.Column<int>(nullable: false),
                    paramId = table.Column<int>(nullable: false),
                    value = table.Column<string>(type: "varchar(125)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractparams", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract10",
                        column: x => x.contractId,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKparams1",
                        column: x => x.paramId,
                        principalTable: "parameters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractpayment",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    summa = table.Column<double>(nullable: false),
                    comment = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    paymentid = table.Column<int>(nullable: false),
                    contractid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractpayment", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract4",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKpayment1",
                        column: x => x.paymentid,
                        principalTable: "payment",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractstatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    statusid = table.Column<int>(nullable: false),
                    startdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractstatus", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract8",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKstatus1",
                        column: x => x.statusid,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contractservice",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date1 = table.Column<DateTime>(type: "date", nullable: false),
                    date2 = table.Column<DateTime>(type: "date", nullable: true),
                    comment = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractid = table.Column<int>(nullable: false),
                    serviceid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractservice", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract6",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKservice1",
                        column: x => x.serviceid,
                        principalTable: "service",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contracttariff",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date1 = table.Column<DateTime>(type: "date", nullable: false),
                    date2 = table.Column<DateTime>(type: "date", nullable: true),
                    comment = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractid = table.Column<int>(nullable: false),
                    tariffplanid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracttariff", x => x.id);
                    table.ForeignKey(
                        name: "FKcontract5",
                        column: x => x.contractid,
                        principalTable: "contract",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FKtariff1",
                        column: x => x.tariffplanid,
                        principalTable: "tariffplan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "FKgroup1_idx",
                table: "contract",
                column: "contractgroupid");

            migrationBuilder.CreateIndex(
                name: "FKcontract7_idx",
                table: "contractaccount",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKcontract3_idx",
                table: "contractbalance",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKcontract2_idx",
                table: "contractcharge",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKcontract9_idx",
                table: "contractlimit",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKlimit1_idx",
                table: "contractlimit",
                column: "limitid");

            migrationBuilder.CreateIndex(
                name: "FKmodule1_idx",
                table: "contractmodule",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "FKcontract10_idx",
                table: "contractparams",
                column: "contractId");

            migrationBuilder.CreateIndex(
                name: "FKparams1_idx",
                table: "contractparams",
                column: "paramId");

            migrationBuilder.CreateIndex(
                name: "FKcontract4_idx",
                table: "contractpayment",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKpayment1_idx",
                table: "contractpayment",
                column: "paymentid");

            migrationBuilder.CreateIndex(
                name: "FKcontract6_idx",
                table: "contractservice",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKservice1_idx",
                table: "contractservice",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "FKcontract8_idx",
                table: "contractstatus",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKstatus1_idx",
                table: "contractstatus",
                column: "statusid");

            migrationBuilder.CreateIndex(
                name: "FKcontract5_idx",
                table: "contracttariff",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "FKtariff1_idx",
                table: "contracttariff",
                column: "tariffplanid");

            migrationBuilder.CreateIndex(
                name: "FKmodule3_idx",
                table: "service",
                column: "moduleid");

            migrationBuilder.CreateIndex(
                name: "FKmodule1_idx",
                table: "tariffplan",
                column: "tariffgroupid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contractaccount");

            migrationBuilder.DropTable(
                name: "contractbalance");

            migrationBuilder.DropTable(
                name: "contractcharge");

            migrationBuilder.DropTable(
                name: "contractlimit");

            migrationBuilder.DropTable(
                name: "contractmodule");

            migrationBuilder.DropTable(
                name: "contractparams");

            migrationBuilder.DropTable(
                name: "contractpayment");

            migrationBuilder.DropTable(
                name: "contractservice");

            migrationBuilder.DropTable(
                name: "contractstatus");

            migrationBuilder.DropTable(
                name: "contracttariff");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "limit");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "tariffplan");

            migrationBuilder.DropTable(
                name: "module");

            migrationBuilder.DropTable(
                name: "contractgroup");

            migrationBuilder.DropTable(
                name: "tariffgroup");
        }
    }
}
