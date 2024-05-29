using eMuhasebeServer.Domain.Abstractions;
using eMuhasebeServer.Domain.Enums;

namespace eMuhasebeServer.Domain.Entities;

public sealed class CashRegister : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal Debt { get; set; }
    public decimal Receivable { get; set; }
    public decimal Balance { get; set; }
    public CurrencyTypeEnum CurrencyType { get; set; } = CurrencyTypeEnum.TL;

    public ICollection<CashRegisterDetail>? Details { get; set; } = new List<CashRegisterDetail>();


}