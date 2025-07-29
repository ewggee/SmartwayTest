using SmartwayTest.Domain.Exceptions.Common;

namespace SmartwayTest.Domain.Exceptions.Department;

public class DepartmentNotFoundException(int id) : EntityNotFoundException(nameof(Entities.Department), id)
{ }
