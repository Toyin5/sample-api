using MongoDB.Driver;

namespace SampleAPI.Persistence;
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {

        var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
        _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
    }

    public IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _database.GetCollection<T>(collectionName);
    }
}
