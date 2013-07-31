using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Moonghy.Configuration;
using Moonghy.Core;
using Moonghy.Runtime;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace Moonghy
{
    class Program
    {
        static IEnumerable<IOperationHandler> handlers = new IOperationHandler[] 
        {
        };

        static AggregateOperationFactory factory = new AggregateOperationFactory(new IOperationFactory[] { new InsertOperationFactory(), new UpdateOperationFactory()});

        static void Main(String[] args)
        {
            try 
            {
                var config = (MoonghySection)ConfigurationManager.GetSection("moonghy");
                var collection = config.GetCollection();

                // to test the tailable cursor manually insert documents into the test.capped collection
                // while this program is running and verify that they are echoed to the console window

                // see: http://www.mongodb.org/display/DOCS/Tailable+Cursors for C++ version of this loop
                var timestamp = new BsonTimestamp(0);
                while (true) 
                {
                    var query = Query.GT("ts", timestamp);
                    var cursor = collection.Find(query)
                        .SetFlags(QueryFlags.TailableCursor | QueryFlags.AwaitData | QueryFlags.NoCursorTimeout)
                        .SetSortOrder("$natural");
                    using (var enumerator = (MongoCursorEnumerator<BsonDocument>) cursor.GetEnumerator()) {
                        while (true) 
                        {
                            if (enumerator.MoveNext()) 
                            {
                                var document = enumerator.Current;
                                Operation operation = factory.ComposeFrom(document);
                                
                                handlers
                                    .Where(h => h.ShouldHandle(operation))
                                    .ToList()
                                    .ForEach(h => h.Handle(operation));

                                timestamp = operation.Timestamp;
                            } 
                            else 
                            {
                                if (enumerator.IsDead)
                                    break;
                                if (!enumerator.IsServerAwaitCapable) 
                                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                            }
                        }
                    }
                }
            } 
            catch (Exception ex) 
            {
                Console.WriteLine("Unhandled exception:");
                Console.WriteLine(ex);
            }

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

        private static void ProcessDocument(BsonDocument document) 
        {
            Console.WriteLine(document.ToJson());
        }
    }
}
