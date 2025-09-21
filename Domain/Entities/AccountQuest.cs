using Domain.Entities.Accounts;
using Domain.Entities.Quests;

namespace Domain.Entities.AccountQuests;

public class AccountQuest
{
    public int Id { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; private set; }
    public int QuestId { get; private set; }
    public Quest Quest { get; private set; }
    public bool IsCompleted { get; private set; }
    
    private AccountQuest() { }

    public AccountQuest(int accountId, int questId)
    {
        AccountId = accountId;
        QuestId = questId;
        IsCompleted = false;
    }

    // Mapper
    public void UpdateCompleteStatus(bool status) => IsCompleted = status;
}