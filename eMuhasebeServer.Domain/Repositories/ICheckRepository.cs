using eMuhasebeServer.Domain.Entities;
using GenericRepository;

namespace eMuhasebeServer.Domain.Repositories;

<<<<<<< HEAD
public interface ICheckRepository : IRepository<Check>
{
    Task<Check> GetByIdAsync(Guid checkId, CancellationToken cancellationToken);
    IQueryable<Check> Query();
    void UpdateCheckAndDetail(Check check, CheckDetail checkDetail);
}
=======
public interface ICheckRepository: IRepository<Check>
{
    
}
>>>>>>> f5ce1916f9f2464a550c86c2634782668fce3af3
