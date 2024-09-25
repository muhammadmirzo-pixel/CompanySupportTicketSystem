namespace CompanySupportTicketSystem.Data.IRepositories;

public interface IRepostiory<TEntity>
{
    public Task<bool> InsertAsync(TEntity entity);
    public Task<bool> UpdateAsync(TEntity entity);
    public Task<bool> DeleteByIdAsync(long id);
    public Task<TEntity> RetrievByIdAsync(long id);
    public Task<List<TEntity>> RetrievAllAsync();
}
