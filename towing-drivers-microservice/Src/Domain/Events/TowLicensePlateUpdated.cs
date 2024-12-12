using Application.Core;

namespace Tow.Domain
{
    public class TowLicensePlateUpdatedEvent(string publisherId, string type, TowLicensePlateUpdated context) : DomainEvent(publisherId, type, context) { }
    public class TowLicensePlateUpdated(string licensePlate)
    {
        public readonly string LicensePlate = licensePlate;

        public static TowLicensePlateUpdatedEvent CreateEvent(TowId publisherId, TowLicensePlate licensePlate)
        {
            return new TowLicensePlateUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowLicensePlateUpdated).Name,
                new TowLicensePlateUpdated(
                    licensePlate.GetValue()
                )
            );

        }
    }
}
