using INNOEcoSystem.Data.DbContexts;
using INNOEcoSystem.Data.IRepositories;
using INNOEcoSystem.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INNOEcoSystem.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    AppDbContext dbContext;
    DbSet<TEntity> dbSet;
    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        this.dbSet.Remove(entity);

        return await this.dbContext.SaveChangesAsync() > 0;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await this.dbSet.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return entry.Entity;
    }

    public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null)
    {
        var query = expression is null ? dbSet : dbSet.Where(expression);
        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }

    public async Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        => await this.SelectAll(expression, includes).FirstOrDefaultAsync();

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = dbContext.Update(entity);
        await dbContext.SaveChangesAsync();

        return entry.Entity;
    }
}
