﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecruitmentSITHEC;

#nullable disable

namespace RecruitmentSITHEC.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230303183627_HumanTBL")]
    partial class HumanTBL
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecruitmentSITHEC.Entities.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Humano", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Altura = 1.80m,
                            Edad = 20,
                            Nombre = "Juan",
                            Peso = 80.00m,
                            Sexo = "H"
                        },
                        new
                        {
                            Id = 2,
                            Altura = 1.70m,
                            Edad = 25,
                            Nombre = "Pedro",
                            Peso = 70.00m,
                            Sexo = "H"
                        },
                        new
                        {
                            Id = 3,
                            Altura = 1.60m,
                            Edad = 30,
                            Nombre = "Maria",
                            Peso = 60.00m,
                            Sexo = "M"
                        },
                        new
                        {
                            Id = 4,
                            Altura = 1.50m,
                            Edad = 35,
                            Nombre = "Jose",
                            Peso = 50.00m,
                            Sexo = "H"
                        },
                        new
                        {
                            Id = 5,
                            Altura = 1.40m,
                            Edad = 40,
                            Nombre = "Luis",
                            Peso = 40.00m,
                            Sexo = "H"
                        },
                        new
                        {
                            Id = 6,
                            Altura = 1.30m,
                            Edad = 45,
                            Nombre = "Ana",
                            Peso = 30.00m,
                            Sexo = "M"
                        },
                        new
                        {
                            Id = 7,
                            Altura = 1.20m,
                            Edad = 50,
                            Nombre = "Luisa",
                            Peso = 20.00m,
                            Sexo = "M"
                        },
                        new
                        {
                            Id = 8,
                            Altura = 1.10m,
                            Edad = 55,
                            Nombre = "Luis",
                            Peso = 10.00m,
                            Sexo = "H"
                        },
                        new
                        {
                            Id = 9,
                            Altura = 1.00m,
                            Edad = 60,
                            Nombre = "Luisa",
                            Peso = 5.00m,
                            Sexo = "M"
                        },
                        new
                        {
                            Id = 10,
                            Altura = 0.90m,
                            Edad = 65,
                            Nombre = "Luis",
                            Peso = 4.00m,
                            Sexo = "H"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}