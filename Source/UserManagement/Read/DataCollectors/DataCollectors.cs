using MongoDB.Driver;
using System.Collections.Generic;
using Concepts.DataCollectors;
using Infrastructure.Read.MongoDb;

namespace Read.DataCollectors
{
    public class DataCollectors : ExtendedReadModelRepositoryFor<DataCollector>, IDataCollectors
    {
        public DataCollectors(IMongoDatabase database) : base(database)
        {
        }

        public override IMongoCollection<DataCollector> GetCollection()
        {
            return this._database.GetCollection<DataCollector>("DataCollectors");
        }

        public DataCollector GetById(DataCollectorId id)
        {
            return GetOne(d => d.Id == id);
        }

        public IEnumerable<DataCollector> GetAll()
        {
            return GetMany(_ => true);
        }
    }
}
