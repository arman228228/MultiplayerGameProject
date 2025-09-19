using Application.DTOs.Cars;
using Application.Interfaces.Accounts;
using Application.Interfaces.Cars;
using Application.Mappers;
using Domain.Entities.Cars;

namespace Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IAccountRepository _accountRepository;

    public CarService(ICarRepository carRepository, IAccountRepository accountRepository)
    {
        _carRepository = carRepository;
        _accountRepository = accountRepository;
    }
    
    public async Task<Car?> Create(CreateCarDto request)
    {
        var account = await _accountRepository.GetById(request.AccountId); 
        if (account == null) return null;
        
        var result = await _carRepository.GetByAccountAndModel(request.AccountId, request.Model);
        if (result != null) return null;
    
        return await _carRepository.Create(request.ToEntity());
    }
    
    public Task<List<Car>> GetAll()
    {
        return _carRepository.GetAll();
    }
    
    public Task<Car?> GetById(int id)
    {
        return _carRepository.GetById(id);
    }
    
    public async Task<bool> Update(int carId, UpdateCarDto request)
    {
        var car = await _carRepository.GetById(carId);
        if (car == null) return false;

        car.MapFromDto(request);
        return await _carRepository.Update(car);
    }

    public async Task<bool> Delete(int id)
    {
        var car = await _carRepository.GetById(id);
        if (car == null) return false;
        
        return await _carRepository.Delete(id);
    }
}