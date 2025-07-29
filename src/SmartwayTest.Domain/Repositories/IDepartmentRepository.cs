
namespace SmartwayTest.DataAccess.Repositories;

public interface IDepartmentRepository
{
    Task<bool> IsDepartmentByIdExistsAsync(int departmentId);
}