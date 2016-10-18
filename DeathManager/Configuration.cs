using Rocket.API;

namespace DeathManager
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool Debug;
        public string DeathMessagesColor;
        public bool ShowSuicideMessages, ShowHeadshotMessages, EffectOnDeath, BackEnabled;
        public decimal KillerReward, EffectOnDeathId;
        public double TimeLimit;

        public void LoadDefaults()
        {
            Enabled = true;
            Debug = true;
            ShowSuicideMessages = true;
            ShowHeadshotMessages = true;
            DeathMessagesColor = "Red";
            EffectOnDeath = true;
            EffectOnDeathId = 45;
            KillerReward = 500;
        }
    }
}