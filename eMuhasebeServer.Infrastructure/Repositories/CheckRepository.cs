using eMuhasebeServer.Domain.Entities;
using eMuhasebeServer.Domain.Repositories;
using eMuhasebeServer.Infrastructure.Context;
using GenericRepository;

namespace eMuhasebeServer.Infrastructure.Repositories;

public sealed class CheckRepository: Repository<Check, CompanyDbContext>, ICheckRepository
{
    public CheckRepository(CompanyDbContext context) : base(context)
    {
    }
}
