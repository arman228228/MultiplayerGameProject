using Domain.Entities.AccountQuests;
using Domain.Entities.Cars;
using Domain.Entities.Quests;

namespace Domain.Entities.Accounts;

// Business logic
public class Account
{
    public int Id { get; private set; }
    public string Nickname { get; private set; }
    public string Mail { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public int HoursPlayed { get; private set; }
    public bool AdminStatus { get; private set; }
    public ICollection<Quest> Quests { get; private set; } = new List<Quest>();
    public ICollection<AccountQuest> AccountQuests { get; private set; } = new List<AccountQuest>();
    public Car Car { get; set; }

    private const int MinNicknameLength = 3;
    private const int MaxNicknameLength = 32;
    
    private const int MinMailLength = 6;
    private const int MaxMailLength = 64;
    
    private const int MinPasswordLength = 6;
    private const int MaxPasswordLength = 32;
    
    private const int MinHoursPlayed = 0;
    private const int MaxHoursPlayed = int.MaxValue;
    
    private Account() {}

    public Account(string nickname, string mail, string password)
    {
        if (string.IsNullOrWhiteSpace(nickname) || nickname.Length < MinNicknameLength || nickname.Length > MaxNicknameLength)
        {
            throw new ArgumentException($"Nickname length is invalid. Correct lengths: from {MinNicknameLength} to {MaxNicknameLength}", nameof(nickname));
        }
        if (string.IsNullOrWhiteSpace(mail) || mail.Length < MinMailLength || mail.Length > MaxMailLength)
        {
            throw new ArgumentException($"Mail length is invalid. Correct lengths: from {MinMailLength} to {MaxMailLength}", nameof(mail));
        }
        if (string.IsNullOrWhiteSpace(password) || password.Length < MinPasswordLength || password.Length > MaxPasswordLength)
        {
            throw new ArgumentException($"Password length is invalid. Correct lengths: from {MinPasswordLength} to {MaxPasswordLength}", nameof(password));
        }

        Nickname = nickname;
        Mail = mail;
        Password = password;
        CreatedAt = DateTime.UtcNow;
    }
    
    // Mapper
    public void Update(string mail, int hoursPlayed, bool adminStatus)
    {
        if (string.IsNullOrWhiteSpace(mail) || mail.Length < MinMailLength || mail.Length > MaxMailLength)
        {
            throw new ArgumentException($"Mail length is invalid. Correct lengths: from {MinMailLength} to {MaxMailLength}", nameof(mail));
        }
        if (hoursPlayed < MinHoursPlayed || hoursPlayed > MaxHoursPlayed)
        {
            throw new ArgumentException($"HoursPlayed value is invalid. Correct lengths: from {MinHoursPlayed} to {MaxHoursPlayed}", nameof(hoursPlayed));
        }
        
        Mail = mail;
        HoursPlayed = hoursPlayed;
        AdminStatus = adminStatus;
    }
}