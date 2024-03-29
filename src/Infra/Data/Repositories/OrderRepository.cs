using Domain.Entity;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Infra.Data.Repositories;

[ExcludeFromCodeCoverage]

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(IConfiguration config, IMongoClient mongoClient) : base(config, mongoClient)
    {
    }

    public async Task<List<Order>> GetByStatus(OrderStatus status)
    {
        var filter = Builders<Order>.Filter.Eq(p => p.Status, status);

        return await _collection.Find(filter).ToListAsync();
    }
}

