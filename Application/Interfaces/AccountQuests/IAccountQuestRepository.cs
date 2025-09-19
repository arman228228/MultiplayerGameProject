using Domain.Entities.AccountQuests;

namespace Application.Interfaces.AccountQuests;

public interface IAccountQuestRepository
{
    Task<AccountQuest?> Create(AccountQuest accountQuest);
    Task<AccountQuest?> GetById(int id);
    Task<AccountQuest?> GetByAccountAndQuest(int accountId, int questId);

    Task<List<AccountQuest>> GetAll();
    Task<bool> Update(AccountQuest accountQuest);
    Task<bool> Delete(int id);
}