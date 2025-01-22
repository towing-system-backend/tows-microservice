namespace Tow.Infrastructure;

public record FindActiveTowsResponse
(
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
