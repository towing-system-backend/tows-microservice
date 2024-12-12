using Application.Core;

namespace Tow.Domain
{
    public class TowYearUpdatedEvent(string publisherId, string type, TowYearUpdated context) : DomainEvent(publisherId, type, context) { }

    public class TowYearUpdated(int year)
    {
        public readonly int Year = year;

        public static TowYearUpdatedEvent CreateEvent(TowId publisherId, TowYear year)
        {
            return new TowYearUpdatedEvent(
                publisherId.GetValue(),
                typeof(TowYearUpdated).Name,
                new TowYearUpdated(
                    year.GetValue()
                )
            );

        }
    }
}
