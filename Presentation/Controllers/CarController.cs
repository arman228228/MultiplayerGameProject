using Application.DTOs.Cars;
using Application.Interfaces.Cars;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService accountService)
    {
        _carService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCarDto dto)
    {
        var car = await _carService.Create(dto);
        if (car == null) return Conflict("Error key");
        
        return Created($"/api/car/{car.Id}", car);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var car = await _carService.GetById(id);
        if (car == null) return NotFound($"Car with ID: {id} not found");
        
        return Ok(car);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = await _carService.GetAll();
        if (!cars.Any()) return NotFound($"Cars not found");
        
        return Ok(cars);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCarDto request)
    {
        bool updatingResult = await _carService.Update(id, request);
        if (!updatingResult) return NotFound($"Car not found");
        
        return Ok(updatingResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletionResult = await _carService.Delete(id);
        if (!deletionResult) return NotFound($"Car not found");
        
        return Ok(deletionResult);
    }
}