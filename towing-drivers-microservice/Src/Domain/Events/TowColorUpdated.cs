using Application.Core;

namespace Tow.Domain
{
    public class TowColorUpdatedEvent(string publisherId, string type, TowColorUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowColorUpdated(string color)
    {
        public readonly string Color = color;

        public static TowColorUpdatedEvent CreateEvent(TowId publisherId, TowColor color)
        {
            return new TowColorUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowColorUpdated).Name,
                new TowColorUpdated(
                    color.GetValue()
                )
            );
        }
    }
}
