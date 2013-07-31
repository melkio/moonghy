using MongoDB.Bson;
using Moonghy.Core;
using System;

namespace Moonghy.ComponentModel
{
    interface IOperationFactory
    {
        String Code { get; }
        Operation ComposeFrom(BsonDocument document);
    }
}
