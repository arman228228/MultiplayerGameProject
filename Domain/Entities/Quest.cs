using System.ComponentModel.DataAnnotations;
using Domain.Entities.AccountQuests;
using Domain.Entities.Accounts;

namespace Domain.Entities.Quests;

public class Quest
{
    public int Id { get; }

    [Required]
    [StringLength(32, MinimumLength = 3)]
    public string Name { get; set; }

    public bool IsCompleted { get; set; }

    [Required] 
    public int AccountId { get; set; }
    [Required] 
    public Account Account { get; set; }
    
    public ICollection<AccountQuest> AccountQuests { get; private set; } = new List<AccountQuest>();

    public Quest(string name, int accountId)
    {
        Name = name;
        AccountId = accountId;
        IsCompleted = false;
    }
}