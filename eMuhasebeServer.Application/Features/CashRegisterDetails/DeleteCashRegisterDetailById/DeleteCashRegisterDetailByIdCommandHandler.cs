using eMuhasebeServer.Application.Services;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisterDetails.DeleteCashRegisterDetailById;

internal sealed class DeleteCashRegisterDetailByIdCommandHandler(
    ICashRegisterRepository cashRegisterRepository,
    ICashRegisterDetailRepository cashRegisterDetailRepository,
    IUnitOfWorkCompany unitOfWorkCompany,
    ICacheService cacheService
) : IRequestHandler<DeleteCashRegisterDetailByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCashRegisterDetailByIdCommand request,
        CancellationToken cancellationToken)
    {
        CashRegisterDetail? cashRegisterDetail =
            await cashRegisterDetailRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id,
                cancellationToken);

        if (cashRegisterDetail is null)
        {
            return Result<string>.Failure("Kasa hareketi bulunamadı!");
        }

        CashRegister? cashRegister =
            await cashRegisterRepository.GetByExpressionWithTrackingAsync(
                x => x.Id == cashRegisterDetail.CashRegisterId, cancellationToken);

        if (cashRegister is null)
        {
            return Result<string>.Failure("Kasa bulunamadı!");
        }

        cashRegister.Debt -= cashRegisterDetail.Debt;
        cashRegister.Receivable -= cashRegisterDetail.Receivable;

        if (cashRegisterDetail.CashRegisterDetailId is not null)
        {
            CashRegisterDetail? oppositeCashRegisterDetail =
                await cashRegisterDetailRepository.GetByExpressionWithTrackingAsync(
                    x => x.Id == cashRegisterDetail.CashRegisterDetailId, cancellationToken);

            if (oppositeCashRegisterDetail is null)
            {
                return Result<string>.Failure("Kasa hareketi bulunamadı!");
            }

            CashRegister? oppositeCashRegister =
                await cashRegisterRepository.GetByExpressionWithTrackingAsync(
                    x => x.Id == oppositeCashRegisterDetail.CashRegisterId, cancellationToken);

            if (oppositeCashRegister is null)
            {
                return Result<string>.Failure("Kasa bulunamadı!");
            }

            oppositeCashRegister.Debt -= oppositeCashRegisterDetail.Debt;
            oppositeCashRegister.Receivable -= oppositeCashRegisterDetail.Receivable;

        }


        cashRegisterDetailRepository.Delete(cashRegisterDetail);
        await unitOfWorkCompany.SaveChangesAsync(cancellationToken);
        cacheService.Remove("cashRegisters");
        return "Kasa hareketi silindi!";

    }
}




