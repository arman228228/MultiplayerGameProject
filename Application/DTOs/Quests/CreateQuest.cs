using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Quests;

public record CreateQuestDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int AccountId { get; set; }
}