using eMuhasebeServer.Application.Services;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using TS.Result;

namespace eMuhasebeServer.Application.Features.CashRegisters.DeleteCashRegisterById;

internal sealed class DeleteCashRegisterByIdCommandHandler(
    ICashRegisterRepository cashRegisterRepository,
    IUnitOfWorkCompany unitOfWorkCompany,
    ICacheService cacheService
) : IRequestHandler<DeleteCashRegisterByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(
        DeleteCashRegisterByIdCommand request,
        CancellationToken cancellationToken
    )
    {
        CashRegister? cashRegister = await cashRegisterRepository.GetByExpressionWithTrackingAsync(
            x => x.Id == request.Id,
            cancellationToken
        );
        if (cashRegister is null)
        {
            return Result<string>.Failure("Kayıt bulunamadı");
        }

        cashRegister.IsDeleted = true;
        await unitOfWorkCompany.SaveChangesAsync(cancellationToken);
        cacheService.Remove("cacheRegisters");
        return "Kasa Kaydı Silindi.";
    }
}