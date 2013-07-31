using System;
using System.Configuration;

namespace Moonghy.Configuration
{
    public class MoonghySettingsElement : ConfigurationElement
    {
        [ConfigurationProperty("server", DefaultValue = "mongodb://localhost:27017")]
        public String Server
        {
            get { return (String)this["server"]; }
            set { this["server"] = value; }
        }

        [ConfigurationProperty("database", DefaultValue = "local")]
        public String Database
        {
            get { return (String)this["database"]; }
            set { this["database"] = value; }
        }

        [ConfigurationProperty("collection", DefaultValue = "oplog.rs")]
        public String Collection
        {
            get { return (String)this["collection"]; }
            set { this["collection"] = value; }
        }
    }
}
