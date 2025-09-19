using Application.DTOs.Cars;
using Domain.Entities.Cars;

namespace Application.Interfaces.Cars;

public interface ICarService
{
    Task<Car?> Create(CreateCarDto request);
    Task<List<Car>> GetAll();
    Task<Car?> GetById(int id);
    Task<bool> Update(int carId, UpdateCarDto request);
    Task<bool> Delete(int carId);
}