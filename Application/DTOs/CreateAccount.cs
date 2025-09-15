namespace Application.DTOs;

public class CreateAccountDTO
{
    public string Name { get; set; } = string.Empty;
    public string Mail { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}