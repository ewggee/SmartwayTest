namespace SmartwayTest.Domain.Repositories;

public interface IDepartmentRepository
{
    Task<bool> IsDepartmentByIdExistsAsync(int departmentId);
}