using MongoDB.Bson;
using System;

namespace Moonghy
{
    public interface IOperationFactory
    {
        String Code { get; }
        Operation ComposeFrom(BsonDocument document);
    }
}
