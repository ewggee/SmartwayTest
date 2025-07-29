namespace SmartwayTest.Domain.Exceptions.Common;

/// <summary>
/// Формирует сообщение исключения в формате:<br>
/// <paramref name="entityName"/> with id <paramref name="id"/> not found.</br>
/// </summary>
public abstract class EntityNotFoundException : Exception
{ 
    /// <param name="entityName">Название сущности.</param>
    /// <param name="id">ID сущности.</param>
    public EntityNotFoundException(string entityName, int id) : base($"{entityName} with id {id} not found.")
    { }

    /// <param name="entityName">Название сущности.</param>
    public EntityNotFoundException(string entityName) : base($"{entityName} not found.")
    { }
}
