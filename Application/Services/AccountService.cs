using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services;

// Business logic

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Account>> GetAll()
    {
        return _repository.GetAll();
    }
    
    public Task<Account?> GetAccountById(int id)
    {
        return _repository.GetById(id);
    }

    public Task<Account> CreateAccount(CreateAccountDTO request)
    {
        var account = new Account
        {
            Name = request.Name,
            Mail = request.Mail,
            Password = request.Password
        };
        
        return _repository.Create(account);
    }

    public async Task<Account> UpdateAccount(int accountId, UpdateAccountDTO request)
    {
        var currentAccount = await _repository.GetById(accountId);

        if (currentAccount == null)
            return null;
        
        currentAccount.Mail = request.Mail;
        currentAccount.HoursPlayed = request.HoursPlayed;
        currentAccount.AdminStatus = request.AdminStatus;

        _repository.Update(currentAccount);

        return currentAccount;
    }
}