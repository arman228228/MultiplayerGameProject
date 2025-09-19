using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Cars;

public record UpdateCarDto
{
    [Required]
    public required string Model { get; set; }
}