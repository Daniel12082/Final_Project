using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "boss",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dentification_ard = table.Column<int>(type: "int", nullable: true),
                    cellphone = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    contact_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_last_name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_numbrer = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fax = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product_line",
                columns: table => new
                {
                    product_line = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_text = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_html = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.product_line);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dentification_ard = table.Column<int>(type: "int", nullable: false),
                    cellphone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCountryFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                    table.ForeignKey(
                        name: "Fk_IdCountry",
                        column: x => x.IdCountryFk,
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_code = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    product_line = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dimensions = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    supplier = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    stock_quantity = table.Column<short>(type: "smallint", nullable: false),
                    selling_price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    supplier_price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    IdProviderFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_IdproviderFk",
                        column: x => x.IdProviderFk,
                        principalTable: "provider",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_product_line",
                        column: x => x.product_line,
                        principalTable: "product_line",
                        principalColumn: "product_line");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdStateFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Fk_IdState",
                        column: x => x.IdStateFk,
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "location_office",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoDeVia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroPri = table.Column<short>(type: "smallint", nullable: false),
                    letra = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bis = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letrasec = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cardinal = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroSec = table.Column<short>(type: "smallint", nullable: false),
                    letrater = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroTer = table.Column<short>(type: "smallint", nullable: false),
                    cardinalSec = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idCityFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Fk1_idCityFk",
                        column: x => x.idCityFk,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "office",
                columns: table => new
                {
                    office_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    location_office_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.office_code);
                    table.ForeignKey(
                        name: "fk_office_location_customer_copy11",
                        column: x => x.location_office_FK,
                        principalTable: "location_office",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employee_code = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    office_code = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdBossFk = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.employee_code);
                    table.ForeignKey(
                        name: "Fk_IdBossFk",
                        column: x => x.IdBossFk,
                        principalTable: "boss",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Fk_OfficeCodeFk",
                        column: x => x.office_code,
                        principalTable: "office",
                        principalColumn: "office_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_code = table.Column<int>(type: "int", nullable: false),
                    client_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    credit_limit = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    IdEmployeeFK = table.Column<int>(type: "int", nullable: false),
                    IdContactFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.client_code);
                    table.ForeignKey(
                        name: "FK_Contact",
                        column: x => x.IdContactFK,
                        principalTable: "contact",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_FK",
                        column: x => x.IdEmployeeFK,
                        principalTable: "employee",
                        principalColumn: "employee_code",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "location_customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoDeVia = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroPri = table.Column<short>(type: "smallint", nullable: false),
                    letra = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bis = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    letrasec = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cardinal = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroSec = table.Column<short>(type: "smallint", nullable: false),
                    letrater = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroTer = table.Column<short>(type: "smallint", nullable: false),
                    cardinalSec = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complemento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    idClientFk = table.Column<int>(type: "int", nullable: false),
                    idCityFk = table.Column<int>(type: "int", nullable: false),
                    PostCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "Fk1_idClientFk",
                        column: x => x.idClientFk,
                        principalTable: "client",
                        principalColumn: "client_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk2_idCityFk",
                        column: x => x.idCityFk,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_code = table.Column<int>(type: "int", nullable: false),
                    order_date = table.Column<DateOnly>(type: "date", nullable: false),
                    expected_date = table.Column<DateOnly>(type: "date", nullable: false),
                    delivery_date = table.Column<DateOnly>(type: "date", nullable: true),
                    status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    comments = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    client_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.order_code);
                    table.ForeignKey(
                        name: "Fk_client_code",
                        column: x => x.client_code,
                        principalTable: "client",
                        principalColumn: "client_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payment_method = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    transaction_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    payment_date = table.Column<DateOnly>(type: "date", nullable: false),
                    total = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    client_code = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_cliente_code",
                        column: x => x.client_code,
                        principalTable: "client",
                        principalColumn: "client_code");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_detail",
                columns: table => new
                {
                    order_code = table.Column<int>(type: "int", nullable: false),
                    product_code = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    line_number = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.order_code, x.product_code })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "Fk1_order_code",
                        column: x => x.order_code,
                        principalTable: "orders",
                        principalColumn: "order_code");
                    table.ForeignKey(
                        name: "Fk2_product_code",
                        column: x => x.product_code,
                        principalTable: "product",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "Fk_IdState",
                table: "city",
                column: "IdStateFk");

            migrationBuilder.CreateIndex(
                name: "FK_Contact",
                table: "client",
                column: "IdContactFK");

            migrationBuilder.CreateIndex(
                name: "FK_Employee_FK",
                table: "client",
                column: "IdEmployeeFK");

            migrationBuilder.CreateIndex(
                name: "Fk_IdBossFk",
                table: "employee",
                column: "IdBossFk");

            migrationBuilder.CreateIndex(
                name: "Fk_OfficeCodeFk",
                table: "employee",
                column: "office_code");

            migrationBuilder.CreateIndex(
                name: "Fk1_idClientFk",
                table: "location_customer",
                column: "idClientFk");

            migrationBuilder.CreateIndex(
                name: "Fk2_idCityFk",
                table: "location_customer",
                column: "idCityFk");

            migrationBuilder.CreateIndex(
                name: "Fk1_idCityFk",
                table: "location_office",
                column: "idCityFk");

            migrationBuilder.CreateIndex(
                name: "fk_office_location_customer_copy11_idx",
                table: "office",
                column: "location_office_FK");

            migrationBuilder.CreateIndex(
                name: "Fk2_product_code",
                table: "order_detail",
                column: "product_code");

            migrationBuilder.CreateIndex(
                name: "Fk_client_code",
                table: "orders",
                column: "client_code");

            migrationBuilder.CreateIndex(
                name: "Fk_cliente_code",
                table: "payment",
                column: "client_code");

            migrationBuilder.CreateIndex(
                name: "Fk_IdproviderFk",
                table: "product",
                column: "IdProviderFk");

            migrationBuilder.CreateIndex(
                name: "Fk_product_line",
                table: "product",
                column: "product_line");

            migrationBuilder.CreateIndex(
                name: "Fk_IdCountry",
                table: "state",
                column: "IdCountryFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "location_customer");

            migrationBuilder.DropTable(
                name: "order_detail");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "product_line");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "boss");

            migrationBuilder.DropTable(
                name: "office");

            migrationBuilder.DropTable(
                name: "location_office");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
