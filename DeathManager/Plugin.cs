using fr34kyn01535.Uconomy;
using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Commands;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DeathManager
{
    public class DeathManager : RocketPlugin<Configuration>
    {
        public static UnturnedPlayer killer;
        public static DeathManager Instance;
        private IDictionary<string, DeathNote> deathNotes;


        protected override void Load()
        {
            Instance = this;

            if (Instance.Configuration.Instance.Enabled)
            {
                deathNotes = new Dictionary<string, DeathNote>();
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
        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    {"gun","{0} [GUN] {2} {1}"},
                    {"death","ADMIN [KILL] {0}"},
                    {"null","[NULL] {0}"},
                    {"food","[FOOD] {0}"},
                    {"arena","[ARENA] {0}"},
                    {"shred","[SHRED] {0}"},
                    {"punch","{0} [PUNCH] {2} {1}"},
                    {"bones","[BONES] {0}"},
                    {"melee","{0} [MELEE] {2} {1}"},
                    {"water","[WATER] {0}"},
                    {"breath","[BREATH] {0}"},
                    {"zombie","[ZOMBIE] {0}"},
                    {"animal","[ANIMAL] {0}"},
                    {"grenade","??? [EXPLOSION] {0}"},
                    {"vehicle","[VEHICLE] {0}"},
                    {"suicide","[SUICIDE] {0}"},
                    {"burning","[BURNING] {0}"},
                    {"headshot","+ [HEADSHOT]" },
                    {"landmine","??? [LANDMINE] {0}"},
                    {"roadkill","{0} [ROADKILL] {1}"},
                    {"bleeding","[BLEEDING] {0}"},
                    {"freezing","[FREEZING] {0}"},
                    {"infection","[INFECTION] {0}"},
                };
            }
        }

        private void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer )
        {
            deathNotes[player.SteamName] = new DeathNote() { Position = player.Position, TimeOfDeath = DateTime.Now };
            killer = UnturnedPlayer.FromCSteamID(murderer);
            string death = cause.ToString();
            string headshot = string.Empty;
            string Received = Configuration.Instance.KillerReward + Uconomy.Instance.Configuration.Instance.MoneyName;
            string TotalMoney = Uconomy.Instance.Database.IncreaseBalance(killer.Id, Configuration.Instance.KillerReward) + Uconomy.Instance.Configuration.Instance.MoneyName;
            if (Instance.Configuration.Instance.EffectOnDeath)
            {
                EffectManager.sendEffect((ushort)Instance.Configuration.Instance.EffectOnDeathId, 30, player.Position);
            }
            if (Instance.Configuration.Instance.ShowHeadshotMessages)
            {
                headshot = Instance.Translations.Instance.Translate("headshot");
            }
            try
            {
                switch (death)
                {

                    case "BLEEDING":
                        UnturnedChat.Say(Translate("bleeding", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "BONES":
                        UnturnedChat.Say(Translate("bones", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "FREEZING":
                        UnturnedChat.Say(Translate("freezing", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "BURNING":
                        UnturnedChat.Say(Translate("burning", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "FOOD":
                        UnturnedChat.Say(Translate("food", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "WATER":
                        UnturnedChat.Say(Translate("water", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "GUN":
                        if (limb == ELimb.SKULL)
                            UnturnedChat.Say(Translate("gun", killer.DisplayName, player.DisplayName, headshot), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        else
                            UnturnedChat.Say(Translate("gun", killer.DisplayName, player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "MELEE":
                        if (limb == ELimb.SKULL)
                            UnturnedChat.Say(Translate("melee", killer.DisplayName, player.DisplayName, headshot), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        else
                            UnturnedChat.Say(Translate("melee", killer.DisplayName, player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "ZOMBIE":
                        UnturnedChat.Say(Translate("zombie", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "ANIMAL":
                        UnturnedChat.Say(Translate("animal", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "KILL":
                        UnturnedChat.Say(Translate("kill", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "INFECTION":
                        UnturnedChat.Say(Translate("infection", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "PUNCH":
                        if (limb == ELimb.SKULL)
                            UnturnedChat.Say(Translate("punch", killer.DisplayName, player.DisplayName, headshot), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        else
                            UnturnedChat.Say(Translate("punch", killer.DisplayName, player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "BREATH":
                        UnturnedChat.Say(Translate("breath", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "ROADKILL":
                        UnturnedChat.Say(Translate("roadkill", killer.DisplayName, player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "VEHICLE":
                        UnturnedChat.Say(Translate("vehicle", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "GRENADE":
                        UnturnedChat.Say(Translate("grenade", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "SHRED":
                        UnturnedChat.Say(Translate("shred", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "LANDMINE":
                        UnturnedChat.Say(Translate("landmine", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "ARENA":
                        UnturnedChat.Say(Translate("arena", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    case "SUICIDE":
                        if (Instance.Configuration.Instance.ShowSuicideMessages)
                            UnturnedChat.Say(Translate("suicide", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
                        break;
                    default:
                        UnturnedChat.Say(Translate("null", player.DisplayName), UnturnedChat.GetColorFromName(Configuration.Instance.DeathMessagesColor, Color.green));
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
        internal void TrySendBack(UnturnedPlayer player )
        {
            if (!Configuration.Instance.BackEnabled)
                return;

            if (deathNotes.ContainsKey(player.SteamName))
            {
                DeathNote deathNote = deathNotes[player.SteamName];

                if (DateTime.Now <= deathNote.TimeOfDeath.AddSeconds(Configuration.Instance.TimeLimit))
                {
                    // Teleporting the player back.
                    player.Teleport(deathNote.Position, player.Rotation);

                    // Saying hello to the dead :)
                    UnturnedChat.Say(player, "Back !");
                }
                else
                    UnturnedChat.Say(player, "too slow, have a nice walk. ");

                // Removing the reference, we dont want a smart player using our plugin as fast travel.
                deathNotes.Remove(player.SteamName);
            }
            else
            {
                // Cant find the poor guy =/
                UnturnedChat.Say(player, "You have to die first !");
            }
        }
        [RocketCommand("back", "Back To Death Location", "", AllowedCaller.Both)]

        public void Execute(UnturnedPlayer caller , string[] command)
        {
            if (command.Length == 0)
            {
                if (caller is ConsolePlayer)
                {
                    Logger.Log("Admin , Your trying to execute the command from console , Back : to your fucking server!");
                    return;
                }
                if (caller != null )
                    TrySendBack(caller);
            }
        }
    }

    }
