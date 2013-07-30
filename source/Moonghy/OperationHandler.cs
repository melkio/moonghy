using MongoDB.Bson;
using Moonghy.Operations;
using System;

namespace Moonghy
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

    // TODO: da cancellare!!!!

    public class AllOperationsHandler : OperationHandler<Operation>
    {
        public override void Handle(Operation operation)
        {
            
        }
    }

    public class InsertOperationsHandler : OperationHandler<InsertOperation>
    {
        public override Boolean ShouldHandle(InsertOperation operation)
        {
            return operation.Document["name"].AsString.Contains("alessandro");
        }

        public override void Handle(InsertOperation operation)
        {

        }
    }

    public class UpdateOperationsHandler : OperationHandler<UpdateOperation>
    {
        public override void Handle(UpdateOperation operation)
        {

        }
    }

    public class Update2OperationsHandler : OperationHandler<UpdateOperation>
    {
        public override Boolean ShouldHandle(UpdateOperation operation)
        {
            return operation.Document["name"].AsString.Contains("emanuele");
        }

        public override void Handle(UpdateOperation operation)
        {

        }
    }
}
