using Application.Core;

namespace Tow.Application
{
    using Tow.Domain;
    public class CreateTowCommandHandler(IdService<string> idService, IMessageBrokerService messageBrokerService,  IEventStore eventStore, ITowRepository towRepository) : IService<CreateTowCommand, CreateTowResponse>
    {
        private readonly IdService<string> _idService = idService;
        private readonly IMessageBrokerService _messageBrokerService = messageBrokerService;
        private readonly IEventStore _eventStore = eventStore;
        private readonly ITowRepository _towRepository = towRepository;

        public async Task<Result<CreateTowResponse>> Execute(CreateTowCommand command)
        {
            var response = await _towRepository.FindByLicensePlate(command.LicensePlate);
            if (response.HasValue())
            {
                return Result<CreateTowResponse>.MakeError(new TowAlreadyExistException());
            }
            var id = _idService.GenerateId();
            var tow = Tow.Create(
                new TowId(id),
                new TowBrand(command.Brand),
                new TowModel(command.Model),
                new TowColor(command.Color),
                new TowLicensePlate(command.LicensePlate),
                new TowYear(command.Year),
                new TowSizeType(command.SizeType),
                new TowStatus(command.Status)

            );

            await _towRepository.Save(tow);
            var events = tow.PullEvents();
            await _eventStore.AppendEvents(events);
            await _messageBrokerService.Publish(events);


            return Result<CreateTowResponse>.MakeSuccess(new CreateTowResponse(id));
        }
    }
}
