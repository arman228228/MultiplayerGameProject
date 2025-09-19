using Application.DTOs.Cars;
using Application.Interfaces.Cars;
using Application.Mappers;
using Domain.Entities.Cars;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CarRepository : ICarRepository
{
    private AppDbContext _context;

    public CarRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Car?> Create(Car quest)
    {
        _context.Add(quest);
        await _context.SaveChangesAsync();
        return quest;
    }

    public Task<List<Car>> GetAll()
    {
        return _context.Cars.AsNoTracking().ToListAsync();
    }

    public Task<Car?> GetById(int questId)
    {
        return _context.Cars.AsNoTracking().FirstOrDefaultAsync(q => q.Id == questId);
    }

    public Task<Car?> GetByAccountAndModel(int accountId, string model)
    {
        return _context.Cars.AsNoTracking().FirstOrDefaultAsync(c => c.AccountId == accountId && c.Model == model);
    }

    public async Task<bool> Update(Car car)
    {
        var carFromDb = await _context.Cars.FirstOrDefaultAsync(c => c.Id == car.Id && c.AccountId == car.AccountId);
        if (carFromDb == null) return false;

        carFromDb.Map(car);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var carFromDb = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        if (carFromDb == null) return false;

        _context.Cars.Remove(carFromDb);
        return await _context.SaveChangesAsync() > 0;
    }
}