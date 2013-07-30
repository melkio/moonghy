using MongoDB.Bson;
using System;

namespace Moonghy.Operations
{
    public sealed class UpdateOperation : Operation
    {
        public BsonDocument Query { get; private set; }

        public sealed class Factory : IOperationFactory
        {
            public String Code
            {
                get { return "u"; }
            }

            public Operation ComposeFrom(BsonDocument document)
            {
                var operation = new UpdateOperation();
                operation.Timestamp = document["ts"].AsBsonTimestamp;
                operation.Namespace = document["ns"].AsString;
                operation.Document = document["o"].AsBsonDocument;
                operation.Query = document["o2"].AsBsonDocument;

                return operation;
            }
        }

    }
}
