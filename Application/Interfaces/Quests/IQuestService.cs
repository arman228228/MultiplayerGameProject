using Application.DTOs.Quests;
using Domain.Entities.Quests;

namespace Application.Interfaces.Quests;

public interface IQuestService
{
    Task<Quest?> Create(CreateQuestDto request);
    Task<List<Quest>> GetAll();
    Task<Quest?> GetById(int id);
    Task<bool> Update(int questId, UpdateQuestDto request);
    Task<bool> Delete(int questId);
}