using eMuhasebeServer.Domain.Entities;
using GenericRepository;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eMuhasebeServer.Domain.Repositories;

public interface ICheckDetailRepository : IRepository<CheckDetail>
{
    Task<CheckDetail> GetByIdAsync(Guid checkDetailId, CancellationToken cancellationToken);
    CheckDetail FirstOrDefault(Expression<Func<CheckDetail, bool>> predicate);
    Task<CheckDetail> FirstOrDefaultAsync(Expression<Func<CheckDetail, bool>> predicate, CancellationToken cancellationToken = default);

    EntityEntry<CheckDetail> Entry(CheckDetail entity);

}
=======

namespace eMuhasebeServer.Domain.Repositories;

public interface ICheckDetailRepository: IRepository<CheckDetail>
{
    
}
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
