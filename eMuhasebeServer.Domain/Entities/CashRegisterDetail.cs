using eMuhasebeServer.Domain.Abstractions;

namespace eMuhasebeServer.Domain.Entities;

public sealed class CashRegisterDetail : Entity
{
    public Guid CashRegisterId { get; set; }
    public decimal Debt { get; set; }
    public decimal Receivable { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public Guid? CashRegisterDetailId { get; set; }

    public CashRegisterDetail? CashRegisterDetailOpposite { get; set; }



}