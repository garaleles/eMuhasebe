﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eMuhasebeServer.Infrastructure.Context;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations.CompanyDb
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20240530131217_mg-08")]
    partial class mg08
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegister", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<decimal>("Debt")
                        .HasColumnType("decimal");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<decimal>("Receivable")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("CashRegisters", (string)null);
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegisterDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailOppositeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CashRegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("Debt")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Receivable")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CashRegisterDetailOppositeId");

                    b.HasIndex("CashRegisterId");

                    b.ToTable("CashRegisterDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegisterDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.CashRegisterDetail", "CashRegisterDetailOpposite")
                        .WithMany()
                        .HasForeignKey("CashRegisterDetailOppositeId");

                    b.HasOne("eMuhasebeServer.Domain.Entities.CashRegister", null)
                        .WithMany("Details")
                        .HasForeignKey("CashRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CashRegisterDetailOpposite");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegister", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
