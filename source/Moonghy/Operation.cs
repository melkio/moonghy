using MongoDB.Bson;
using System;

namespace Moonghy
{
    public abstract class Operation
    {
        public BsonTimestamp Timestamp { get; protected set; }
        public String Namespace { get;  protected set; }
        public BsonDocument Document { get; protected set; }
    }
}
