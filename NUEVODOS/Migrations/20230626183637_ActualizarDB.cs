using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NUEVODOS.Migrations
{
    public partial class ActualizarDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Vehiculos",
            //    columns: table => new
            //    {
            //        Placa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Vehiculo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Marca = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Modelo = table.Column<int>(type: "int", nullable: false),
            //        Capacidad = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Tipo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Color = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Servicio = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Linea = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Motor = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Chasis = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Serie = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Empresa = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Matricula = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false),
            //        Kilometraje = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Cilindraje = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        Combustible = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Traccion = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
            //        Soat = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Tecnomecanica = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Correadentada = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Vehiculo__8310F99C85B7A0BC", x => x.Placa);
            //    });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            //migrationBuilder.CreateTable(
            //    name: "Compras",
            //    columns: table => new
            //    {
            //        Idcompra = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Fechacompra = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        Preciocompra = table.Column<int>(type: "int", nullable: false),
            //        MPcompra = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Limitacionescompra = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //        Ciudadcompra = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        SPcompra = table.Column<int>(type: "int", nullable: false),
            //        Placacompra = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Compras__6CA76DB8E7F239E3", x => x.Idcompra);
            //        table.ForeignKey(
            //            name: "FK__Compras__Placaco__276EDEB3",
            //            column: x => x.Placacompra,
            //            principalTable: "Vehiculos",
            //            principalColumn: "Placa");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Ventas",
            //    columns: table => new
            //    {
            //        Idventa = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Fechaventa = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        Precioventa = table.Column<int>(type: "int", nullable: false),
            //        MPventa = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        Limitacionesventa = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
            //        Ciudadventa = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
            //        SPventa = table.Column<int>(type: "int", nullable: false),
            //        Placaventa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Ventas__AF5FD380C7D4DE2A", x => x.Idventa);
            //        table.ForeignKey(
            //            name: "FK__Ventas__Placaven__2B3F6F97",
            //            column: x => x.Placaventa,
            //            principalTable: "Vehiculos",
            //            principalColumn: "Placa");
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Compras_Placacompra",
            //    table: "Compras",
            //    column: "Placacompra");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Ventas_Placaventa",
            //    table: "Ventas",
            //    column: "Placaventa");
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

            //migrationBuilder.DropTable(
            //    name: "Compras");

            //migrationBuilder.DropTable(
            //    name: "Ventas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            //migrationBuilder.DropTable(
            //    name: "Vehiculos");
        }
    }
}
