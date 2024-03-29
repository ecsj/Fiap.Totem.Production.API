using Domain.Base;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Domain.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Data.Repositories;
[ExcludeFromCodeCoverage]
public class Repository<T> : IRepository<T> where T : Entity
{
    protected readonly IMongoCollection<T> _collection;


    public Repository(IConfiguration config, IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase("ProductionOrder");

        _collection = database.GetCollection<T>(nameof(T));
    }

    public async Task AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task<List<T>> Get()
    {
        return await _collection.Find(new BsonDocument()).ToListAsync();

    }
    public async Task<T> GetEntityByIdAsync(string id)
    {
        var entity = await _collection.FindAsync(f => f.Id == id);

        return await entity.FirstOrDefaultAsync();
    }

    public virtual async Task<bool> UpdateAsync(string id, T entity)
    {
        var result = await _collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", id), entity);
        return result.ModifiedCount > 0;
    }


    public virtual async Task<bool> DeleteAsync(string id)
    {
        var result = await _collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id));
        return result.DeletedCount > 0;
    }
}