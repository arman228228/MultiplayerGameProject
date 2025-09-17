using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class AccountRepository : IAccountRepository
{
    private static AppDbContext _context;

    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public Task<Account?> GetById(int id)
    {
        return _context.Accounts.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<List<Account>> GetAll()
    {
        return _context.Accounts.ToListAsync();
    }

    public async Task<Account> Create(Account account)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
        
        return account;
    }

    public void Update(Account account)
    {
        var currentAccount = _context.Accounts.FirstOrDefaultAsync(p => p.Id == account.Id);

        if (currentAccount == null)
            return;
        
        _context.Remove(currentAccount);
        _context.Add(account);
    }
}