namespace SmartwayTest.Domain.Repositories;

public interface ITransactionable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
}
