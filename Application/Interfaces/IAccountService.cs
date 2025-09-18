using Application.DTOs;
using Domain.Entities;

// Business logic

namespace Application.Interfaces;

public interface IAccountService
{
    Task<Account?> Create(CreateAccountDTO request);
    Task<List<Account>> GetAll();
    Task<Account?> GetById(int id);
    Task<bool> Update(int accountId, UpdateAccountDTO request);
    Task<bool> Delete(int accountId);
}