using HarmonyLib;

namespace GameNameUnlimiter
{
    [HarmonyPatch(typeof(PLUILoadMenu), "LoadFromFile")]
    class HarmonyLoadMenu
    {
        static void Prefix(PLUILoadMenu __instance)
        {
            __instance.GameNameField.characterLimit = 0;
        }
    }
}
