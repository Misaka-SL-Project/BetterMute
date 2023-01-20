using System;
using CommandSystem;
using Exiled.API.Features;
using static BetterMute.EventHandlers.EventHandlers;

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
            if (int.TryParse(arguments.At(0), out int result))
            {
                Player player = Player.Get(result);
                player.IsMuted = true;
                player.IsIntercomMuted = true;
                string userid = player.UserId;
                int duration = 1;
                if (int.TryParse(arguments.At(1), out int result2))
                {
                    duration = result2;
                }
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
