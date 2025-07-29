namespace SmartwayTest.Domain.Exceptions;

/// <summary>
/// Формирует сообщение исключения в формате:<br>
/// <paramref name="entityName"/> with id <paramref name="id"/> not found.</br>
/// </summary>
/// <param name="entityName">Название сущности.</param>
/// <param name="id">ID сущности.</param>
public abstract class EntityNotFoundException(string entityName, int id)
    : Exception($"{entityName} with id {id} not found.")
{ }
