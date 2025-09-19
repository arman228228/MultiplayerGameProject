using Domain.Entities.Cars;

namespace Application.Interfaces.Cars;

// Data access

public interface ICarRepository
{
    Task<Car> Create(Car car);
    Task<Car?> GetById(int id);
    Task<Car?> GetByAccountAndModel(int accountId, string model);
    Task<List<Car>> GetAll();
    Task<bool> Update(Car car);
    Task<bool> Delete(int id);
}