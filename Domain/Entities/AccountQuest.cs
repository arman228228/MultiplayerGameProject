using System.ComponentModel.DataAnnotations;
using Domain.Entities.Accounts;
using Domain.Entities.Quests;

namespace Domain.Entities.AccountQuests;

public class AccountQuest
{
    public int Id { get; set; }
    
    [Required]
    public int AccountId { get; set; }
    [Required]
    public Account Account { get; set; }
    
    [Required]
    public int QuestId { get; set; }
    [Required]
    public Quest Quest { get; set; }
    
    public bool IsCompleted { get; set; }
    
    private AccountQuest() { }

    public AccountQuest(int accountId, int questId)
    {
        AccountId = accountId;
        QuestId = questId;
        IsCompleted = false;
    }
}