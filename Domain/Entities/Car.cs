using System.ComponentModel.DataAnnotations;
using Domain.Entities.Accounts;

namespace Domain.Entities.Cars;

// Business logic
public class Car
{
    public int Id { get; private set; }
    
    [Required]
    [StringLength(64, MinimumLength = 3)]
    public string Model { get; set; }

    [Required]
    public int AccountId { get; set; }
    public Account Account { get; set; }
    
    private Car() {}

    public Car(string model, int accountId)
    {
        Model = model;
        AccountId = accountId;
    }
}