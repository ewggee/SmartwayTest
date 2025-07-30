namespace SmartwayTest.Domain.Exceptions.Common;

public class EntityAlreadyExistsException(string entityName) : Exception($"{entityName} already exists.")
{ }
