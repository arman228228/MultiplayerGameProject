using Application.Interfaces;
using Domain.Entities;
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
    
    public Task<Account?> GetById(int id)
    {
        return _context.Accounts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<Account?> GetByNickname(string nickname)
    {
        return _context.Accounts.AsNoTracking().FirstOrDefaultAsync(p => p.Nickname == nickname);
    }
    
    public Task<Account?> GetByMail(string mail)
    {
        return _context.Accounts.AsNoTracking().FirstOrDefaultAsync(p => p.Mail == mail);
    }

    public Task<List<Account>> GetAll()
    {
        return _context.Accounts.AsNoTracking().ToListAsync();
    }

    public async Task<Account> Create(Account account)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<bool> Update(Account account)
    {
        var currentAccount = await _context.Accounts.FirstOrDefaultAsync(p => p.Id == account.Id);

        if (currentAccount == null)
            return false;

        currentAccount.Mail = account.Mail;
        currentAccount.HoursPlayed = account.HoursPlayed;
        currentAccount.AdminStatus = account.AdminStatus;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var account = await _context.Accounts.FirstOrDefaultAsync(p => p.Id == id);

        if (account == null)
            return false;
        
        _context.Accounts.Remove(account);
        return await _context.SaveChangesAsync() > 0;
    }
}