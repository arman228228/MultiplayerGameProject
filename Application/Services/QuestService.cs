using Application.DTOs.Quests;
using Application.Interfaces.Accounts;
using Application.Interfaces.Quests;
using Application.Mappers.Quests;
using Domain.Entities.Quests;

namespace Application.Services;

public class QuestService : IQuestService
{
    private readonly IQuestRepository _questRepository;
    private readonly IAccountRepository _accountRepository;

    public QuestService(IQuestRepository repository, IAccountRepository accountRepository)
    {
        _questRepository = repository;
        _accountRepository = accountRepository;
    }

    public Task<List<Quest>> GetAll()
    {
        return _questRepository.GetAll();
    }
    
    public Task<Quest?> GetById(int id)
    {
        return _questRepository.GetById(id);
    }

    public async Task<Quest?> Create(CreateQuestDto request)
    {
        var account = await _accountRepository.GetById(request.AccountId);
        if (account == null) return null;
        
        var result = await _questRepository.GetByIdAndName(request.AccountId, request.Name);
        if (result != null) return null;

        return await _questRepository.Create(request.ToEntity());
    }

    public async Task<bool> Update(int questId, UpdateQuestDto request)
    {
        var quest = await _questRepository.GetById(questId);
        if (quest == null) return false;

        quest.MapFromDto(request);

        return await _questRepository.Update(quest);
    }

    public async Task<bool> Delete(int questId)
    {
        var quest = await _questRepository.GetById(questId);
        if (quest == null) return false;
        
        return await _questRepository.Delete(questId, quest.AccountId);
    }
}