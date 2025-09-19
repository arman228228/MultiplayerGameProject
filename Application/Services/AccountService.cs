using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Mappers.Accounts;
using Domain.Entities.Accounts;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;

    public AccountService(IAccountRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Account?> Create(CreateAccountDto request)
    {
        var results = await Task.WhenAll(
            _repository.GetByNickname(request.Nickname),
            _repository.GetByMail(request.Mail)
        );
        
        if (results[0] != null || results[1] != null) return null;
        
        return await _repository.Create(request.ToEntity());
    }

    public Task<List<Account>> GetAll()
    {
        return _repository.GetAll();
    }
    
    public Task<Account?> GetById(int id)
    {
        return _repository.GetById(id);
    }

    public async Task<bool> Update(int accountId, UpdateAccountDto request)
    {
        var account = await _repository.GetById(accountId);
        if (account == null) return false;

        account.MapFromDto(request);

        return await _repository.Update(account);
    }

    public async Task<bool> Delete(int accountId)
    {
        return await _repository.Delete(accountId);
    }
}