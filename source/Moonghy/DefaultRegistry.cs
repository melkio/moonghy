using Moonghy.ComponentModel;
using Moonghy.Runtime;
using StructureMap.Configuration.DSL;

namespace Moonghy
{
    class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<IOperationFactory>().Use<InsertOperationFactory>();
            For<IOperationFactory>().Use<UpdateOperationFactory>();

            For<AggregateOperationFactory>().Use<AggregateOperationFactory>();
        }
    }
}
