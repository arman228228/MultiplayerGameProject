using Application.DTOs.Accounts;
using Domain.Entities.Accounts;

namespace Application.Mappers.Accounts;

public static class AccountMappingExtensions
{
    public static void Map(this Account account, Account secondAccount)
    {
        account.Mail = secondAccount.Mail;
        account.HoursPlayed = secondAccount.HoursPlayed;
        account.AdminStatus = secondAccount.AdminStatus;
    }
    
    public static void MapFromDto(this Account account, UpdateAccountDto dto)
    {
        account.Mail = dto.Mail;
        account.HoursPlayed = dto.HoursPlayed;
        account.AdminStatus = dto.AdminStatus;
    }
    
    public static Account ToEntity(this CreateAccountDto dto)
    {
        return new Account(dto.Nickname, dto.Mail, dto.Password);
    }
}