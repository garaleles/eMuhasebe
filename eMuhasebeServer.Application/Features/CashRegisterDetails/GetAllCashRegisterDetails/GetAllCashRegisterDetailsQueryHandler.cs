using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisterDetails.GetAllCashRegisterDetails;

internal sealed class GetAllCashRegisterDetailsQueryHandler(
    ICashRegisterRepository cashRegisterRepository
) : IRequestHandler<GetAllCashRegisterDetailsQuery, Result<CashRegister>>
{
    public async Task<Result<CashRegister>> Handle(
        GetAllCashRegisterDetailsQuery request,
        CancellationToken cancellationToken
    )
    {
        CashRegister? cashRegister = await cashRegisterRepository
            .Where(x => x.Id == request.CashRegisterId)
            .Include(x =>
                Enumerable.Where<CashRegisterDetail>(x.Details!, x =>
                    x.Date >= request.StartDate && x.Date <= request.EndDate
                )
            )
            .FirstOrDefaultAsync(cancellationToken);

        if (cashRegister is null)
        {
            return Result<CashRegister>.Failure("Kayıt bulunamadı!");
        }

        return cashRegister;
    }
}