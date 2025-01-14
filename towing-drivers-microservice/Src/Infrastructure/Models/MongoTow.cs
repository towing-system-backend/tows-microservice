using MongoDB.Bson.Serialization.Attributes;

namespace Tow.Infrastructure
{
    public class MongoTow
    (
        string towId,
        string brand,
        string model,
        string color,
        string licensePlate,
        string location,
        int year,
        string sizeType,
        string status
    )
    {
        [BsonId]
        public string TowId = towId;
        public string Brand = brand;
        public string Model = model;
        public string Color = color;
        public string LicensePlate = licensePlate;
        public string Location = location;
        public int Year = year;
        public string SizeType = sizeType;
        public string Status = status;
        public DateTime CreatedAt = DateTime.Now;
    }
}

