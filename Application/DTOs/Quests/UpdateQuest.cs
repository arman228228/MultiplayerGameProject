using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Quests;

public record UpdateQuestDto
{
    [Required]
    public bool IsCompleted { get; set; }
}