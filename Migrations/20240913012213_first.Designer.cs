﻿// <auto-generated />
using System;
using InScreeningApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace InScreeningApi.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20240913012213_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InScreeningApi.Models.Funcionario", b =>
                {
                    b.Property<int>("funcionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("funcionarioId"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cpf");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Nome");

                    b.HasKey("funcionarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("InScreeningApi.Models.Paciente", b =>
                {
                    b.Property<int>("pacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pacienteId"));

                    b.Property<int>("EnderecoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cpf");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<string>("rg")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Rg");

                    b.Property<int>("sexo")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("pacienteId");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("InScreeningApi.Models.Triagem", b =>
                {
                    b.Property<int>("triagemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("triagemId"));

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("dataInicio")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DataInicio");

                    b.Property<int>("prioridade")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Prioridade");

                    b.Property<string>("sintomas")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Sintomas");

                    b.HasKey("triagemId");

                    b.ToTable("Triagens");
                });
#pragma warning restore 612, 618
        }
    }
}