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
    [Migration("20240916135951_secod")]
    partial class secod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InScreeningApi.Models.Endereco", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cep");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Complemento");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Estado");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Logradouro");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Municipio");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Numero");

                    b.HasKey("EnderecoId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("InScreeningApi.Models.Funcionario", b =>
                {
                    b.Property<int>("funcionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("funcionarioId"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("funcionarioId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("InScreeningApi.Models.Paciente", b =>
                {
                    b.Property<int>("pacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pacienteId"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Nome");

                    b.Property<string>("Rg")
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