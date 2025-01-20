using Tow.Infrastructure;

namespace RabbitMQ.Contracts
{
    public class CreateTowDtoCreator : DtoCreator<CreateTow, CreateTowDto>
    {
        public override CreateTowDto CreateDto(CreateTow message)
        {
            return new CreateTowDto(
                message.Brand,
                message.Model,
                message.Color,
                message.LicensePlate,
                message.Location,
                message.Year,
                message.SizeType,
                message.Status
            );
        }
    }
}