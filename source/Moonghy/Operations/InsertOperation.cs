using MongoDB.Bson;
using System;

namespace Moonghy.Operations
{
    public sealed class InsertOperation : Operation
    {
        public class Factory : IOperationFactory
        {
            public String Code
            {
                get { return "i"; }
            }

            public Operation ComposeFrom(BsonDocument document)
            {
                var operation = new InsertOperation();
                operation.Timestamp = document["ts"].AsBsonTimestamp;
                operation.Namespace = document["ns"].AsString;
                operation.Document = document["o"].AsBsonDocument;

                return operation;
            }
        }
    }
}
