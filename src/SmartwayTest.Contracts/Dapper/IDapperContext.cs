namespace SmartwayTest.Contracts.Dapper;

public interface IDapperContext
{
    void BeginTransaction();
    void Commit();
    void Rollback();

    /// <returns>Количество затронутых записей.</returns>
    Task<int> Execute(QueryObject queryObject);
    Task<T> ExecuteWithResult<T>(QueryObject queryObject);
    Task<T?> FirstOrDefault<T>(QueryObject queryObject);
    Task<IEnumerable<T>> ListOrEmpty<T>(QueryObject queryObject);
}
