using Moonghy.Core;
using System;

namespace Moonghy.Test
{
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
