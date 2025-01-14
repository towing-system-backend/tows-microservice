using Application.Core;

namespace Tow.Domain
{
    public class TowSizeTypeUpdateEvent(string publisherId, string type, TowSizeTypeUpdate context) : DomainEvent(publisherId, type, context) { }

    public class TowSizeTypeUpdate(string sizeType)
    {
        public readonly string SizeType = sizeType;

        public static TowSizeTypeUpdateEvent CreateEvent(TowId publisherId, TowSizeType sizeType)
        {
            return new TowSizeTypeUpdateEvent(
                publisherId.GetValue(),
                typeof(TowSizeTypeUpdate).Name,
                new TowSizeTypeUpdate(
                    sizeType.GetValue()
                )
            );
        }
    }
}
