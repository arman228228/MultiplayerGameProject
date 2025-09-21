using Application.DTOs.Accounts;
using Domain.Entities.Accounts;

namespace Application.Mappers.Accounts;

public static class AccountMappingExtensions
{
    public static void Map(this Account account, Account secondAccount)
    {
        account.Update(secondAccount.Mail, secondAccount.HoursPlayed, secondAccount.AdminStatus);
    }
    
    public static void MapFromDto(this Account account, UpdateAccountDto dto)
    {
        account.Update(dto.Mail, dto.HoursPlayed, dto.AdminStatus);
    }
    
    public static Account ToEntity(this CreateAccountRequestDto requestDto)
    {
        return new Account(requestDto.Nickname, requestDto.Mail, requestDto.Password);
    }

    public static CreateAccountResponseDto ToResponseDto(this Account account)
    { 
        return new CreateAccountResponseDto { Id = account.Id, Nickname = account.Nickname, Mail = account.Mail };
    }
}