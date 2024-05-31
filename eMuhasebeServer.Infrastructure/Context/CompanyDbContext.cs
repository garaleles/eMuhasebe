using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Enums;
using eMuhasebeServer.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace eMuhasebeServer.Infrastructure.Context;

public sealed class CompanyDbContext : DbContext, IUnitOfWorkCompany
{
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

    public DbSet<CashRegister> CashRegisters { get; set; }
    public DbSet<CashRegisterDetail> CashRegisterDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<CashRegisterDetail>().Property(p => p.DepositAmount).HasColumnType("money");
        modelBuilder.Entity<CashRegisterDetail>().Property(p => p.WithdrawalAmount).HasColumnType("money");
        modelBuilder.Entity<CashRegisterDetail>().HasQueryFilter(filter => !filter.IsDeleted);
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
}
