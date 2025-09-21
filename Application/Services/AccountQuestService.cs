using Application.DTOs.AccountQuests;
using Application.Interfaces.AccountQuests;
using Application.Interfaces.Accounts;
using Application.Interfaces.Quests;
using Domain.Entities.AccountQuests;

namespace Application.Services;

public class AccountQuestService : IAccountQuestService
{
    private readonly IAccountQuestRepository _accountQuestRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly IQuestRepository _questRepository;
    
    public AccountQuestService(IAccountQuestRepository accountQuestRepository, IAccountRepository accountRepository, IQuestRepository questRepository)
    {
        _accountQuestRepository = accountQuestRepository;
        _accountRepository = accountRepository;
        _questRepository = questRepository;
    }
    
    public async Task<AccountQuest?> Create(CreateAccountQuestDto request)
    {
        var account = await _accountRepository.GetById(request.AccountId);
        if (account == null) return null;

        var quest = await _questRepository.GetById(request.QuestId);
        if (quest == null) return null;

        var checkExist = await _accountQuestRepository.GetByAccountAndQuest(request.AccountId, request.QuestId);
        if (checkExist != null) return null;

        var accountQuest = new AccountQuest(request.AccountId, request.QuestId);

        return await _accountQuestRepository.Create(accountQuest);
    }

    public async Task<AccountQuest?> GetById(int id)
    {
        return await _accountQuestRepository.GetById(id);
    }

    public async Task<List<AccountQuest>> GetAll()
    {
        return await _accountQuestRepository.GetAll();
    }

    public async Task<bool> Update(int id, UpdateAccountQuestDto request)
    {
        var accountQuest = await _accountQuestRepository.GetById(id);
        if (accountQuest == null) return false;

        accountQuest.UpdateCompleteStatus(request.IsCompleted);

        return await _accountQuestRepository.Update(accountQuest);
    }

    public async Task<bool> Delete(int id)
    {
        return await _accountQuestRepository.Delete(id);
    }
}