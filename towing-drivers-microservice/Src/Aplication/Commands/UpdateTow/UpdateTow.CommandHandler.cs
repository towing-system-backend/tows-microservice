using Application.Core;

namespace Tow.Application
{
    using System.Threading.Tasks;
    using Tow.Domain;
    public class UpdateTowCommandHandler(IMessageBrokerService messageBrokerService, IEventStore eventStore, ITowRepository towRepository) : IService<UpdateTowCommand, UpdateTowResponse>
    {
        private readonly IMessageBrokerService _messageBrokerService = messageBrokerService;
        private readonly IEventStore _eventStore = eventStore;
        private readonly ITowRepository _towRepository = towRepository;

        public async Task<Result<UpdateTowResponse>> Execute(UpdateTowCommand command)
        {
            var towRegistered = await _towRepository.FindById(command.Id);
            if (!towRegistered.HasValue())
            {
                return Result<UpdateTowResponse>.MakeError(new TowNotFoundException());
            }

            var tow = towRegistered.Unwrap();
            if (command.Brand != null) tow.UpdateTowBrand(new TowBrand(command.Brand));
            if (command.Model != null) tow.UpdateTowModel(new TowModel(command.Model));
            if (command.Color != null) tow.UpdateTowColor(new TowColor(command.Color));
            if (command.LicensePlate != null) tow.UpdateTowLicensePlate(new TowLicensePlate(command.LicensePlate));
            if (command.Year != null) tow.UpdateTowYear(new TowYear(command.Year.Value));
            if (command.SizeType != null) tow.UpdateTowSizeType(new TowSizeType(command.SizeType));
            if (command.Status != null) tow.UpdateTowStatus(new TowStatus(command.Status));

           var events = tow.PullEvents();
           await _towRepository.Save(tow);
           await _eventStore.AppendEvents(events); 
           await _messageBrokerService.Publish(events); 
            


            return Result<UpdateTowResponse>.MakeSuccess(new UpdateTowResponse(command.Id));

        }
    }
}
