using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;

namespace TestingPlugin
{
    using EventHandlers;
    public class Plugin : Plugin<Config>
    {
    	public override string Author { get; } = "Killla";
		public override string Name { get; } = "Template Plugin";
		public override string Prefix { get; } = "TP";
		public override Version RequiredExiledVersion { get; } = new Version(3, 0, 0);

        public PlayerHandlers PlayerHandlers;
        public ServerHandlers ServerHandlers;
        public override void OnEnabled()
        {
            PlayerHandlers = new PlayerHandlers(this);
            ServerHandlers = new ServerHandlers(this);
            base.OnEnabled();
        }
        public override void OnDisabled()
        {

            base.OnDisabled();

        }
    }
}
