﻿// <auto-generated />
using System;
using HCC_API_ADRIAN_RAMIREZ_SALAZAR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HCC_API_ADRIAN_RAMIREZ_SALAZAR.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccAlmacen", b =>
                {
                    b.Property<int>("AlmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlmId"), 1L, 1);

                    b.Property<int>("AlmCantidad")
                        .HasColumnType("int");

                    b.Property<byte>("AlmEstatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("AlmFechaActualizacion")
                        .HasColumnType("datetime2");

                    b.HasKey("AlmId");

                    b.ToTable("HccAlmacenes");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccCatEstatusOrden", b =>
                {
                    b.Property<int>("CatOrdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatOrdId"), 1L, 1);

                    b.Property<byte>("CatOrdEstatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("CatOrdNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatOrdId");

                    b.ToTable("HccCatEstatusOrdenes");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccMesa", b =>
                {
                    b.Property<int>("MesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesId"), 1L, 1);

                    b.Property<byte>("MesDisponibles")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MesEstatus")
                        .HasColumnType("tinyint");

                    b.Property<short>("MesLugares")
                        .HasColumnType("smallint");

                    b.HasKey("MesId");

                    b.ToTable("HccMesas");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccOrden", b =>
                {
                    b.Property<int>("OrdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdId"), 1L, 1);

                    b.Property<int>("CatOrdId")
                        .HasColumnType("int");

                    b.Property<int>("EstatusOrdenCatOrdId")
                        .HasColumnType("int");

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<int>("MesaMesId")
                        .HasColumnType("int");

                    b.Property<byte>("OrdenEstatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("OrdenFechaInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("OrdId");

                    b.HasIndex("EstatusOrdenCatOrdId");

                    b.HasIndex("MesaMesId");

                    b.ToTable("HccOrdenes");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccOrdenDetalle", b =>
                {
                    b.Property<int>("OrdDetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdDetId"), 1L, 1);

                    b.Property<short>("OrdDetCantidad")
                        .HasColumnType("smallint");

                    b.Property<byte>("OrdDetEstatus")
                        .HasColumnType("tinyint");

                    b.Property<int>("OrdId")
                        .HasColumnType("int");

                    b.Property<int>("OrdenOrdId")
                        .HasColumnType("int");

                    b.Property<int>("ProId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoProId")
                        .HasColumnType("int");

                    b.HasKey("OrdDetId");

                    b.HasIndex("OrdenOrdId");

                    b.HasIndex("ProductoProId");

                    b.ToTable("HccOrdenDetalles");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccProducto", b =>
                {
                    b.Property<int>("ProId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProId"), 1L, 1);

                    b.Property<int>("AlmId")
                        .HasColumnType("int");

                    b.Property<int>("AlmacenAlmId")
                        .HasColumnType("int");

                    b.Property<string>("ProDescripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("ProEstatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("ProNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ProPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProId");

                    b.HasIndex("AlmacenAlmId");

                    b.ToTable("HccProductos");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccOrden", b =>
                {
                    b.HasOne("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccCatEstatusOrden", "EstatusOrden")
                        .WithMany()
                        .HasForeignKey("EstatusOrdenCatOrdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccMesa", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaMesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstatusOrden");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccOrdenDetalle", b =>
                {
                    b.HasOne("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccOrden", "Orden")
                        .WithMany("OrdenDetalles")
                        .HasForeignKey("OrdenOrdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccProducto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoProId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orden");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccProducto", b =>
                {
                    b.HasOne("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccAlmacen", "Almacen")
                        .WithMany()
                        .HasForeignKey("AlmacenAlmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Almacen");
                });

            modelBuilder.Entity("HCC_API_ADRIAN_RAMIREZ_SALAZAR.Models.HccOrden", b =>
                {
                    b.Navigation("OrdenDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}