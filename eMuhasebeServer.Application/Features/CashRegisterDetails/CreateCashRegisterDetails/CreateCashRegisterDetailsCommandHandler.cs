using eMuhasebeServer.Application.Services;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisterDetails.CreateCashRegisterDetails;

internal sealed class CreateCashRegisterDetailsCommandHandler(
    ICashRegisterRepository cashRegisterRepository,
    ICashRegisterDetailRepository cashRegisterDetailRepository,
    IUnitOfWorkCompany unitOfWorkCompany,
    ICacheService cacheService
) : IRequestHandler<CreateCashRegisterDetailsCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCashRegisterDetailsCommand request, CancellationToken cancellationToken)
    {
        CashRegister cashRegister =
            await cashRegisterRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.CashRegisterId,
                cancellationToken);

        cashRegister.Debt += (request.Type == 0 ? request.OppositeAmount : 0);
        cashRegister.Receivable += (request.Type == 1 ? request.OppositeAmount : 0);




        CashRegisterDetail cashRegisterDetail = new()
        {
            Date = request.Date,
            Debt = request.Type == 0 ? request.Amount : 0,
            Receivable = request.Type == 1 ? request.Amount : 0,
            CashRegisterDetailId = request.CashRegisterDetailId,
            CashRegisterId = request.CashRegisterId,
            Description = request.Description
        };

        await cashRegisterDetailRepository.AddAsync(cashRegisterDetail, cancellationToken);

        if (request.CashRegisterDetailId is not null)
        {
            CashRegisterDetail oppositeCashRegister =
                await cashRegisterDetailRepository.GetByExpressionWithTrackingAsync(x =>
                    x.Id == request.CashRegisterDetailId, cancellationToken);

            oppositeCashRegister.Debt += (request.Type == 1 ? request.OppositeAmount : 0);
            oppositeCashRegister.Receivable += (request.Type == 0 ? request.OppositeAmount : 0);

            CashRegisterDetail oppositeCashRegisterDetail = new()
            {
                Date = request.Date,
                Debt = request.Type == 1 ? request.OppositeAmount : 0,
                Receivable = request.Type == 0 ? request.OppositeAmount : 0,
                CashRegisterDetailId = cashRegisterDetail.Id,
                CashRegisterId = (Guid)request.CashRegisterDetailId,
                Description = request.Description
            };

            await cashRegisterDetailRepository.AddAsync(oppositeCashRegisterDetail, cancellationToken);
        }

        await unitOfWorkCompany.SaveChangesAsync(cancellationToken);

        cacheService.Remove("cashRegisters");

        return "Kasa hareketi başarıyla kaydedildi.";
    }
}