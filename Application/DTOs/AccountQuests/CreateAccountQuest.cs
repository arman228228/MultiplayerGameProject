using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.AccountQuests;

public class CreateAccountQuestDto
{
    [Required]
    public int AccountId { get; set; }
    
    [Required]
    public int QuestId { get; set; }
}