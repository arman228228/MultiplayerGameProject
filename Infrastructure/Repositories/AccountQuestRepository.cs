using Application.Interfaces.AccountQuests;
using Domain.Entities.AccountQuests;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountQuestRepository : IAccountQuestRepository
{
    private readonly AppDbContext _context;

    public AccountQuestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<AccountQuest?> Create(AccountQuest accountQuest)
    {
        _context.AccountQuests.Add(accountQuest);
        await _context.SaveChangesAsync();
        return accountQuest;
    }

    public async Task<AccountQuest?> GetById(int id)
    {
        var accountQuest = await _context.AccountQuests
            .Include(aq => aq.Account)
            .Include(aq => aq.Quest)
            .FirstOrDefaultAsync(aq => aq.Id == id);
        
        if (accountQuest == null) return null;
        
        return accountQuest;
    }

    public async Task<AccountQuest?> GetByAccountAndQuest(int accountId, int questId)
    {
        var accountQuest = await _context.AccountQuests
            .Include(aq => aq.Account)
            .Include(aq => aq.Quest)
            .FirstOrDefaultAsync(aq => aq.AccountId == accountId && aq.QuestId == questId);
        
        if (accountQuest == null) return null;
        
        return accountQuest;
    }

    public async Task<List<AccountQuest>> GetAll()
    {
        return await _context.AccountQuests
            .Include(aq => aq.Account)
            .Include(aq => aq.Quest)
            .ToListAsync();
    }
    
    public async Task<bool> Update(AccountQuest accountQuest)
    {
        _context.AccountQuests.Update(accountQuest);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var accountQuest = _context.AccountQuests.FirstOrDefault(aq => aq.Id == id);
        if (accountQuest == null) return false;

        _context.AccountQuests.Remove(accountQuest);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}