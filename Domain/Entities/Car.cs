using Domain.Entities.Accounts;

namespace Domain.Entities.Cars;

// Business logic
public class Car
{
    public int Id { get; private set; }
    public string Model { get; private set; }
    public int AccountId { get; private set; }
    public Account Account { get; private set; }
    
    private const int MinModelLength = 3;
    private const int MaxModelLength = 64;
    
    private Car() {}

    public Car(string model, int accountId)
    {
        Model = model;
        AccountId = accountId;
    }

    // Mapper
    public void UpdateModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model) || model.Length < MinModelLength || model.Length > MaxModelLength)
        {
            throw new ArgumentException($"Model length is invalid. Correct lengths: from {MinModelLength} to {MaxModelLength}", nameof(model));
        }
        
        Model = model;
    }
}