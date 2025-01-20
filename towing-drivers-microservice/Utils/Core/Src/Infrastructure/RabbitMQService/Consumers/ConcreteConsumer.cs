using MassTransit;
using RabbitMQ.Contracts;

namespace Application.Core
{
    public class CreateTowConsumer(IServiceProvider serviceProvider) : IConsumer<CreateTow>
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        public Task Consume(ConsumeContext<CreateTow> @event)
        {
            var message = @event.Message;
            new MessageProcessor(_serviceProvider).ProcessMessage(message);

            return Task.CompletedTask;
        }
    }
}