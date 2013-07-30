using MongoDB.Bson;
using Moonghy.Core;
using System;

namespace Moonghy.Runtime
{
    class UpdateOperationFactory : IOperationFactory
    {
        public String Code
        {
            get { return "u"; }
        }

        public Operation ComposeFrom(BsonDocument document)
        {
            var operation = new UpdateOperation
                (
                    timestamp: document["ts"].AsBsonTimestamp,
                    @namespace: document["ns"].AsString,
                    document: document["o"].AsBsonDocument,
                    query: document["o2"].AsBsonDocument    
                );
            return operation;
        }
    }
}
