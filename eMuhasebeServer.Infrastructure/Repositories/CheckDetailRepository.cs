using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using eMuhasebeServer.Infrastructure.Context;
using GenericRepository;

namespace eMuhasebeServer.Infrastructure.Repositories;

public sealed class CheckDetailRepository: Repository<CheckDetail, CompanyDbContext>, ICheckDetailRepository
{
    public CheckDetailRepository(CompanyDbContext context) : base(context)
    {
    }
}
