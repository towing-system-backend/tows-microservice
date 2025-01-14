using Application.Core;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Tow.Application;

namespace Tow.Infrastructure
{
    public class FindAllTowQuery : IService<object, List<FindAllTowResponse>>
    {
        private readonly IMongoCollection<MongoTow> _towCollection;

        public FindAllTowQuery()
        {
            MongoClient client = new MongoClient(Environment.GetEnvironmentVariable("CONNECTION_URI"));
            IMongoDatabase database = client.GetDatabase(Environment.GetEnvironmentVariable("DATABASE_NAME"));
            _towCollection = database.GetCollection<MongoTow>("tows");
        }
        public async Task<Result<List<FindAllTowResponse>>> Execute(object data)
        {
            Console.WriteLine("hola");
            var filter = Builders<MongoTow>.Filter.Empty;
            var res = await _towCollection.Find(filter).ToListAsync();

            Console.WriteLine(res);

            if (res.IsNullOrEmpty()) return Result<List<FindAllTowResponse>>.MakeError(new TowNotFoundExceptionError());

            var tows = res.Select(
                tow => new FindAllTowResponse(
                    tow.TowId,
                    tow.Brand,
                    tow.Model,
                    tow.Color,
                    tow.LicensePlate,
                    tow.Location,
                    tow.Year,
                    tow.SizeType,
                    tow.Status

                )
            ).ToList();
            return Result<List<FindAllTowResponse>>.MakeSuccess(tows);
        }
    }
}
