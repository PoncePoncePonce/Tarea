﻿// <auto-generated />
using System;
using Infraestructura.SQLServer.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.SQLServer.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20221220232650_consultorio")]
    partial class consultorio
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Consultorio.Business.Entidades.Cliente", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("apellidoCliente");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("direccionCliente");

                    b.Property<DateTime>("FechaDeNacimiento")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaDeNacimientoCliente");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombreCliente");

                    b.HasKey("Id");

                    b.ToTable("Clientes", "cat");
                });

            modelBuilder.Entity("Consultorio.Business.Entidades.Consulta", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClienteId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DoctorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaDeConsulta");

                    b.Property<string>("Motivo")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("motivo");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("DoctorId");

                    b.ToTable("RegConsultas", "At");
                });

            modelBuilder.Entity("Consultorio.Business.Entidades.Doctor", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("apellidoDoctor");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)")
                        .HasColumnName("cedulaDoctor");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombreDoctor");

                    b.Property<string>("NumeroDeTelefono")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("numeroTelefonoDoctor");

                    b.HasKey("Id");

                    b.ToTable("Doctores", "cat");
                });

            modelBuilder.Entity("Consultorio.Business.Entidades.Consulta", b =>
                {
                    b.HasOne("Consultorio.Business.Entidades.Cliente", "Cliente")
                        .WithMany("Consultas")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Consultorio.Business.Entidades.Doctor", "Doctor")
                        .WithMany("Consultas")
                        .HasForeignKey("DoctorId");

                    b.Navigation("Cliente");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("Consultorio.Business.Entidades.Cliente", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("Consultorio.Business.Entidades.Doctor", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
