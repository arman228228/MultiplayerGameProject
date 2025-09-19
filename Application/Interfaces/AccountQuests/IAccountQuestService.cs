using Application.DTOs.AccountQuests;
using Domain.Entities.AccountQuests;

namespace Application.Interfaces.AccountQuests;

public interface IAccountQuestService
{
    Task<AccountQuest?> Create(CreateAccountQuestDto request);
    Task<AccountQuest?> GetById(int id);
    Task<List<AccountQuest>> GetAll();
    Task<bool> Update(int id, UpdateAccountQuestDto request);
    Task<bool> Delete(int id);
}