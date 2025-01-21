using Application.Core;

namespace Tow.Domain
{
    public class TowSizeTypeUpdatedEvent(string publisherId, string type, TowSizeTypeUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowSizeTypeUpdated(string sizeType)
    {
        public readonly string SizeType = sizeType;

        public static TowSizeTypeUpdatedEvent CreateEvent(TowId publisherId, TowSizeType sizeType)
        {
            return new TowSizeTypeUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowSizeTypeUpdated).Name,
                new TowSizeTypeUpdated(
                    sizeType.GetValue()
                )
            );
        }
    }
}
