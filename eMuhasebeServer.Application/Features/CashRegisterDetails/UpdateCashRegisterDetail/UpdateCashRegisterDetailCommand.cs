using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisterDetails.UpdateCashRegisterDetail;

public sealed record UpdateCashRegisterDetailCommand(
    Guid Id,
    int Type,
    decimal Amount,
    Guid CashRegisterId,
    string Description
    ) : IRequest<Result<string>>;