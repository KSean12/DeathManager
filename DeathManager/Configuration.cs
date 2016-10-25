using Rocket.API;

namespace DeathManager
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled = true;

        public bool ShowErrorMessages ;
        public bool ShowSuicideMessages ;
        public bool ShowHeadshotMessages ;

        public string DeathMessagesColor;

        public void LoadDefaults()
        {
            Enabled = true;
            ShowErrorMessages = true;
            ShowSuicideMessages = true;
            ShowHeadshotMessages = true;
            DeathMessagesColor = "Red";
        }
    }
}
