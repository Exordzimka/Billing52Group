using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing52Group.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
