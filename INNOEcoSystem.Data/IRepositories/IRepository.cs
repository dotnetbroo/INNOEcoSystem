using INNOEcoSystem.Domain.Commons;
using System.Linq.Expressions;

namespace INNOEcoSystem.Data.IRepositories;

public interface IApplicationRepository<TEntity> where TEntity : Auditable
{
    Task<bool> DeleteAsync(long id);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> InsertAsync(TEntity enitity);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
    IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null);
}
