using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.AccountQuests;

public class UpdateAccountQuestDto
{
    [Required]
    public bool IsCompleted { get; set; }
}