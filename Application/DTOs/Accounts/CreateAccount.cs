using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Accounts;

public record CreateAccountRequestDto
{
    [Required]
    [StringLength(32, MinimumLength = 3, ErrorMessage = "Nickname valid length is from 3 to 32")]
    public string Nickname { get; set; } = string.Empty;
    
    [Required]
    [StringLength(64, MinimumLength = 6, ErrorMessage = "Mail valid length is from 6 to 64"), EmailAddress]
    public string Mail { get; set; } = string.Empty;
    
    [Required]
    [Range(6, 32, ErrorMessage = "Password valid length is from 6 to 32")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}

public record CreateAccountResponseDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string Nickname { get; set; } = string.Empty;
    
    [Required]
    public string Mail { get; set; } = string.Empty;
}