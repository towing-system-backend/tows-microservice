using Application.Core;

namespace Tow.Domain
{
    public class TowBrandUpdatedEvent(string publisherId, string type, TowBrandUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowBrandUpdated(string brand)
    {
        public readonly string Brand = brand;

        public static TowBrandUpdatedEvent CreateEvent(TowId publisherId, TowBrand brand)
        {
            return new TowBrandUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowBrandUpdated).Name,
                new TowBrandUpdated(
                    brand.GetValue()
                )
            );

        }
    }
}
