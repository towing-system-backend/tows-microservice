using Application.Core;
using MongoDB.Driver;
using Tow.Application;

namespace Tow.Infrastructure
{
    public class FindTowByIdQuery : IService<FindTowByIdDto, FindTowByIdResponse>
    {
        private readonly IMongoCollection<MongoTow> _towCollection;

        public FindTowByIdQuery()
        {
            MongoClient client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_URI"));
            IMongoDatabase database = client.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));
            _towCollection = database.GetCollection<MongoTow>("tows");
        }

        public async Task<Result<FindTowByIdResponse>> Execute(FindTowByIdDto query)
        {
            var filter = Builders<MongoTow>.Filter.Eq(tow => tow.TowId, query.Id);
            var res = await _towCollection.Find(filter).FirstOrDefaultAsync();

            if (res == null) return Result<FindTowByIdResponse>.MakeError(new TowNotFoundExceptionError());

            return Result<FindTowByIdResponse>.MakeSuccess(
                new FindTowByIdResponse(
                    res.TowId,
                    res.Brand,
                    res.Model,
                    res.Color,
                    res.LicensePlate,
                    res.Location,
                    res.Year,
                    res.SizeType,
                    res.Status
                )
            );
        }
    }
}
