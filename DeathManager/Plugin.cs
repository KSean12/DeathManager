using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;

namespace DeathManager
{
    public class DeathManager : RocketPlugin<Configuration>
    {

        public static DeathManager Instance;

        protected override void Load()
        {
            Instance = this;

            if (Instance.Configuration.Instance.Enabled)
            {
                UnturnedPlayerEvents.OnPlayerDeath += UnturnedPlayerEvents_OnPlayerDeath;

                Logger.Log("[DeathManager] The Plugin Has Been loaded!");
                
            }
        }

        protected override void Unload()
        {
            if (Instance.Configuration.Instance.Enabled)
            {
                UnturnedPlayerEvents.OnPlayerDeath -= UnturnedPlayerEvents_OnPlayerDeath;
            }
        }


       

        private void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, Steamworks.CSteamID murderer)
        {
            //string killer = 
            string death = cause.ToString();
          
            try
            {
                switch (death)
                {
                    case "BLEEDING":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "BONES":
                        UnturnedChat.Say("["+ death +"]" + player.DisplayName );
                        break;
                    case "FREEZING":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "BURNING":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "FOOD":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "WATER":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "GUN":
                        if (limb == ELimb.SKULL)
                            UnturnedChat.Say("["+ death +"]" + "[Murderer: " + murderer.ToString() + " ]" +  player.DisplayName + limb);
                        else
                            UnturnedChat.Say("[" + death + "]" + "[Murderer: " + murderer.ToString() + " ]" + player.DisplayName);
                        break;
                    case "MELEE":
                        if (limb == ELimb.SKULL)
                            UnturnedChat.Say(death + player.DisplayName);
                        else
                            UnturnedChat.Say(death + player.DisplayName);
                        break;
                    case "ZOMBIE":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "ANIMAL":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "KILL":
                        UnturnedChat.Say("[" + death + "]" + "[Murderer: " + murderer.ToString() + " ]" + player.DisplayName);
                        break;
                    case "INFECTION":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "PUNCH":
                        if (limb == ELimb.SKULL)
                            UnturnedChat.Say("[" + death + "]" + "[Murderer: " + murderer.ToString() + " ]" + player.DisplayName + limb);
                        else
                            UnturnedChat.Say("[" + death + "]" + "[Murderer: " + murderer.ToString() + " ]" + player.DisplayName);
                        break;
                    case "BREATH":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "ROADKILL":
                        UnturnedChat.Say("[" + death + "]" + "[Murderer: " + murderer.ToString() + "]" + player.DisplayName);
                        break;
                    case "VEHICLE":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "GRENADE":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "SHRED":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "LANDMINE":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "ARENA":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    case "SUICIDE":
                        UnturnedChat.Say("[" + death + "]" + player.DisplayName);
                        break;
                    default:
                        UnturnedChat.Say(death + player.DisplayName);
                        break;
                }
            }
            catch (Exception exc)
            {
                if (Instance.Configuration.Instance.Debug)
                {
                    Logger.LogError("[DeathManager] Error : " + exc);

                }
            }
        }

    }
}