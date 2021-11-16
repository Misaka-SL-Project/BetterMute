using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System.IO;

namespace BetterMute.EventHandlers
{
    public class EventHandlers
    {
        private readonly Plugin _plugin;
        public EventHandlers(Plugin plugin) => this._plugin = plugin;
        static Dictionary<Player, int> MutedPlayers = new Dictionary<Player, int>();
        public static string path;
        public static string[] MuteList;
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (Player player in MutedPlayers.Keys)
            {
                if (Player.List.Contains(player))
                {
                    if (MutedPlayers[player] > 1)
                    {
                        UpdateMuteStatus(player.UserId, MutedPlayers[player] - 1);
                    }
                    else
                    {
                        player.IsMuted = false;
                        player.IsIntercomMuted = false;
                        RemoveMuteStatus(player.UserId);
                    }
                }
            }
            MutedPlayers.Clear();
        }
        public void OnVerified(VerifiedEventArgs ev)
        {
            if (ev.Player.IsMuted || ev.Player.IsIntercomMuted)
            {
                for (int i = 0; i < MuteList.Count(); i++)
                {
                    if (MuteList[i].Split(' ').First() == ev.Player.UserId)
                    {
                        MutedPlayers.Add(ev.Player, Convert.ToInt32(MuteList[i].Split(' ').ElementAt(1)));
                        break;
                    }
                }
            }
        }
        public static void UpdateMuteStatus(string userid, int duration)
        {
            for (int i = 0; i < MuteList.Count(); i++)
            {
                if (MuteList[i].Split(' ').First() == userid)
                {
                    MuteList[i] = MuteList[i].Split(' ').First() + " " + duration;
                    break;
                }
            }
            File.WriteAllLines(path, MuteList);
        }
        public static void RemoveMuteStatus(string userid)
        {
            for (int i = 0; i < MuteList.Count(); i++)
            {
                if (MuteList[i].Split(' ').First() == userid)
                {
                    MuteList[i] = "";
                    break;
                }
            }
            File.WriteAllLines(path, MuteList);
        }
        public static void AddingMuteStatus(string userid, int duration)
        {
            MuteList.Append($"{userid} {duration}");
            File.WriteAllLines(path, MuteList);
            MutedPlayers.Add(Player.Get(userid), duration);
        }
        public static string[] GetMuteList()
        {
            return File.ReadAllLines(path);
        }
    }

}
