namespace SmartwayTest.Domain.Exceptions.Employee;

public class EmployeeNotFoundException(int id) : EntityNotFoundException(nameof(Entities.Employee), id)
{ }
