using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Accounts;

public record CreateAccountDto
{
    [Required]
    public string Nickname { get; set; } = string.Empty;
    
    [Required]
    public string Mail { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
}