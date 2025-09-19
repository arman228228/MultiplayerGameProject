using Application.DTOs.Quests;
using Application.Interfaces.Quests;
using Application.Mappers.Quests;
using Domain.Entities.Quests;

namespace Application.Services;

public class QuestService : IQuestService
{
    private readonly IQuestRepository _repository;

    public QuestService(IQuestRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Quest>> GetAll()
    {
        return _repository.GetAll();
    }
    
    public Task<Quest?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public async Task<Quest?> Create(CreateQuestDto request)
    {
        var result = await _repository.GetByIdAndName(request.AccountId, request.Name);

        if (result != null)
            return null;

        return await _repository.Create(request.ToEntity());
    }

    public async Task<bool> Update(int questId, UpdateQuestDto request)
    {
        var quest = await _repository.GetById(questId);

        if (quest == null)
            return false;

        quest.MapFromDto(request);

        return await _repository.Update(quest);
    }

    public async Task<bool> Delete(int questId)
    {
        var quest = await _repository.GetById(questId);

        if (quest == null)
            return false;
        
        return await _repository.Delete(questId, quest.AccountId);
    }
}