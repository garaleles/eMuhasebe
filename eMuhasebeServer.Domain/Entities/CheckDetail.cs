using eMuhasebeServer.Domain.Abstractions;
using eMuhasebeServer.Domain.Enums;

namespace eMuhasebeServer.Domain.Entities;

public class CheckDetail : Entity
{
    public Guid CheckId { get; set; }
    public Check Check { get; set; } = null!;
    public CheckStatus Status { get; set; } = CheckStatus.InPortfolio;
    public DateOnly DueDate { get; set; }
    public DateOnly? IssuedDate { get; set; }
    public DateOnly? CollectedDate { get; set; }
    public string CheckNumber { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BranchName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public string? Debtor { get; set; }
    public string? Creditor { get; set; }
    public string? Endorser { get; set; }
    public Guid? CheckRegisterPayrollDetailId { get; set; }
    public CheckRegisterPayrollDetail? CheckRegisterPayrollDetail { get; set; }
}
