﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication.TCC.Context.Datas;

namespace WebApplication.TCC.Context.Migrations
{
    [DbContext(typeof(TccContext))]
    [Migration("20210813114954_Doctor-Patient")]
    partial class DoctorPatient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApplication.TCC.Context.Models.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("doctor_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnName("document")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Id");

                    b.ToTable("doctor");
                });

            modelBuilder.Entity("WebApplication.TCC.Context.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("patient_id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("DATE");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnName("document")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("Height")
                        .HasColumnName("height")
                        .HasColumnType("NUMERIC(2,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("VARCHAR(255)");

                    b.Property<decimal>("Weight")
                        .HasColumnName("weight")
                        .HasColumnType("NUMERIC(3,3)");

                    b.HasKey("Id");

                    b.ToTable("patient");
                });
#pragma warning restore 612, 618
        }
    }
}