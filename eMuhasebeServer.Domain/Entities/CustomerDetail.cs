﻿using eMuhasebeServer.Domain.Abstractions;
using eMuhasebeServer.Domain.Enums;

namespace eMuhasebeServer.Domain.Entities;

public sealed class CustomerDetail: Entity
{
    public Guid CustomerId { get; set; }
    public string ProcessNumber { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public CustomerDetailTypeEnum Type { get; set; }=CustomerDetailTypeEnum.CashRegister;
    public string Description { get; set; } = string.Empty;
    public decimal DepositAmount { get; set; } //Giriş
    public decimal WithdrawalAmount { get; set; } //Çıkış
    public Guid? BankDetailId { get; set; }
    public Guid? CashRegisterDetailId { get; set; }
    public Guid? InvoiceId { get; set; }
    public Guid? CollectionId { get; set; }
    public Guid? PaymentId { get; set; }
    public Guid? CheckRegisterPayrollId { get; set; }
<<<<<<< HEAD
    public Guid? ChequeissuePayrollId { get; set; }
=======
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3

    
}