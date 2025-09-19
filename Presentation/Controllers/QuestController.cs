using Application.DTOs.Quests;
using Application.Interfaces.Quests;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class QuestController : ControllerBase
{
    private readonly IQuestService _questService;

    public QuestController(IQuestService questService)
    {
        _questService = questService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateQuestDto dto)
    {
        var quest = await _questService.Create(dto);

        if (quest == null)
            return Conflict("Duplicate key");
        
        return Created($"/api/quest/{quest.Id}", quest);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var quest = await _questService.GetById(id);

        if (quest == null)
            return NotFound($"Quest with ID: {id} not found");
        
        return Ok(quest);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var quests = await _questService.GetAll();

        if (!quests.Any())
            return NotFound($"Quests not found");
        
        return Ok(quests);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateQuestDto request)
    {
        bool updatingResult = await _questService.Update(id, request);

        if (!updatingResult)
            return NotFound($"Quest not found");
        
        return Ok(updatingResult);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deletionResult = await _questService.Delete(id);

        if (!deletionResult)
            return NotFound($"Quest not found");
        
        return Ok(deletionResult);
    }
}