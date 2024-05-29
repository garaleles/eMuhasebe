using eMuhasebeServer.Application.Services;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisterDetails.UpdateCashRegisterDetail;

internal sealed class UpdateCashRegisterDetailCommandHandler(
    ICashRegisterRepository cashRegisterRepository,
    ICashRegisterDetailRepository cashRegisterDetailRepository,
    IUnitOfWorkCompany unitOfWorkCompany,
    ICacheService cacheService
) : IRequestHandler<UpdateCashRegisterDetailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateCashRegisterDetailCommand request, CancellationToken cancellationToken)
    {

        CashRegisterDetail? cashRegisterDetail =
            await cashRegisterDetailRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);

        if (cashRegisterDetail is null)
        {
            return Result<string>.Failure("Kasa hareketi bulunamadı!");
        }

        CashRegister? cashRegister = await cashRegisterRepository.GetByExpressionWithTrackingAsync(x => x.Id == cashRegisterDetail.CashRegisterId, cancellationToken);

        if (cashRegister is null)
        {
            return Result<string>.Failure("Kasa bulunamadı!");
        }

        cashRegister.Debt -= cashRegisterDetail.Debt;
        cashRegister.Receivable -= cashRegisterDetail.Receivable;

        cashRegister.Debt += request.Type == 0 ? request.Amount : 0;
        cashRegister.Receivable += request.Type == 1 ? request.Amount : 0;

        cashRegisterDetail.Debt = request.Type == 0 ? request.Amount : 0;
        cashRegisterDetail.Receivable = request.Type == 1 ? request.Amount : 0;
        cashRegisterDetail.Description = request.Description;

        await unitOfWorkCompany.SaveChangesAsync(cancellationToken);





        cacheService.Remove("cashRegisters");
        return "Kasa hareketi başarıyla güncellendi!";
    }
}