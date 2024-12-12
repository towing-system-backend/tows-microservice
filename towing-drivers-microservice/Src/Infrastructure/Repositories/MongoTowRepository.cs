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
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.towId, id);
            var res = await _towCollection.Find(filter).FirstOrDefaultAsync();

            if (res == null)
            {
                return IsOptional.Empty();
            }

            return IsOptional.Of(
                Domain.Tow.Create(
                    new TowId(res.towId),
                    new TowBrand(res.brand),
                    new TowModel(res.model),
                    new TowColor(res.color),
                    new TowLicensePlate(res.licenPlate),
                    new TowYear(res.year),
                    new TowSizeType(res.sizeType),
                    new TowStatus(res.status),
                    true
                   
                )
            );
        }

        public async Task<IsOptional> FindByLicensePlate(string licensePlate)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.licenPlate, licensePlate);
            var res = await _towCollection.Find(filter).FirstOrDefaultAsync();
            
            if (res == null)
            {
                return IsOptional.Empty();
            }

            return IsOptional.Of(
                Domain.Tow.Create(
                    new TowId(res.towId),
                    new TowBrand(res.brand),
                    new TowModel(res.model),
                    new TowColor(res.color),
                    new TowLicensePlate(res.licenPlate),
                    new TowYear(res.year),
                    new TowSizeType(res.sizeType),
                    new TowStatus(res.status),
                    true
                )
            );
        }

        public async Task Save(Domain.Tow tow)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.towId, tow.GetTowId().GetValue());
            var update = Builders<MongoTow>.Update
                .Set(account => account.brand, tow.GetTowBrand().GetValue())
                .Set(account => account.model, tow.GetTowModel().GetValue())
                .Set(account => account.color, tow.GetTowColor().GetValue())
                .Set(account => account.licenPlate, tow.GetTowLicensePlate().GetValue())
                .Set(account => account.year, tow.GetTowYear().GetValue())
                .Set(account => account.sizeType, tow.GetTowSizeType().GetValue())
                .Set(account => account.status, tow.GetTowStatus().GetValue());

            await _towCollection.UpdateOneAsync(filter, update, new UpdateOptions { IsUpsert = true });
        }

        public async Task Remove(string id)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.towId, id);
            await _towCollection.DeleteOneAsync(filter);
        }
    }
}
