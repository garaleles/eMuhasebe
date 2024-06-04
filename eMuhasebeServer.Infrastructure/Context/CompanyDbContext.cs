﻿using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Enums;
using eMuhasebeServer.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace eMuhasebeServer.Infrastructure.Context;

public sealed class CompanyDbContext : DbContext, IUnitOfWorkCompany
{
  

    #region connection
    private string connectionString = String.Empty;
    public CompanyDbContext(Company company)
    {
        CreateConnectionStringWithCompany(company);
    }

    public CompanyDbContext(
        IHttpContextAccessor contextAccessor,
        ApplicationDbContext applicationDbContext
    )
    {
        CreateConnectionString(contextAccessor, applicationDbContext);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
    
    private void CreateConnectionString(
        IHttpContextAccessor contextAccessor,
        ApplicationDbContext applicationDbContext
    )
    {
        if (contextAccessor.HttpContext is null)
            return;
        string? companyId = contextAccessor.HttpContext.User.FindFirstValue("CompanyId");
        if (string.IsNullOrEmpty(companyId))
            return;
        Company? company = applicationDbContext.Companies.FirstOrDefault(x =>
            x.Id == Guid.Parse(companyId)
        );
        if (company is null)
            return;

        CreateConnectionStringWithCompany(company);
    }

    private void CreateConnectionStringWithCompany(Company company)
    {
        if (string.IsNullOrEmpty(company.Database.UserId))
        {
            connectionString =
                $"Data Source={company.Database.Server};"
                + $"Initial Catalog={company.Database.DatabaseName};"
                + "Integrated Security=True;"
                + "Connect Timeout=30;"
                + "Encrypt=True;"
                + "Trust Server Certificate=true;"
                + "Application Intent=ReadWrite;"
                + "Multi Subnet Failover=False";
        }
        else
        {
            connectionString =
                $"Data Source={company.Database.Server};"
                + $"Initial Catalog={company.Database.DatabaseName};"
                + "Integrated Security=False;"
                + $"User Id={company.Database.UserId};"
                + $"Password={company.Database.Password};"
                + "Connect Timeout=30;"
                + "Encrypt=True;"
                + "Trust Server Certificate=true;"
                + "Application Intent=ReadWrite;"
                + "Multi Subnet Failover=False";
        }
    }

    #endregion
   

    public DbSet<CashRegister> CashRegisters { get; set; }
    public DbSet<CashRegisterDetail> CashRegisterDetails { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<BankDetail> BankDetails { get; set; }
    public DbSet<Customer>  Customers { get; set; }
    public DbSet<CustomerDetail> CustomerDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region cashRegister
        modelBuilder.Entity<CashRegister>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<CashRegister>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        modelBuilder.Entity<CashRegister>()
            .Property(p => p.CurrencyType)
            .HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
        modelBuilder.Entity<CashRegister>().HasQueryFilter(filter => !filter.IsDeleted);
        modelBuilder.Entity<CashRegister>()
            .HasMany(p => p.Details)
            .WithOne()
            .HasForeignKey(p => p.CashRegisterId);
        #endregion

        #region cashRegisterDetail
        modelBuilder.Entity<CashRegisterDetail>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<CashRegisterDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        #endregion

        #region Bank

        modelBuilder.Entity<Bank>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<Bank>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        modelBuilder.Entity<Bank>()
            .Property(p => p.CurrencyType)
            .HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));
        modelBuilder.Entity<Bank>().HasQueryFilter(filter => !filter.IsDeleted);
        modelBuilder.Entity<Bank>()
            .HasMany(p => p.Details)
            .WithOne()
            .HasForeignKey(p => p.BankId);

        #endregion

        #region BankDetail
        modelBuilder.Entity<BankDetail>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<BankDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        #endregion
        
        #region Customer
        modelBuilder.Entity<Customer>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<Customer>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        modelBuilder.Entity<Customer>()
            .Property(p => p.Type)
            .HasConversion(type => type.Value, value => CustomerTypeEnum.FromValue(value));
        
        modelBuilder.Entity<Customer>().HasQueryFilter(filter => !filter.IsDeleted);
        #endregion
        
        #region CustomerDetail
        modelBuilder.Entity<CustomerDetail>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<CustomerDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        modelBuilder.Entity<CustomerDetail>().Property(p => p.Type)
            .HasConversion(type => type.Value, value => CustomerDetailTypeEnum.FromValue(value));
        #endregion
        
        #region Product
        modelBuilder.Entity<Product>().Property(p => p.SellingPrice).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>().Property(p => p.PurchasePrice).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>().Property(p => p.Deposit).HasColumnType("decimal(7,2)");
        modelBuilder.Entity<Product>().Property(p => p.Withdrawal).HasColumnType("decimal(7,2)");
        modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Product>().HasOne(p => p.Unit).WithMany().HasForeignKey(p => p.UnitId);
        modelBuilder.Entity<Product>().HasQueryFilter(filter => !filter.IsDeleted);
        #endregion
        
        #region ProductDetail
        modelBuilder.Entity<ProductDetail>().Property(p => p.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.Deposit).HasColumnType("decimal(7,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.Withdrawal).HasColumnType("decimal(7,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.BrutTotal).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.DiscountTotal).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.NetTotal).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.VatTotal).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.GrandTotal).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<ProductDetail>().Property(p => p.VatRate).HasColumnType("int");
        modelBuilder.Entity<ProductDetail>().Property(p => p.DiscountRate).HasColumnType("int");
        #endregion
        
        #region Unit
        modelBuilder.Entity<Unit>().HasQueryFilter(filter => !filter.IsDeleted);
        #endregion
        
        #region Category
        modelBuilder.Entity<Category>().HasQueryFilter(filter => !filter.IsDeleted);
        #endregion
       
        
       
    }

  
}
