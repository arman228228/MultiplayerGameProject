using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Cars;

public record CreateCarDto
{
    [Required]
    public string Model { get; set; } = string.Empty;
    [Required]
    public int AccountId { get; set; }
}