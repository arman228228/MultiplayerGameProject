using Application.DTOs.Accounts;
using Domain.Entities.Accounts;

// Business logic

namespace Application.Interfaces.Accounts;

public interface IAccountService
{
    Task<Account?> Create(CreateAccountDto request);
    Task<List<Account>> GetAll();
    Task<Account?> GetById(int id);
    Task<bool> Update(int accountId, UpdateAccountDto request);
    Task<bool> Delete(int accountId);
}