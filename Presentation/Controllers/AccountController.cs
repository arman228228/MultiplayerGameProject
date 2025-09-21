using Application.DTOs.Accounts;
using Application.Interfaces.Accounts;
using Application.Mappers.Accounts;
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
    public async Task<IActionResult> Create(CreateAccountRequestDto requestDto)
    {
        var account = await _accountService.Create(requestDto);
        if (account == null) return Conflict("Error key with nickname or email");

        var response = account.ToResponseDto();
        
        return CreatedAtAction(nameof(GetById), new {id = account.Id}, response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await _accountService.GetById(id);
        if (account == null) return NotFound($"Account with ID: {id} not found");
        
        var response = account.ToResponseDto();
        
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accounts = await _accountService.GetAll();
        if (!accounts.Any()) return NotFound($"Accounts not found");

        var responses = accounts.Select(a => a.ToResponseDto()).ToList();
        
        return Ok(responses);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAccountDto request)
    {
        bool updatingResult = await _accountService.Update(id, request);
        if (!updatingResult) return NotFound($"Account not found");
        
        return Ok(updatingResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletionResult = await _accountService.Delete(id);
        if (!deletionResult) return NotFound($"Account not found");
        
        return Ok(deletionResult);
    }
}