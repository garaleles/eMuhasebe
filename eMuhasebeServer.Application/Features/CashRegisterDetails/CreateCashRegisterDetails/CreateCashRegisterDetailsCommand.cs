using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisterDetails.CreateCashRegisterDetails;

public sealed record CreateCashRegisterDetailsCommand(
    int Type,
    DateOnly Date,
    decimal Amount,
    Guid CashRegisterId,
    Guid? CashRegisterDetailId,
    decimal OppositeAmount,
    string Description
) : IRequest<Result<string>>;

