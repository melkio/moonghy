using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Threading;

namespace Moonghy
{
    class Program
    {
        static void Main(String[] args)
        {
            try 
            {
                var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27100");
                var server = client.GetServer();
                var database = server.GetDatabase("local");
                var collection = database.GetCollection("oplog.rs");

                // to test the tailable cursor manually insert documents into the test.capped collection
                // while this program is running and verify that they are echoed to the console window

                // see: http://www.mongodb.org/display/DOCS/Tailable+Cursors for C++ version of this loop
                var timestamp = BsonTimestamp.Create(0);
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
                                timestamp = document["ts"].AsBsonTimestamp;
                                ProcessDocument(document);
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
