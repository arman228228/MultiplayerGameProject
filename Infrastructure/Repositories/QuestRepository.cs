using Application.Interfaces.Quests;
using Application.Mappers.Quests;
using Domain.Entities.Quests;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class QuestRepository : IQuestRepository
{
    private AppDbContext _context;

    public QuestRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Quest?> Create(Quest quest)
    {
        _context.Add(quest);
        await _context.SaveChangesAsync();
        return quest;
    }

    public Task<List<Quest>> GetAll()
    {
        return _context.Quests.AsNoTracking().ToListAsync();
    }

    public Task<Quest?> GetById(int questId)
    {
        return _context.Quests.AsNoTracking().FirstOrDefaultAsync(q => q.Id == questId);
    }
    
    public Task<Quest?> GetByIdAndName(int accountId, string name)
    {
        return _context.Quests.AsNoTracking().FirstOrDefaultAsync(q => q.AccountId == accountId && q.Name == name);
    }

    public async Task<bool> Update(Quest quest)
    {
        var questFromDb = await _context.Quests.FirstOrDefaultAsync(q => q.Id == quest.Id);

        if (questFromDb == null)
            return false;

        questFromDb.Map(quest);

        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<bool> Delete(int questId, int accountId)
    {
        var questFromDb = await _context.Quests.FirstOrDefaultAsync(q => q.Id == questId && q.AccountId == accountId);

        if (questFromDb == null)
            return false;
        
        _context.Quests.Remove(questFromDb);
        return await _context.SaveChangesAsync() > 0;
    }
}