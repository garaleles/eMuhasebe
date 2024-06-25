using eMuhasebeServer.Application.Services;
using eMuhasebeServer.Domain.Entities;
<<<<<<< HEAD
using eMuhasebeServer.Domain.Enums;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
=======
using eMuhasebeServer.Domain.Repositories;
using MediatR;
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
using TS.Result;

namespace eMuhasebeServer.Application.Features.CheckRegisterPayrolls.DeleteChecRegisterPayrollById;

internal sealed class
    DeleteChecRegisterPayrollByIdCommandHandler : IRequestHandler<DeleteChecRegisterPayrollByIdCommand, Result<string>>
{
    private readonly ICheckRegisterPayrollRepository _checkRegisterPayrollRepository;
    private readonly ICheckRegisterPayrollDetailRepository _checkRegisterPayrollDetailRepository;
    private readonly IUnitOfWorkCompany _unitOfWorkCompany;
    private readonly ICacheService _cacheService;
    private readonly ICheckDetailRepository _checkDetailRepository;
    private readonly ICheckRepository _checkRepository;
    private readonly ICustomerDetailRepository _customerDetailRepository;
    private readonly ICustomerRepository _customerRepository;
<<<<<<< HEAD
    private readonly ILogger<DeleteChecRegisterPayrollByIdCommandHandler> _logger;


    public DeleteChecRegisterPayrollByIdCommandHandler(
        ICheckRegisterPayrollRepository checkRegisterPayrollRepository,
=======



    public DeleteChecRegisterPayrollByIdCommandHandler(ICheckRegisterPayrollRepository checkRegisterPayrollRepository,
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
        IUnitOfWorkCompany unitOfWorkCompany,
        ICacheService cacheService,
        ICheckDetailRepository checkDetailRepository,
        ICustomerDetailRepository customerDetailRepository,
        ICustomerRepository customerRepository,
        ICheckRepository checkRepository,
<<<<<<< HEAD
        ILogger<DeleteChecRegisterPayrollByIdCommandHandler> logger,
        ICheckRegisterPayrollDetailRepository checkRegisterPayrollDetailRepository)
=======
        ICheckRegisterPayrollDetailRepository checkRegisterPayrollDetailRepository)

>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
    {
        _checkRegisterPayrollRepository = checkRegisterPayrollRepository;
        _unitOfWorkCompany = unitOfWorkCompany;
        _cacheService = cacheService;
        _checkDetailRepository = checkDetailRepository;
        _customerDetailRepository = customerDetailRepository;
        _customerRepository = customerRepository;
        _checkRepository = checkRepository;
<<<<<<< HEAD
        _logger = logger;
=======
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
        _checkRegisterPayrollDetailRepository = checkRegisterPayrollDetailRepository;
    }

public async Task<Result<string>> Handle(DeleteChecRegisterPayrollByIdCommand request, CancellationToken cancellationToken)
{
<<<<<<< HEAD
    using var transaction = await _unitOfWorkCompany.BeginTransactionAsync();

    try
    {
        // 1. CheckRegisterPayroll Kaydını Getirme
        var checkRegisterPayroll = await _checkRegisterPayrollRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);
        if (checkRegisterPayroll == null)
        {
            return Result<string>.Failure("Bordro bulunamadı.");
        }

        // 2. İlgili Müşteri Kaydını Getirme
        var customer = await _customerRepository.GetByExpressionAsync(p => p.Id == checkRegisterPayroll.CustomerId, cancellationToken);
        if (customer == null)
        {
            return Result<string>.Failure("Cari bulunamadı.");
        }

        // 3. CheckRegisterPayrollDetail Kayıtlarını Silme
        var checkRegisterPayrollDetails = await _checkRegisterPayrollDetailRepository.GetAll()
            .Where(d => d.CheckRegisterPayrollId == checkRegisterPayroll.Id)
            .ToListAsync(cancellationToken);

        foreach (var detail in checkRegisterPayrollDetails)
        {
            _checkRegisterPayrollDetailRepository.Delete(detail);
        }
        
        // 4. CheckDetail Kayıtlarını Silme (Join yerine Where ve Contains kullanarak)
        var checkRegisterPayrollDetailIds = checkRegisterPayrollDetails.Select(crpd => crpd.Id).ToList();

        // 4. CheckDetail Kayıtlarını Silme
        var checkDetailsToDelete = await _checkDetailRepository.GetAll()
            .Where(cd => cd.CheckRegisterPayrollDetailId.HasValue && checkRegisterPayrollDetailIds.Contains(cd.CheckRegisterPayrollDetailId.Value))
            .ToListAsync(cancellationToken);

        foreach (var checkDetail in checkDetailsToDelete)
        {
            _checkDetailRepository.Delete(checkDetail);
        }

// 5. Check Kayıtlarını Güncelleme veya Silme (İş Mantığına Göre)
        var checksToUpdateOrDelete = await _checkRepository.GetAll()
            .Where(c => c.CheckRegisterPayrollDetailId.HasValue && checkRegisterPayrollDetailIds.Contains(c.CheckRegisterPayrollDetailId.Value))
            .ToListAsync(cancellationToken);

        foreach (var check in checksToUpdateOrDelete) // Bu satırı düzelttim
        {
            // İlişkili CheckDetail Kaydını Sil (Eğer varsa)
            if (check.CheckDetail != null)
            {
                _checkDetailRepository.Delete(check.CheckDetail);
            }

            // Check Kaydını Sil
            _checkRepository.Delete(check);
        }

// Değişiklikleri Veritabanına Kaydetme
        await _unitOfWorkCompany.SaveChangesAsync(cancellationToken);


        // 6. CustomerDetail Kaydını Silme
        var customerDetail = await _customerDetailRepository.GetByExpressionAsync(p => p.CheckRegisterPayrollId == checkRegisterPayroll.Id, cancellationToken);
        if (customerDetail != null)
        {
            _customerDetailRepository.Delete(customerDetail);
        }

        // 7. Müşteri Bakiyesini Güncelleme
        customer.WithdrawalAmount -= checkRegisterPayroll.PayrollAmount;
        _customerRepository.Update(customer);

        // 8. CheckRegisterPayroll Kaydını Silme
        _checkRegisterPayrollRepository.Delete(checkRegisterPayroll);

        // 9. Değişiklikleri Veritabanına Kaydetme
        await _unitOfWorkCompany.SaveChangesAsync(cancellationToken);

        // 10. Cache Temizleme İşlemleri (Gerekirse)
        _cacheService.Remove("checkRegisterPayrolls");
        _cacheService.Remove("customers");
        _cacheService.Remove("customerDetails");
        _cacheService.Remove("checks");
        _cacheService.Remove("checkDetails");

        await transaction.CommitAsync();
        return Result<string>.Succeed("Bordro başarıyla silindi.");
    }
    catch (Exception ex)
    {
        await transaction.RollbackAsync();
        _logger.LogError(ex, "Bordro silme işlemi sırasında bir hata oluştu.");
        return Result<string>.Failure($"Bir hata oluştu: {ex.Message}");
    }
}




}


