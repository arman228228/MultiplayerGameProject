namespace Domain.Entities;

// Business logic
public class Account
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }

    //
    public int HoursPlayed { get; set; }
    public bool AdminStatus { get; set; }
}