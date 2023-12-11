﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeguridadInformatica.Data;

#nullable disable

namespace SeguridadInformatica.Migrations
{
    [DbContext(typeof(SeguridadInformaticaContext))]
    [Migration("20231211121407_Inicio")]
    partial class Inicio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeguridadInformatica.Models.Activos", b =>
                {
                    b.Property<int>("ActivosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivosId"), 1L, 1);

                    b.Property<float>("Confidencialidad")
                        .HasColumnType("real");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Disponibilidad")
                        .HasColumnType("real");

                    b.Property<float>("Integridad")
                        .HasColumnType("real");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuariosId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuariosId1")
                        .HasColumnType("int");

                    b.HasKey("ActivosId");

                    b.HasIndex("UsuariosId1");

                    b.ToTable("Activos");
                });

            modelBuilder.Entity("SeguridadInformatica.Models.Dimensiones", b =>
                {
                    b.Property<int>("DimensionesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DimensionesId"), 1L, 1);

                    b.Property<string>("ActivosId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActivosId1")
                        .HasColumnType("int");

                    b.Property<int>("Confidencialidad")
                        .HasColumnType("int");

                    b.Property<int>("Disponibilidad")
                        .HasColumnType("int");

                    b.Property<int>("Evaluacion")
                        .HasColumnType("int");

                    b.Property<int>("Integridad")
                        .HasColumnType("int");

                    b.Property<string>("UsuariosId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuariosId1")
                        .HasColumnType("int");

                    b.HasKey("DimensionesId");

                    b.HasIndex("ActivosId1");

                    b.HasIndex("UsuariosId1");

                    b.ToTable("Dimensiones");
                });

            modelBuilder.Entity("SeguridadInformatica.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuariosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuariosId"), 1L, 1);

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuariosId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SeguridadInformatica.Models.Activos", b =>
                {
                    b.HasOne("SeguridadInformatica.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosId1");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("SeguridadInformatica.Models.Dimensiones", b =>
                {
                    b.HasOne("SeguridadInformatica.Models.Activos", "Activos")
                        .WithMany()
                        .HasForeignKey("ActivosId1");

                    b.HasOne("SeguridadInformatica.Models.Usuarios", "Usuarios")
                        .WithMany()
                        .HasForeignKey("UsuariosId1");

                    b.Navigation("Activos");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
