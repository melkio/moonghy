using System.Configuration;

namespace Moonghy.Configuration
{
    public class MoonghySection : ConfigurationSection
    {
        [ConfigurationProperty("settings", IsRequired = true)]
        public MoonghySettingsElement Settings
        {
            get { return (MoonghySettingsElement)this["settings"]; }
            set { this["settings"] = value; }
        }
    }
}
