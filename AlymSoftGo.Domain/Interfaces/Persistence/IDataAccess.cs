namespace AlymSoftGo.Domain.Interfaces.Persistence
{
    public interface IDataAccess
    {
        Task<TData> ExecuteSpAsync<TData>(string spName, Dictionary<string, object>? @params = null) where TData : class, new();
        Task ExecuteSpAsync(string spName, Dictionary<string, object>? @params = null);
    }
}
