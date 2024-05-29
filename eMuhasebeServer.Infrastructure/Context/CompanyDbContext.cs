using System.Security.Claims;
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

    public CompanyDbContext(IHttpContextAccessor contextAccessor, ApplicationDbContext applicationDbContext)
    {

        CreateConnectionString(contextAccessor, applicationDbContext);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }


    public DbSet<CashRegister> CashRegisters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Receivable)
            .HasColumnType("decimal");

        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Debt)
            .HasColumnType("decimal");

        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Balance)
            .HasColumnType("decimal");

        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Date)
            .HasColumnType("date");


        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Date)
            .HasColumnType("date");


        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Name)
            .HasColumnType("varchar").HasMaxLength(100).IsRequired();


        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.Description)
            .HasColumnType("varchar").HasMaxLength(250);

        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").Property(x => x.CurrencyType)
            .HasConversion(type => type.Value, value => CurrencyTypeEnum.FromValue(value));

        modelBuilder.Entity<CashRegister>().ToTable("CashRegisters").HasQueryFilter(filter => !filter.IsDeleted);

    }

    private void CreateConnectionString(IHttpContextAccessor contextAccessor, ApplicationDbContext applicationDbContext)
    {
        if (contextAccessor.HttpContext is null) return;
        string? companyId = contextAccessor.HttpContext.User.FindFirstValue("CompanyId");
        if (string.IsNullOrEmpty(companyId)) return;
        Company? company = applicationDbContext.Companies.FirstOrDefault(x => x.Id == Guid.Parse(companyId));
        if (company is null) return;

        CreateConnectionStringWithCompany(company);


    }


    private void CreateConnectionStringWithCompany(Company company)
    {
        if (string.IsNullOrEmpty(company.Database.UserId))
        {
            connectionString =
                $"Data Source={company.Database.Server};" +
                $"Initial Catalog={company.Database.DatabaseName};" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=True;" +
                "Trust Server Certificate=true;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";
        }
        else
        {
            connectionString =
                $"Data Source={company.Database.Server};" +
                $"Initial Catalog={company.Database.DatabaseName};" +
                "Integrated Security=False;" +
                $"User Id={company.Database.UserId};" +
                $"Password={company.Database.Password};" +
                "Connect Timeout=30;" +
                "Encrypt=True;" +
                "Trust Server Certificate=true;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False";
        }
    }
}