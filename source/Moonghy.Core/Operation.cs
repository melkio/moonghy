using MongoDB.Bson;
using System;

namespace Moonghy.Core
{
    public abstract class Operation
    {
        public BsonTimestamp Timestamp { get; private set; }
        public String Namespace { get;  private set; }
        public BsonDocument Document { get; private set; }

        public Operation(BsonTimestamp timestamp, String @namespace, BsonDocument document)
        {
            Timestamp = timestamp;
            Namespace = @namespace;
            Document = document;
        }
    }
}
