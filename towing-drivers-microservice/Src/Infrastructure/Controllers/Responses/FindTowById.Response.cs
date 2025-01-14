namespace Tow.Infrastructure
{
    public record FindTowByIdResponse(

        string towId,
        string towBrand,
        string towModel,
        string towColor,
        string towLicensePlate,
        string towLocation,
        int towYear,
        string towSizeType,
        string towStatus

    );
}
