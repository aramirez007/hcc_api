using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HccAlmacenes",
                columns: table => new
                {
                    AlmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmCantidad = table.Column<int>(type: "int", nullable: false),
                    AlmFechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlmEstatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HccAlmacenes", x => x.AlmId);
                });

            migrationBuilder.CreateTable(
                name: "HccCatEstatusOrdenes",
                columns: table => new
                {
                    CatOrdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatOrdNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatOrdEstatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HccCatEstatusOrdenes", x => x.CatOrdId);
                });

            migrationBuilder.CreateTable(
                name: "HccMesas",
                columns: table => new
                {
                    MesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesLugares = table.Column<short>(type: "smallint", nullable: false),
                    MesDisponibles = table.Column<byte>(type: "tinyint", nullable: false),
                    MesEstatus = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HccMesas", x => x.MesId);
                });

            migrationBuilder.CreateTable(
                name: "HccProductos",
                columns: table => new
                {
                    ProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmId = table.Column<int>(type: "int", nullable: false),
                    ProNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProPrecio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProEstatus = table.Column<byte>(type: "tinyint", nullable: false),
                    AlmacenAlmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HccProductos", x => x.ProId);
                    table.ForeignKey(
                        name: "FK_HccProductos_HccAlmacenes_AlmacenAlmId",
                        column: x => x.AlmacenAlmId,
                        principalTable: "HccAlmacenes",
                        principalColumn: "AlmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HccOrdenes",
                columns: table => new
                {
                    OrdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesId = table.Column<int>(type: "int", nullable: false),
                    CatOrdId = table.Column<int>(type: "int", nullable: false),
                    OrdenFechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrdenEstatus = table.Column<byte>(type: "tinyint", nullable: false),
                    MesaMesId = table.Column<int>(type: "int", nullable: false),
                    EstatusOrdenCatOrdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HccOrdenes", x => x.OrdId);
                    table.ForeignKey(
                        name: "FK_HccOrdenes_HccCatEstatusOrdenes_EstatusOrdenCatOrdId",
                        column: x => x.EstatusOrdenCatOrdId,
                        principalTable: "HccCatEstatusOrdenes",
                        principalColumn: "CatOrdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HccOrdenes_HccMesas_MesaMesId",
                        column: x => x.MesaMesId,
                        principalTable: "HccMesas",
                        principalColumn: "MesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HccOrdenDetalles",
                columns: table => new
                {
                    OrdDetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdId = table.Column<int>(type: "int", nullable: false),
                    ProId = table.Column<int>(type: "int", nullable: false),
                    OrdDetCantidad = table.Column<short>(type: "smallint", nullable: false),
                    OrdDetEstatus = table.Column<byte>(type: "tinyint", nullable: false),
                    OrdenOrdId = table.Column<int>(type: "int", nullable: false),
                    ProductoProId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HccOrdenDetalles", x => x.OrdDetId);
                    table.ForeignKey(
                        name: "FK_HccOrdenDetalles_HccOrdenes_OrdenOrdId",
                        column: x => x.OrdenOrdId,
                        principalTable: "HccOrdenes",
                        principalColumn: "OrdId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HccOrdenDetalles_HccProductos_ProductoProId",
                        column: x => x.ProductoProId,
                        principalTable: "HccProductos",
                        principalColumn: "ProId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HccOrdenDetalles_OrdenOrdId",
                table: "HccOrdenDetalles",
                column: "OrdenOrdId");

            migrationBuilder.CreateIndex(
                name: "IX_HccOrdenDetalles_ProductoProId",
                table: "HccOrdenDetalles",
                column: "ProductoProId");

            migrationBuilder.CreateIndex(
                name: "IX_HccOrdenes_EstatusOrdenCatOrdId",
                table: "HccOrdenes",
                column: "EstatusOrdenCatOrdId");

            migrationBuilder.CreateIndex(
                name: "IX_HccOrdenes_MesaMesId",
                table: "HccOrdenes",
                column: "MesaMesId");

            migrationBuilder.CreateIndex(
                name: "IX_HccProductos_AlmacenAlmId",
                table: "HccProductos",
                column: "AlmacenAlmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HccOrdenDetalles");

            migrationBuilder.DropTable(
                name: "HccOrdenes");

            migrationBuilder.DropTable(
                name: "HccProductos");

            migrationBuilder.DropTable(
                name: "HccCatEstatusOrdenes");

            migrationBuilder.DropTable(
                name: "HccMesas");

            migrationBuilder.DropTable(
                name: "HccAlmacenes");
        }
    }
}
