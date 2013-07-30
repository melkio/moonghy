using MongoDB.Bson;
using System;

namespace Moonghy.Core
{
    public sealed class UpdateOperation : Operation
    {
        public BsonDocument Query { get; private set; }

        public UpdateOperation(BsonTimestamp timestamp, String @namespace, BsonDocument document, BsonDocument query)
            : base(timestamp, @namespace, document)
        {
            Query = query;
        }
    }
}
