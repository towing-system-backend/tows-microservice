namespace Tow.Application
{
    public record CreateTowCommand(string Brand, string Model, string Color, string LicensePlate, int Year, string SizeType, string Status);
}
