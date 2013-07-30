using MongoDB.Bson;
using System;

namespace Moonghy.Core
{
    public sealed class InsertOperation : Operation
    {
        public InsertOperation(BsonTimestamp timestamp, String @namespace, BsonDocument document)
            : base(timestamp, @namespace, document)
        {
        }
    }
}
