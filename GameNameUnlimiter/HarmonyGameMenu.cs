using HarmonyLib;

namespace GameNameUnlimiter
{
    [HarmonyPatch(typeof(PLUICreateGameMenu), "Enter")]
    class HarmonyGameMenu
    {
        static void Prefix(PLUICreateGameMenu __instance)
        {
            __instance.GameNameField.characterLimit = 0;
        }
    }
}
