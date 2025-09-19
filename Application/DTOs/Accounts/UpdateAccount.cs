using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Accounts;

public record UpdateAccountDto
{
    [Required]
    public required string Mail { get; set; }
    
    [Required]
    public int HoursPlayed { get; set; }
    
    [Required]
    public bool AdminStatus { get; set; }
}