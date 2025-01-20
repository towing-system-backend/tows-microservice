using Application.Core;

namespace Tow.Domain
{
    public class TowModelUpdatedEvent(string publisherId, string type, TowModelUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowModelUpdated(string model)
    {
        public readonly string Model = model;

        public static TowModelUpdatedEvent CreateEvent(TowId publisherId, TowModel model)
        {
            return new TowModelUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowModelUpdated).Name,
                new TowModelUpdated(
                    model.GetValue()
                )
            );
        }
    }
}
