using System;
using CommandSystem;
using Exiled.API.Features;
using static BetterMute.EventHandlers.ServerHandlers;

namespace BetterMute
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class MuteCommand : ICommand
    {
        public string[] Aliases { get; } = { };
        public string Command => "bmute";
        public string Description => "Mute player with configurable duration";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Log.Info(1);
            if (Int32.TryParse(arguments.At(0), out int result))
            {
                Log.Info(2);
                Player player = Player.Get(result);
                Log.Info(3);
                player.IsMuted = true;
                player.IsIntercomMuted = true;
                string userid = player.UserId;
                int duration = 1;
                if (Int32.TryParse(arguments.At(1), out int result2))
                {
                    duration = result2;
                }
                Log.Info(4);
                AddingMuteStatus(userid, duration);
                response = $"{player.Nickname} will be muted for {duration} rounds";
            }
            else
            {
                response = "Please enter player id";
            }
            return true;
        }
    }
}
