using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountDto dto)
    {
        var account = await _accountService.Create(dto);

        if (account == null)
            return Conflict("Duplicate key nickname or email");
        
        return Created($"/api/account/{account.Id}", account);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await _accountService.GetById(id);

        if (account == null)
            return NotFound($"Account with ID: {id} not found");
        
        return Ok(account);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountService.GetAll();

        if (!accounts.Any())
            return NotFound($"Accounts not found");
        
        return Ok(accounts);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAccountDto request)
    {
        bool updatingResult = await _accountService.Update(id, request);

        if (!updatingResult)
            return NotFound($"Account not found");
        
        return Ok(updatingResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletionResult = await _accountService.Delete(id);

        if (!deletionResult)
            return NotFound($"Account not found");
        
        return Ok(deletionResult);
    }
}