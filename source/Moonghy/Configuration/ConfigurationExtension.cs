using MongoDB.Bson;
using MongoDB.Driver;

namespace Moonghy.Configuration
{
    static class ConfigurationExtension
    {
        public static MongoCollection<BsonDocument> GetCollection(this MoonghySection section)
        {
            var client = new MongoClient(section.Settings.Server);
            var server = client.GetServer();
            var database = server.GetDatabase(section.Settings.Database);
            var collection = database.GetCollection(section.Settings.Collection);

            return collection;
        }
    }
}
