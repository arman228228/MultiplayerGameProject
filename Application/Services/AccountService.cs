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
    
    public Task<Account?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public async Task<Account?> Create(CreateAccountDTO request)
    {
        var results = await Task.WhenAll(
            _repository.GetByNickname(request.Nickname),
            _repository.GetByMail(request.Mail)
        );
        
        if (results[0] != null || results[1] != null)
            return null;
        
        var account = new Account
        {
            Nickname = request.Nickname,
            Mail = request.Mail,
            Password = request.Password
        };
        
        return await _repository.Create(account);
    }

    public async Task<bool> Update(int accountId, UpdateAccountDTO request)
    {
        var account = await _repository.GetById(accountId);

        if (account == null)
            return false;
        
        account.Mail = request.Mail;
        account.HoursPlayed = request.HoursPlayed;
        account.AdminStatus = request.AdminStatus;

        return await _repository.Update(account);
    }

    public async Task<bool> Delete(int accountId)
    {
        return await _repository.Delete(accountId);
    }
}