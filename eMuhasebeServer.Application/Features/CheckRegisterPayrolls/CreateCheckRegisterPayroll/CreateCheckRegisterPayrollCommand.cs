using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Enums;
using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CheckRegisterPayrolls.CreateCheckRegisterPayroll;

public sealed record CreateCheckRegisterPayrollCommand(
<<<<<<< HEAD
=======
    int TypeValue,
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
    DateOnly Date,
    string PayrollNumber,
    Guid? CustomerId,
    decimal PayrollAmount,
    string? Description,
    int CheckCount,
    DateOnly AverageMaturityDate,
    List<CheckRegisterPayrollDetail> Details
) : IRequest<Result<string>>;
