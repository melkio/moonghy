using MongoDB.Bson;
using Moonghy.Core;
using System;

namespace Moonghy.Runtime
{
    class InsertOperationFactory : IOperationFactory
    {
        public String Code
        {
            get { return "i"; }
        }

        public Operation ComposeFrom(BsonDocument document)
        {
            var operation = new InsertOperation
                (
                    timestamp: document["ts"].AsBsonTimestamp,
                    @namespace: document["ns"].AsString,
                    document: document["o"].AsBsonDocument
                );

            return operation;
        }
    }
}
