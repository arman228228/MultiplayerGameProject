namespace Application.DTOs;

public class UpdateAccountDTO
{
    public required string Mail { get; set; }
    public int HoursPlayed { get; set; }
    public bool AdminStatus { get; set; }
}