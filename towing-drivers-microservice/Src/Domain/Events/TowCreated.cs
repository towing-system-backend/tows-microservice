using Application.Core;

namespace Tow.Domain
{
    public class TowCreatedEvent(string publisherId, string type, TowCreated context) : DomainEvent(publisherId, type, context) { }

    public class TowCreated(string id, string brand, string model, string color, string licensePlate, int year, string sizeType, string status)
    {
        public readonly string Id = id;
        public readonly string Brand = brand;
        public readonly string Model = model;
        public readonly string Color = color;
        public readonly string LicensePlate = licensePlate;
        public readonly int Year = year;
        public readonly string SizeType = sizeType;
        public readonly string Status = status;

        static public TowCreatedEvent CreateEvent(
            TowId publisherId, 
            TowBrand brand, 
            TowModel model, 
            TowColor color,
            TowLicensePlate licensePlate,
            TowYear year,
            TowSizeType sizeType,
            TowStatus status)
        {
            return new TowCreatedEvent(
                publisherId.GetValue(),
                typeof(TowCreated).Name,
                new TowCreated(
                    publisherId.GetValue(),
                    brand.GetValue(),
                    model.GetValue(),
                    color.GetValue(),
                    licensePlate.GetValue(),
                    year.GetValue(),
                    sizeType.GetValue(),
                    status.GetValue()
                )

            );
        }
    }
}
