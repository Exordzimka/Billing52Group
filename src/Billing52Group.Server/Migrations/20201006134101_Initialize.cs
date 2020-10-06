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
                "contractgroup",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    comment = table.Column<string>("varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractgroup", x => x.id);
                });

            migrationBuilder.CreateTable(
                "limit",
                table => new
                {
                    id = table.Column<int>(nullable: false),
                    title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    limit = table.Column<string>("varchar(45)", nullable: false, defaultValueSql: "'0'")
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_limit", x => x.id);
                });

            migrationBuilder.CreateTable(
                "module",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "parameters",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.id);
                });

            migrationBuilder.CreateTable(
                "payment",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>("date", nullable: true),
                    title = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                });

            migrationBuilder.CreateTable(
                "status",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    comment = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                "tariffgroup",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffgroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "user",
                table => new
                {
                    Login = table.Column<string>("varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    Password = table.Column<string>("varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8")
                        .Annotation("MySql:Collation", "utf8_general_ci"),
                    admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new {x.Login, x.Password})
                        .Annotation("MySql:IndexPrefixLength", new[] {0, 0});
                });

            migrationBuilder.CreateTable(
                "contract",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    date1 = table.Column<DateTime>("date", nullable: false),
                    date2 = table.Column<DateTime>("date", nullable: true),
                    fc = table.Column<sbyte>(nullable: false),
                    comment = table.Column<string>("varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractgroupid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contract", x => x.id);
                    table.ForeignKey(
                        "FKgroup1",
                        x => x.contractgroupid,
                        "contractgroup",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "service",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    comment = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    cost = table.Column<double>(nullable: false),
                    moduleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.id);
                    table.ForeignKey(
                        "FKmodule3",
                        x => x.moduleid,
                        "module",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "tariffplan",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>("varchar(45)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    tariffgroupid = table.Column<int>(nullable: true, defaultValueSql: "'0'"),
                    cost = table.Column<double>(nullable: true, defaultValueSql: "'0'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tariffplan", x => x.id);
                    table.ForeignKey(
                        "FKmodule1",
                        x => x.tariffgroupid,
                        "tariffgroup",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractaccount",
                table => new
                {
                    yy = table.Column<int>(nullable: false),
                    mm = table.Column<bool>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    summa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new {x.yy, x.mm, x.contractid})
                        .Annotation("MySql:IndexPrefixLength", new[] {0, 0, 0});
                    table.ForeignKey(
                        "FKcontract7",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractbalance",
                table => new
                {
                    yy = table.Column<int>(nullable: false),
                    mm = table.Column<bool>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    summa = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new {x.yy, x.mm, x.contractid})
                        .Annotation("MySql:IndexPrefixLength", new[] {0, 0, 0});
                    table.ForeignKey(
                        "FKcontract3",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractcharge",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    summa = table.Column<double>(nullable: false),
                    comment = table.Column<string>("varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractid = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>("date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractcharge", x => x.id);
                    table.ForeignKey(
                        "FKcontract2",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractlimit",
                table => new
                {
                    id = table.Column<int>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    limitid = table.Column<int>(nullable: false),
                    startdate = table.Column<DateTime>("date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractlimit", x => x.id);
                    table.ForeignKey(
                        "FKcontract9",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKlimit1",
                        x => x.limitid,
                        "limit",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractmodule",
                table => new
                {
                    contractid = table.Column<int>(nullable: false), moduleid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new {x.contractid, x.moduleid})
                        .Annotation("MySql:IndexPrefixLength", new[] {0, 0});
                    table.ForeignKey(
                        "FKcontract1",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKmodule2",
                        x => x.moduleid,
                        "module",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractparams",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    contractId = table.Column<int>(nullable: false),
                    paramId = table.Column<int>(nullable: false),
                    value = table.Column<string>("varchar(125)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractparams", x => x.id);
                    table.ForeignKey(
                        "FKcontract10",
                        x => x.contractId,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKparams1",
                        x => x.paramId,
                        "parameters",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractpayment",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    summa = table.Column<double>(nullable: false),
                    comment = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    paymentid = table.Column<int>(nullable: false),
                    contractid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractpayment", x => x.id);
                    table.ForeignKey(
                        "FKcontract4",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKpayment1",
                        x => x.paymentid,
                        "payment",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractstatus",
                table => new
                {
                    id = table.Column<int>(nullable: false),
                    contractid = table.Column<int>(nullable: false),
                    statusid = table.Column<int>(nullable: false),
                    startdate = table.Column<DateTime>("date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractstatus", x => x.id);
                    table.ForeignKey(
                        "FKcontract8",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKstatus1",
                        x => x.statusid,
                        "status",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contractservice",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date1 = table.Column<DateTime>("date", nullable: false),
                    date2 = table.Column<DateTime>("date", nullable: true),
                    comment = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractid = table.Column<int>(nullable: false),
                    serviceid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contractservice", x => x.id);
                    table.ForeignKey(
                        "FKcontract6",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKservice1",
                        x => x.serviceid,
                        "service",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "contracttariff",
                table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date1 = table.Column<DateTime>("date", nullable: false),
                    date2 = table.Column<DateTime>("date", nullable: true),
                    comment = table.Column<string>("varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    contractid = table.Column<int>(nullable: false),
                    tariffplanid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracttariff", x => x.id);
                    table.ForeignKey(
                        "FKcontract5",
                        x => x.contractid,
                        "contract",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FKtariff1",
                        x => x.tariffplanid,
                        "tariffplan",
                        "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "FKgroup1_idx",
                "contract",
                "contractgroupid");

            migrationBuilder.CreateIndex(
                "FKcontract7_idx",
                "contractaccount",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKcontract3_idx",
                "contractbalance",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKcontract2_idx",
                "contractcharge",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKcontract9_idx",
                "contractlimit",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKlimit1_idx",
                "contractlimit",
                "limitid");

            migrationBuilder.CreateIndex(
                "FKmodule1_idx",
                "contractmodule",
                "moduleid");

            migrationBuilder.CreateIndex(
                "FKcontract10_idx",
                "contractparams",
                "contractId");

            migrationBuilder.CreateIndex(
                "FKparams1_idx",
                "contractparams",
                "paramId");

            migrationBuilder.CreateIndex(
                "FKcontract4_idx",
                "contractpayment",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKpayment1_idx",
                "contractpayment",
                "paymentid");

            migrationBuilder.CreateIndex(
                "FKcontract6_idx",
                "contractservice",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKservice1_idx",
                "contractservice",
                "serviceid");

            migrationBuilder.CreateIndex(
                "FKcontract8_idx",
                "contractstatus",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKstatus1_idx",
                "contractstatus",
                "statusid");

            migrationBuilder.CreateIndex(
                "FKcontract5_idx",
                "contracttariff",
                "contractid");

            migrationBuilder.CreateIndex(
                "FKtariff1_idx",
                "contracttariff",
                "tariffplanid");

            migrationBuilder.CreateIndex(
                "FKmodule3_idx",
                "service",
                "moduleid");

            migrationBuilder.CreateIndex(
                "FKmodule1_idx",
                "tariffplan",
                "tariffgroupid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "contractaccount");

            migrationBuilder.DropTable(
                "contractbalance");

            migrationBuilder.DropTable(
                "contractcharge");

            migrationBuilder.DropTable(
                "contractlimit");

            migrationBuilder.DropTable(
                "contractmodule");

            migrationBuilder.DropTable(
                "contractparams");

            migrationBuilder.DropTable(
                "contractpayment");

            migrationBuilder.DropTable(
                "contractservice");

            migrationBuilder.DropTable(
                "contractstatus");

            migrationBuilder.DropTable(
                "contracttariff");

            migrationBuilder.DropTable(
                "user");

            migrationBuilder.DropTable(
                "limit");

            migrationBuilder.DropTable(
                "parameters");

            migrationBuilder.DropTable(
                "payment");

            migrationBuilder.DropTable(
                "service");

            migrationBuilder.DropTable(
                "status");

            migrationBuilder.DropTable(
                "contract");

            migrationBuilder.DropTable(
                "tariffplan");

            migrationBuilder.DropTable(
                "module");

            migrationBuilder.DropTable(
                "contractgroup");

            migrationBuilder.DropTable(
                "tariffgroup");
        }
    }
}
