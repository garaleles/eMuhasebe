using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eMuhasebeServer.Application.Features.ExpenseDetails.GetAllExpenseDetails;

internal sealed class GetAllExpenseDetailsQueryHandler(
    IExpenseRepository expenseRepository
) : IRequestHandler<GetAllExpenseDetailsQuery, Result<Expense>>
{
    public async Task<Result<Expense>> Handle(GetAllExpenseDetailsQuery request, CancellationToken cancellationToken)
    {
        Expense? expense =
            await expenseRepository
                .Where(p => p.Id == request.ExpenseId)
                .Include(p => Enumerable.Where<ExpenseDetail>(p.Details!, p => p.Date >= request.StartDate && p.Date <= request.EndDate))
                .FirstOrDefaultAsync(cancellationToken);

        if (expense is null)
        {
            return Result<Expense>.Failure("Gider bulunamadı");

        }

        return expense;
    }
}