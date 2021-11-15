using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Interfaces;
using System.IO;
using Exiled.API.Features;


namespace BetterMute
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public string DataDir = Path.Combine(Paths.Plugins, "BetterMute");
    }
}
