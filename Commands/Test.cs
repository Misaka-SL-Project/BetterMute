using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteAdmin;
using CommandSystem;
using Exiled.API.Features;

namespace TestingPlugin
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Test : ICommand
    {
        public string Command { get; } = "test";
        public string[] Aliases { get; } = new string[] { "t" };
        public string Description { get; } = "A simple test command.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(((CommandSender)sender).SenderId);
            response = player != null ? $"{player.Nickname} sent the command!" : "The command has been sent from the server console!";
            return true;
        }
    }
}
