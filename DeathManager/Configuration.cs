using Rocket.API;

namespace DeathManager
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool Debug;

        public void LoadDefaults()
        {
            Enabled = true;
            Debug = true;
        }
    }
}