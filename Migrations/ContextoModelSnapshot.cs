﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Perla_AP2_API_20190008.DAL;

namespace Perla_AP2_API_20190008.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Costo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Inventario")
                        .HasColumnType("TEXT");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 0m,
                            Descripcion = "Caja de avena",
                            Inventario = 0m
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 0m,
                            Descripcion = "Faldos de refrescos",
                            Inventario = 0m
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 0m,
                            Descripcion = "Cajas de sopa",
                            Inventario = 0m
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 0m,
                            Descripcion = "Embutidos",
                            Inventario = 0m
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 0m,
                            Descripcion = "Cajas de jabones",
                            Inventario = 0m
                        });
                });

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.Compras", b =>
                {
                    b.Property<int>("ComprasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<int?>("proveedoresProveedorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ComprasId");

                    b.HasIndex("proveedoresProveedorId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.ComprasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArticuloId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ComprasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Costo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Importe")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ComprasId");

                    b.ToTable("ComprasDetalle");
                });

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.Proveedores", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            ProveedorId = 1,
                            Nombre = "Bodega de Jesus"
                        },
                        new
                        {
                            ProveedorId = 2,
                            Nombre = "Bodega Rodriguez"
                        },
                        new
                        {
                            ProveedorId = 3,
                            Nombre = "Supermercado Suarez"
                        },
                        new
                        {
                            ProveedorId = 4,
                            Nombre = "Supermercado Canario"
                        });
                });

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.Compras", b =>
                {
                    b.HasOne("Perla_AP2_API_20190008.Entidades.Proveedores", "proveedores")
                        .WithMany()
                        .HasForeignKey("proveedoresProveedorId");

                    b.Navigation("proveedores");
                });

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.ComprasDetalle", b =>
                {
                    b.HasOne("Perla_AP2_API_20190008.Entidades.Compras", null)
                        .WithMany("Detalle")
                        .HasForeignKey("ComprasId");
                });

            modelBuilder.Entity("Perla_AP2_API_20190008.Entidades.Compras", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
