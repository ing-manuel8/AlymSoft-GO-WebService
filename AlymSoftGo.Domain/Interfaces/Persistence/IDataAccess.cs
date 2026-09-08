namespace AlymSoftGo.Domain.Interfaces.Persistence
{
    public interface IDataAccess
    {
        Task<TData> ExecuteSpAsync<TData>(string spName, Dictionary<string, object>? @params = null) where TData : class, new();
        Task<(T1 Data1, T2 Data2)> ExecuteSpAsync<T1, T2>(string spName, Dictionary<string, object>? @params = null) where T1 : class, new() where T2 : class, new();
        Task ExecuteSpAsync(string spName, Dictionary<string, object>? @params = null);
    }
}
