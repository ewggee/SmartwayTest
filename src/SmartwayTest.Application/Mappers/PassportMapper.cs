using SmartwayTest.Contracts.DTOs;
using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Application.Mappers;

public static class PassportMapper
{
    public static Passport MapToEntity(this PassportDto d)
    {
        return new Passport
        {
            Type = d.Type,
            Number = d.Number
        };
    }
}
