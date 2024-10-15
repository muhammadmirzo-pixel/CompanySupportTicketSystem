using Newtonsoft.Json;
using CompanySupportTicketSystem.Domain.Common;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Domain.Configurations;


namespace CompanySupportTicketSystem.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public List<TEntity> entities;
    public string path = "";

    public Repository()
    {
        entities = new List<TEntity>();
        var entityName = typeof(TEntity).Name;
        switch (entityName)
        {
            case nameof(Company):
                path = DatabasePath.COMPANY_PATH;
                break;
            case nameof(CompanyCategory):
                path = DatabasePath.COMPANY_CATEGORY;
                break;
            case nameof(Ticket):
                path = DatabasePath.TICKET_PATH;
                break;
            case nameof(User):
                path = DatabasePath.USER_PATH;
                break;
            case nameof(Order):
                path = DatabasePath.ORDER_PATH;
                break;

            default:
                throw new NotSupportedException($"Entity type {entityName} is not supported");
                
        }
    }
    public async Task<bool> DeleteByIdAsync(long id)
    {
        var entities = RetrievAllAsync().Result.Where(x => x.Id != id);
        await WriteToFileAsync(entities);
        return true;
    }

    public async Task<List<TEntity>> RetrievAllAsync()
    {
        string models = await File.ReadAllTextAsync(path);
        if(string.IsNullOrEmpty(models))
            models = "[]";
        var results = JsonConvert.DeserializeObject<List<TEntity>>(models);
        return results;
    }

    public async Task<bool> InsertAsync(TEntity entity)
    {
        var entities =  RetrievAllAsync().Result.ToList();
        entity.Id = await GenerateIdAsync();
        entity.CreatedAt = DateTime.Now;
        entities.Add(entity);
        await WriteToFileAsync(entities);
        return true;
    }

    public async Task<TEntity> RetrievByIdAsync(long id)
    {
        var entities = await this.RetrievAllAsync();
        return entities.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var entities = await this.RetrievAllAsync();
        var models = entities.
            Where(e => e.Id != entity.Id).ToList();

        models.Add(entity);
        models.OrderBy(m => m.Id);
        await WriteToFileAsync(models);
        return true;
    }
    private async Task<long> GenerateIdAsync()
    {
        var items = await this.RetrievAllAsync();
        if (items.Count == 0)
            return 1;
        var lastId = items.Max(x => x.Id);
        return ++lastId;    
    }
    private async Task WriteToFileAsync(IEnumerable<TEntity> entities)
    {
        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(path, str);
    }
}
