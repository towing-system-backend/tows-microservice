namespace Tow.Application
{
    public record UpdateTowCommand(
        string Id, 
        string? Brand, 
        string? Model, 
        string? Color, 
        string? LicensePlate, 
        string? Location,
        int? Year, 
        string? SizeType, 
        string? Status
    );
}
