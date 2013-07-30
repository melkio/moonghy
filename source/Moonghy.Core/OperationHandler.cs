using MongoDB.Bson;
using System;

namespace Moonghy.Core
{
    public interface IOperationHandler
    {
        Boolean ShouldHandle(Operation operation);
        void Handle(Operation operation);
    }

    public abstract class OperationHandler<TOperation> : IOperationHandler 
        where TOperation : Operation
    {
        public virtual Boolean ShouldHandle(TOperation operation)
        {
            return true;
        }

        public abstract void Handle(TOperation operation);

        Boolean IOperationHandler.ShouldHandle(Operation operation)
        {
            var matchOperationType = operation is TOperation;
            return matchOperationType && ShouldHandle((TOperation) operation);
        }

        void IOperationHandler.Handle(Operation operation)
        {
            var matchOperationType = operation is TOperation;
            if (!matchOperationType)
            {
                var message = String.Format("Isn't possible handle operation of type {0} by handler {1}", typeof(TOperation).FullName, this.GetType().FullName);
                throw new InvalidOperationException(message);
            }

            Handle((TOperation)operation);
        }
    }
}
