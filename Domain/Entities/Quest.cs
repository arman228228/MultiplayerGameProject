using Domain.Entities.AccountQuests;
using Domain.Entities.Accounts;

namespace Domain.Entities.Quests;

public class Quest
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsCompleted { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; private set; }
    public ICollection<AccountQuest> AccountQuests { get; private set; } = new List<AccountQuest>();

    public Quest(string name, int accountId)
    {
        Name = name;
        AccountId = accountId;
        IsCompleted = false;
    }
    
    // Mapper
    public void UpdateCompleteStatus(bool status) => IsCompleted = status;
}