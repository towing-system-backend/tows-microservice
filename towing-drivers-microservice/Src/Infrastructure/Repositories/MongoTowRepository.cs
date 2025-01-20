using IsOptional = Application.Core.Optional<Tow.Domain.Tow>;
using MongoDB.Driver;
using Tow.Domain;

namespace Tow.Infrastructure
{
    public class MongoTowRepository : ITowRepository
    {
        private readonly IMongoCollection<MongoTow> _towCollection;

        public MongoTowRepository()
        {
            MongoClient client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_URI"));
            IMongoDatabase database = client.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));
            _towCollection = database.GetCollection<MongoTow>("tows");
        }
        public async Task<IsOptional> FindById(string id)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.TowId, id);
            var res = await _towCollection.Find(filter).FirstOrDefaultAsync();

            if (res == null)
            {
                return IsOptional.Empty();
            }

            return IsOptional.Of(
                Domain.Tow.Create(
                    new TowId(res.TowId),
                    new TowBrand(res.Brand),
                    new TowModel(res.Model),
                    new TowColor(res.Color),
                    new TowLicensePlate(res.LicensePlate),
                    new TowLocation(res.Location),
                    new TowYear(res.Year),
                    new TowSizeType(res.SizeType),
                    new TowStatus(res.Status),
                    true
                   
                )
            );
        }

        public async Task<IsOptional> FindByLicensePlate(string licensePlate)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.LicensePlate, licensePlate);
            var res = await _towCollection.Find(filter).FirstOrDefaultAsync();
            
            if (res == null)
            {
                return IsOptional.Empty();
            }

            return IsOptional.Of(
                Domain.Tow.Create(
                    new TowId(res.TowId),
                    new TowBrand(res.Brand),
                    new TowModel(res.Model),
                    new TowColor(res.Color),
                    new TowLicensePlate(res.LicensePlate),
                    new TowLocation(res.Location),
                    new TowYear(res.Year),
                    new TowSizeType(res.SizeType),
                    new TowStatus(res.Status),
                    true
                )
            );
        }

        public async Task Save(Domain.Tow tow)
        {
            
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.TowId, tow.GetTowId().GetValue());
            var update = Builders<MongoTow>.Update
                .Set(account => account.Brand, tow.GetTowBrand().GetValue())
                .Set(account => account.Model, tow.GetTowModel().GetValue())
                .Set(account => account.Color, tow.GetTowColor().GetValue())
                .Set(account => account.LicensePlate, tow.GetTowLicensePlate().GetValue())
                .Set(account => account.Location, tow.GetTowLocation().GetValue())
                .Set(account => account.Year, tow.GetTowYear().GetValue())
                .Set(account => account.SizeType, tow.GetTowSizeType().GetValue())
                .Set(account => account.Status, tow.GetTowStatus().GetValue())
                .SetOnInsert(tow => tow.CreatedAt, DateTime.Now);

            await _towCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public async Task Remove(string id)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.TowId, id);
            await _towCollection.DeleteOneAsync(filter);
        }
    }
}
