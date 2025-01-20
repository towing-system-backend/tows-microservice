namespace Tow.Application
{
    public record CreateTowCommand(
        string Brand, 
        string Model, 
        string Color, 
        string LicensePlate, 
        string Location,
        int Year,
        string SizeType, 
        string Status
    );
}
