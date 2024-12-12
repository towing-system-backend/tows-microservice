using Application.Core;

namespace Tow.Domain
{
   public interface ITowRepository
    {
        Task<Optional<Tow>> FindById(string towId);
        Task<Optional<Tow>> FindByLicensePlate(string licensePlate);
        Task Save(Tow user);
        Task Remove(string towId);
    }
}
