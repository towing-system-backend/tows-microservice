using Application.Core;

namespace Tow.Domain
{
    public class TowStatusUpdatedEvent(string publisherId, string type, TowStatusUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowStatusUpdated(string status)
    {
        public readonly string Status = status;

        public static TowStatusUpdatedEvent CreateEvent(TowId publisherId, TowStatus status)
        {
            return new TowStatusUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowStatusUpdated).Name,
                new TowStatusUpdated(
                    status.GetValue()
                )
            );
        }
    }
}
