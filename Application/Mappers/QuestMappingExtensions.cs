using Application.DTOs.Quests;
using Domain.Entities.Quests;

namespace Application.Mappers.Quests;

public static class QuestMappingExtensions
{
    public static void Map(this Quest quest, Quest secondQuest)
    {
        quest.UpdateCompleteStatus(secondQuest.IsCompleted);
    }
    
    public static void MapFromDto(this Quest quest, UpdateQuestDto dto)
    {
        quest.UpdateCompleteStatus(dto.IsCompleted);
    }
    
    public static Quest ToEntity(this CreateQuestDto dto)
    {
        return new Quest(dto.Name, dto.AccountId);
    }
}