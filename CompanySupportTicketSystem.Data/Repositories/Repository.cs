using Newtonsoft.Json;
using CompanySupportTicketSystem.Domain.Common;
using CompanySupportTicketSystem.Domain.Entities;
using CompanySupportTicketSystem.Data.IRepositories;
using CompanySupportTicketSystem.Domain.Configurations;


namespace CompanySupportTicketSystem.Data.Repositories;

public class Repository<TEntity> : IRepostiory<TEntity> where TEntity : Auditable
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
                path = DatabasePath.COMPANY_PATH;
                break;
            case nameof(Ticket):
                path = DatabasePath.TICKET_PATH;
                break;
            case nameof(User):
                path = DatabasePath.USER_PATH;
                break;
            default:
                throw new NotSupportedException($"Entity type {entityName} is not supported");
                
        }
    }
    public async Task<bool> DeleteByIdAsync(long id)
    {
        List<TEntity> infos = new List<TEntity>();
        bool isAvaible = false;
        var entities = await this.RetrievAllAsync();
        await File.WriteAllTextAsync(path, "");

        isAvaible = entities.Any(e => e.Id == id);
        infos.AddRange(entities.Where(e => e.Id != id));

        var str = JsonConvert.SerializeObject(infos, Formatting.Indented);
        await File.AppendAllTextAsync(path, str);
        return isAvaible;
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
        entity.Id = await GenerateIdAsync();
        var entities = await this.RetrievAllAsync();
        entities.Add(entity);
        var str = JsonConvert.SerializeObject(entities,Formatting.Indented);
        File.WriteAllTextAsync(str,path);
        return true;
    }

    public async Task<TEntity> RetrievByIdAsync(long id)
    {
        var entities = await this.RetrievAllAsync();
        return entities.FirstOrDefault(e => e.Id == id);
    }

    public async Task<bool> UpdateAsync(TEntity entity)
    {
        bool IsAvailable = false;
        var entities = await this.RetrievAllAsync();
        await File.WriteAllTextAsync(path, "[]");
        await this.DeleteByIdAsync(entity.Id);
        entities.Add(entity);

        var str = JsonConvert.SerializeObject(entities, Formatting.Indented);
        await File.WriteAllTextAsync(path, str);
        return IsAvailable;
    }
    private async Task<long> GenerateIdAsync()
    {
        var items = await this.RetrievAllAsync();
        if (items.Count == 0)
            return 1;
        var lastId = items.Max(x => x.Id);
        return ++lastId;    
    }
}
