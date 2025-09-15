using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Create(CreateAccountDTO dto)
    {
        var account = await _accountService.CreateAccount(dto);
        return Ok(account);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var account = await _accountService.GetAccountById(id);

        if (account == null)
            return NotFound($"Account with ID: {id} not found");
        
        return Ok(account);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var account = await _accountService.GetAll();

        if (account == null)
            return NotFound($"Accounts not found");
        
        return Ok(account);
    }
}