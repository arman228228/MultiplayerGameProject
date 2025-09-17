using Domain.Entities;

namespace Application.Interfaces;

// Data access

public interface IAccountRepository
{
    Task<Account?> GetById(int id);
    Task<List<Account>> GetAll();
    Task<Account> Create(Account account);
    void Update(Account account);
}