namespace RabbitMQ.Contracts
{
    public class EventType(
        string PublisherId,
        string Type,
        object Context,
        DateTime OcurredDate
    );
}
