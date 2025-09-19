// Application/Mappers/CarMappingExtensions.cs
using Application.DTOs.Cars;
using Domain.Entities.Cars;

namespace Application.Mappers;

public static class CarMappingExtensions
{
    public static Car ToEntity(this CreateCarDto dto)
    {
        return new Car(dto.Model, dto.AccountId);
    }
    

    public static void Map(this Car target, Car source)
    {
        target.Model = source.Model;
        target.AccountId = source.AccountId;
        target.Account = source.Account;
    }

    public static void MapFromDto(this Car target, UpdateCarDto dto)
    {
        target.Model = dto.Model;
    }
}