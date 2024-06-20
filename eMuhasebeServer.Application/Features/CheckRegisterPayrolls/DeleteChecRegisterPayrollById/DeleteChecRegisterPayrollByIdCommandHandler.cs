using eMuhasebeServer.Application.Services;
using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using MediatR;
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



    public DeleteChecRegisterPayrollByIdCommandHandler(ICheckRegisterPayrollRepository checkRegisterPayrollRepository,
        IUnitOfWorkCompany unitOfWorkCompany,
        ICacheService cacheService,
        ICheckDetailRepository checkDetailRepository,
        ICustomerDetailRepository customerDetailRepository,
        ICustomerRepository customerRepository,
        ICheckRepository checkRepository,
        ICheckRegisterPayrollDetailRepository checkRegisterPayrollDetailRepository)

    {
        _checkRegisterPayrollRepository = checkRegisterPayrollRepository;
        _unitOfWorkCompany = unitOfWorkCompany;
        _cacheService = cacheService;
        _checkDetailRepository = checkDetailRepository;
        _customerDetailRepository = customerDetailRepository;
        _customerRepository = customerRepository;
        _checkRepository = checkRepository;
        _checkRegisterPayrollDetailRepository = checkRegisterPayrollDetailRepository;
    }

public async Task<Result<string>> Handle(DeleteChecRegisterPayrollByIdCommand request, CancellationToken cancellationToken)
{
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