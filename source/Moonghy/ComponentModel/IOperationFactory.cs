using MongoDB.Bson;
using System;

namespace Moonghy.Core
{
    public interface IOperationFactory
    {
        String Code { get; }
        Operation ComposeFrom(BsonDocument document);
    }
}
