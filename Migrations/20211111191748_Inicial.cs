using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Perla_AP2_API_20190008.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Inventario = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    ComprasId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.ComprasId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "ComprasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProveedorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Importe = table.Column<int>(type: "INTEGER", nullable: false),
                    Costo = table.Column<int>(type: "INTEGER", nullable: false),
                    ComprasId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComprasDetalle_Compras_ComprasId",
                        column: x => x.ComprasId,
                        principalTable: "Compras",
                        principalColumn: "ComprasId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 1, 0m, "Caja de avena", 0m });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 2, 0m, "Faldos de refrescos", 0m });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 3, 0m, "Cajas de sopa", 0m });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 4, 0m, "Embutidos", 0m });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Inventario" },
                values: new object[] { 5, 0m, "Cajas de jabones", 0m });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "ProveedorId", "Nombre" },
                values: new object[] { 1, "Bodega de Jesus" });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "ProveedorId", "Nombre" },
                values: new object[] { 2, "Bodega Rodriguez" });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "ProveedorId", "Nombre" },
                values: new object[] { 3, "Supermercado Suarez" });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "ProveedorId", "Nombre" },
                values: new object[] { 4, "Supermercado Canario" });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasDetalle_ComprasId",
                table: "ComprasDetalle",
                column: "ComprasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "ComprasDetalle");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Compras");
        }
    }
}
