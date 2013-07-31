using Moonghy.Core;
using StructureMap;
using System;

namespace Moonghy
{
    class Bootstrapper
    {
        private readonly String _directory;

        public Bootstrapper(String directory)
        {
            _directory = directory;
        }

        public IContainer Boot()
        {
            var container = new Container(c =>
                {
                    c.AddRegistry<DefaultRegistry>();
                    c.Scan(s =>
                    {
                        s.AssembliesFromPath(_directory);
                        s.AddAllTypesOf<IOperationHandler>();
                    });
                });

            return container;
        }
    }
}
