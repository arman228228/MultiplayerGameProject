using System.ComponentModel.DataAnnotations;
using Domain.Entities.AccountQuests;
using Domain.Entities.Cars;
using Domain.Entities.Quests;

namespace Domain.Entities.Accounts;

// Business logic
public class Account
{
    public int Id { get; private set; }
    
    [Required]
    [StringLength(32, MinimumLength = 3)]
    public string Nickname { get; set; }
    
    [Required]
    [StringLength(64, MinimumLength = 5)]
    public string Mail { get; set; }
    
    [Required]
    [StringLength(32, MinimumLength = 6)]
    public string Password { get; set; }
    public DateTime CreatedAt { get; private set; }
    public int HoursPlayed { get; set; }
    public bool AdminStatus { get; set; }
    public ICollection<Quest> Quests { get; private set; } = new List<Quest>();
    public ICollection<AccountQuest> AccountQuests { get; private set; } = new List<AccountQuest>();
    public Car Car { get; set; }
    
    private Account() {}

    public Account(string nickname, string mail, string password)
    {
        Nickname = nickname;
        Mail = mail;
        Password = password;
        CreatedAt = DateTime.UtcNow;
    }
}