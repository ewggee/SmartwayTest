using SmartwayTest.Domain.Exceptions.Common;

namespace SmartwayTest.Domain.Exceptions.Company;

public class CompanyNotFoundException(int id) : EntityNotFoundException(nameof(Entities.Company), id)
{ }
