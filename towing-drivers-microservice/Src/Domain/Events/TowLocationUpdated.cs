using Application.Core;

namespace Tow.Domain
{
    public class TowLocationUpdatedEvent(string publisherId, string type, TowLocationUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowLocationUpdated(string location)
    {
        public readonly string Location = location;

        public static TowLocationUpdatedEvent CreateEvent(TowId publisherId, TowLocation location)
        {
            return new TowLocationUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowLocationUpdated).Name,
                new TowLocationUpdated(
                    location.GetValue()
                )
            );
        }
    }
}
