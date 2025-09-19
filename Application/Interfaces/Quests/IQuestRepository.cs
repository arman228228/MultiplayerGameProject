using Application.DTOs.Quests;
using Domain.Entities.Quests;

namespace Application.Interfaces.Quests;

public interface IQuestRepository
{
    public Task<Quest?> Create(Quest quest);
    public Task<List<Quest>> GetAll();
    public Task<Quest?> GetById(int questId);
    public Task<Quest?> GetByIdAndName(int accountId, string name);
    public Task<bool> Update(Quest quest);
    public Task<bool> Delete(int questId, int accountId);
}