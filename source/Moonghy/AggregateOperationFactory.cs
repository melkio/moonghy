using MongoDB.Bson;
using Moonghy.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moonghy
{
    class AggregateOperationFactory : IOperationFactory
    {
        private readonly IOperationFactory[] _factories;

        public String Code 
        { 
            get { return "All"; } 
        }

        public AggregateOperationFactory()
            : this( new IOperationFactory[] { new InsertOperation.Factory(), new UpdateOperation.Factory() })
        {
        }

        public AggregateOperationFactory(IOperationFactory[] factories)
        {
            _factories = factories;
        }

        public Operation ComposeFrom(BsonDocument document)
        {
            var operationCode = document["op"].AsString;
            var factory = _factories.SingleOrDefault(f => f.Code == operationCode);
            if (factory != null)
                return factory.ComposeFrom(document);

            return new NullOperation();
        }
    }
}
