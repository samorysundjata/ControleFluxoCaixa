﻿// <auto-generated />
using System;
using ControleFluxoCaixa.Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleFluxoCaixa.Infraestrutura.Migrations
{
    [DbContext(typeof(ControleFluxoCaixaDbContext))]
    partial class ControleFluxoCaixaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("ControleFluxoCaixa.Dominio.Entidades.ConsolidadoDiario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalCreditos")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalDebitos")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ConsolidadosDiarios");
                });

            modelBuilder.Entity("ControleFluxoCaixa.Dominio.Entidades.Lancamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCredito")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Lancamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
