using Rocket.API;

namespace DeathManager
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool Debug;
        public string DeathMessagesColor;
        public bool ShowSuicideMessages;
        public bool ShowHeadshotMessages;

        public void LoadDefaults()
        {
            Enabled = true;
            Debug = true;
            ShowSuicideMessages = true;
            ShowHeadshotMessages = true;
            DeathMessagesColor = "Red";
        }
    }
}