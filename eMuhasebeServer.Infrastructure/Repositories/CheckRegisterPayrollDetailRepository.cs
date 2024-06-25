using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using eMuhasebeServer.Infrastructure.Context;
using GenericRepository;

namespace eMuhasebeServer.Infrastructure.Repositories;

<<<<<<< HEAD
public sealed class CheckRegisterPayrollDetailRepository : Repository<CheckRegisterPayrollDetail, CompanyDbContext>, ICheckRegisterPayrollDetailRepository
{

    public CheckRegisterPayrollDetailRepository(CompanyDbContext context) : base(context)
    {
    }
}
=======
public sealed class CheckRegisterPayrollDetailRepository: Repository<CheckRegisterPayrollDetail, CompanyDbContext>, ICheckRegisterPayrollDetailRepository
{
    public CheckRegisterPayrollDetailRepository(CompanyDbContext context) : base(context)
    {
    }
}
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
