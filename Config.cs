using Exiled.API.Interfaces;
using System.ComponentModel;
using System.IO;
using Exiled.API.Features;


namespace BetterMute
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        [Description("Path of the Mute file")]
        public string DataDir { get; set; } = Path.Combine(Paths.Plugins, "BetterMute");
    }
}
