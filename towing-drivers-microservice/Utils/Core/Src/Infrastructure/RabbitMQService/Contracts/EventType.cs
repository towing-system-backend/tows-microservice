namespace RabbitMQ.Contracts
{
    public interface IRabbitMQMessage { };
    public class EventType(
        string PublisherId,
        string Type,
        object Context,
        DateTime OcurredDate
    );

    public record CreateTow(
        string Brand,
        string Model,
        string Color,
        string LicensePlate,
        string Location,
        int Year,
        string SizeType,
        string Status
    ) : IRabbitMQMessage;
}
