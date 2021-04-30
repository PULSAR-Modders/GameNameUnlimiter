using PulsarPluginLoader;

namespace GameNameUnlimiter
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.0.0";

        public override string Author => "18107";

        public override string ShortDescription => "Unlocks the character limit on game names";

        public override string Name => "Game name unlimiter";

        public override string HarmonyIdentifier()
        {
            return "id107.GameNameUnlimiter";
        }
    }
}
