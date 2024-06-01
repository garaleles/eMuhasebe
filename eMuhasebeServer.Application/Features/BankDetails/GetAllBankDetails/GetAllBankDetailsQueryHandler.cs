using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eMuhasebeServer.Application.Features.BankDetails.GetAllBankDetails;

sealed class GetAllBankDetailsQueryHandler(
    IBankRepository bankRepository
) : IRequestHandler<GetAllBankDetailsQuery, Result<Bank>>
{
    public async Task<Result<Bank>> Handle(GetAllBankDetailsQuery request, CancellationToken cancellationToken)
    {
        Bank? bank =
            await bankRepository
                .Where(p => p.Id == request.BankId)
                .Include(p => Enumerable.Where<BankDetail>(p.Details!, p => p.Date >= request.StartDate && p.Date <= request.EndDate))
                .FirstOrDefaultAsync(cancellationToken);

        if (bank is null)
        {
            return Result<Bank>.Failure("Banka hareketi bulunamadı");

        }

        return bank;
    }
}