=======
    // Get the CheckRegisterPayroll to delete
    var checkRegisterPayroll = await _checkRegisterPayrollRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

    if (checkRegisterPayroll is null)
    {
        return Result<string>.Failure("Bordro bulunamadı");
    }

    // Get the customer
    Customer? customer = await _customerRepository.GetByExpressionAsync(p => p.Id == checkRegisterPayroll.CustomerId, cancellationToken);

    if (customer is null)
    {
        return Result<string>.Failure("Cari bulunamadı");
    }

    // Decrease the customer's withdrawal amount by the payroll amount
    customer.WithdrawalAmount -= checkRegisterPayroll.PayrollAmount;
    _customerRepository.Update(customer);

    // Delete the CustomerDetail entry for the check deposit
    var customerDetail = await _customerDetailRepository.GetByExpressionAsync(p => p.CheckRegisterPayrollId == checkRegisterPayroll.Id, cancellationToken);
    if (customerDetail != null)
    {
        _customerDetailRepository.Delete(customerDetail);
    }

    // Delete  Check and CheckDetail records
    
   
    
    
    
    // Delete the CheckRegisterPayroll
    _checkRegisterPayrollRepository.Delete(checkRegisterPayroll);

    // Save changes to the database
    await _unitOfWorkCompany.SaveChangesAsync(cancellationToken);

    // Optionally update cache
    _cacheService.Remove("checkRegisterPayrolls");
    _cacheService.Remove("customers");
    _cacheService.Remove("customerDetails");
    _cacheService.Remove("checks");
    _cacheService.Remove("checkDetails");

    return Result<string>.Succeed("Bordro başarıyla silindi.");
}

}
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
