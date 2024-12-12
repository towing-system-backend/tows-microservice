using MongoDB.Bson.Serialization.Attributes;

namespace Tow.Infrastructure
{
    public class MongoTow
    {
        [BsonId]
        public string towId { get; set; }

        public string brand { get; set; }

        public string model { get; set; }

        public string color { get; set; }

        public string licenPlate { get; set; }

        public int year { get; set; }

        public string sizeType { get; set; }

        public string status { get; set; }
    }
}
