using Application.DTOs.AccountQuests;
using Application.Interfaces.AccountQuests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountQuestController : ControllerBase
{
    private readonly IAccountQuestService _accountQuestService;

    public AccountQuestController(IAccountQuestService accountQuestService)
    {
        _accountQuestService = accountQuestService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountQuestDto dto)
    {
        var accountQuest = await _accountQuestService.Create(dto);
        if (accountQuest == null) return Conflict("Error key");
        
        return Created($"/api/accountQuest/{accountQuest.Id}", accountQuest);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var accountQuest = await _accountQuestService.GetById(id);
        if (accountQuest == null) return NotFound($"AccountQuest with ID: {id} not found");
        
        return Ok(accountQuest);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var accountQuests = await _accountQuestService.GetAll();
        if (!accountQuests.Any()) return NotFound($"AccountsQuests not found");
        
        return Ok(accountQuests);
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAccountQuestDto request)
    {
        bool updatingResult = await _accountQuestService.Update(id, request);
        if (!updatingResult) return NotFound($"AccountQuest not found");
        
        return Ok(updatingResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletionResult = await _accountQuestService.Delete(id);
        if (!deletionResult) return NotFound($"AccountQuest not found");
        
        return Ok(deletionResult);
    }
}