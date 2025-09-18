using Domain.Entities;

namespace Application.Interfaces;

// Data access

public interface IAccountRepository
{
    Task<Account> Create(Account account);
    Task<Account?> GetById(int id);
    Task<Account?> GetByNickname(string nickname);
    Task<Account?> GetByMail(string mail);
    Task<List<Account>> GetAll();
    Task<bool> Update(Account account);
    Task<bool> Delete(int id);
}