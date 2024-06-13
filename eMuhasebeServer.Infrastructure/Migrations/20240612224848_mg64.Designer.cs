﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eMuhasebeServer.Infrastructure.Context;

#nullable disable

namespace eMuhasebeServer.Infrastructure.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20240612224848_mg64")]
    partial class mg64
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Bank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("IBAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.BankDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExpenseDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProcessNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("BankDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegister", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("CashRegisters");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegisterDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CashRegisterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CustomerDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExpenseDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProcessNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CashRegisterId");

                    b.ToTable("CashRegisterDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxOffice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CustomerDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("DepositAmount")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("PaymentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProcessNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyType")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.ExpenseDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BankDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CashRegisterDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExpenseDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExpenseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ProcessNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WithdrawalAmount")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("ExpenseDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.InvoiceDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BrutTotal")
                        .HasColumnType("money");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountTotal")
                        .HasColumnType("money");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("money");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("NetTotal")
                        .HasColumnType("money");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProductDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductDetailId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(7,2)");

                    b.Property<int>("TaxRate")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxTotal")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductDetailId1");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PurchaseDiscountRate")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxRate")
                        .HasColumnType("int");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Withdrawal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UnitId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BrutTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<decimal>("Deposit")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountRate")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("InvoiceDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("NetTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ProductDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TaxRate")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Withdrawal")
                        .HasColumnType("decimal(7,2)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductDetailId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.BankDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Bank", null)
                        .WithMany("Details")
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegisterDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.CashRegister", null)
                        .WithMany("Details")
                        .HasForeignKey("CashRegisterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CustomerDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Customer", null)
                        .WithMany("Details")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.ExpenseDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Expense", null)
                        .WithMany("Details")
                        .HasForeignKey("ExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.InvoiceDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Invoice", null)
                        .WithMany("Details")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eMuhasebeServer.Domain.Entities.ProductDetail", "ProductDetail")
                        .WithMany()
                        .HasForeignKey("ProductDetailId1");

                    b.HasOne("eMuhasebeServer.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Product", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eMuhasebeServer.Domain.Entities.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.ProductDetail", b =>
                {
                    b.HasOne("eMuhasebeServer.Domain.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.HasOne("eMuhasebeServer.Domain.Entities.ProductDetail", null)
                        .WithMany("Details")
                        .HasForeignKey("ProductDetailId");

                    b.HasOne("eMuhasebeServer.Domain.Entities.Product", null)
                        .WithMany("Details")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Bank", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.CashRegister", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Expense", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Invoice", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.Product", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("eMuhasebeServer.Domain.Entities.ProductDetail", b =>
                {
                    b.Navigation("Details");
                });
#pragma warning restore 612, 618
        }
    }
}
