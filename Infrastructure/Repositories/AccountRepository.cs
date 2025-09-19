using Application.Interfaces.Accounts;
using Application.Mappers.Accounts;
using Domain.Entities.Accounts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Account> Create(Account account)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }
    
    public Task<Account?> GetById(int id)
    {
        return _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }

    public Task<Account?> GetByNickname(string nickname)
    {
        return _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Nickname == nickname);
    }
    
    public Task<Account?> GetByMail(string mail)
    {
        return _context.Accounts.AsNoTracking().FirstOrDefaultAsync(a => a.Mail == mail);
    }

    public Task<List<Account>> GetAll()
    {
        return _context.Accounts.AsNoTracking().ToListAsync();
    }

    public async Task<bool> Update(Account account)
    {
        var currentAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == account.Id);
        if (currentAccount == null) return false;

        currentAccount.Map(account);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        if (account == null) return false;
        
        _context.Accounts.Remove(account);
        return await _context.SaveChangesAsync() > 0;
    }
}