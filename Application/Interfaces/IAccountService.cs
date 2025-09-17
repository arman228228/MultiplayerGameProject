using Application.DTOs;
using Domain.Entities;

// Business logic

namespace Application.Interfaces;

public interface IAccountService
{
    Task<List<Account>> GetAll();
    Task<Account?> GetAccountById(int id);
    Task<Account> CreateAccount(CreateAccountDTO request);
    Task<Account> UpdateAccount(int accountId, UpdateAccountDTO request);
}