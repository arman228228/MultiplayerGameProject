using Application.Interfaces;
using Domain.Entities;

public class AccountRepository : IAccountRepository
{
    private static readonly List<Account> _accounts = new();
    private static int _nextId = 1; // AUTO INCREMENT
    
    public Task<Account?> GetById(int id)
    {
        return Task.FromResult(_accounts.FirstOrDefault(p => p.Id == id));
    }

    public Task<List<Account>> GetAll()
    {
        return Task.FromResult(_accounts);
    }

    public Task<Account> Create(Account account)
    {
        account.Id = _nextId;
        _accounts.Add(account);

        _nextId++;
        
        return Task.FromResult(account);
    }
}