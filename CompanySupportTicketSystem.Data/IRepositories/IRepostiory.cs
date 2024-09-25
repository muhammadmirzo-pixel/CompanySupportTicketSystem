namespace CompanySupportTicketSystem.Data.IRepositories;

public interface IRepostiory<TEntity>
{
    public Task<bool> InsertAsync(TEntity entity);
    public Task<bool> UpdateAsync(TEntity entity);
    public Task<bool> DeleteByIdAsync(int id);
    public Task<TEntity> RetriewByIdAsync(int id);
    public Task<List<TEntity>> GetAllAsync();
}
